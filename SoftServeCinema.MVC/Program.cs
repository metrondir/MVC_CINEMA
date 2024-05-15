using Microsoft.EntityFrameworkCore;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.Core.Services;
using SoftServeCinema.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using SoftServeCinema.Core;
using SoftServeCinema.MVC.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using SoftServeCinema.Core.DTOs.Users;
using SoftServeCinema.MVC.CustomMiddlware;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CinemaDbContext");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext(connectionString);

// repository 
builder.Services.AddRepository();

// services
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IDirectorService, DirectorService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISuperAdminService, SuperAdminService>();
builder.Services.AddTransient<AddTokenToHeader>();
builder.Services.AddTransient<Interceptor>();
//session
builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(120);
});

// auto mapper
builder.Services.AddAutoMapper();

// fluent validators
builder.Services.AddValidators();

// file upload helper
builder.Services.AddSingleton<FileUpload>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowMyOrigins", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddHttpContextAccessor();

var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"]));
var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidIssuer = builder.Configuration["JWT:Issuer"],

    ValidateAudience = true,
    ValidAudience = builder.Configuration["JWT:Audience"],

    ValidateLifetime = true,

    ValidateIssuerSigningKey = true,
    ClockSkew = TimeSpan.Zero,
    IssuerSigningKey = key

};

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = tokenValidationParameters;
    })
    .AddCookie()
    .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
    {
        options.ClientId = builder.Configuration.GetSection("Autorization:ClientId").Value;
        options.ClientSecret = builder.Configuration.GetSection("Autorization:ClientSecret").Value;
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole",
    policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("RequireSuperAdminRole",
    policy => policy.RequireClaim(ClaimTypes.Role, "SuperAdmin"));
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowMyOrigins");
app.UseSession();
app.UseMiddleware<AddTokenToHeader>();
app.UseMiddleware<Interceptor>();



app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();