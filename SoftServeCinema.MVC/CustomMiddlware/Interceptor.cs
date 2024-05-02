
using Newtonsoft.Json;
using SoftServeCinema.Core.DTOs.Users;
using SoftServeCinema.MVC.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SoftServeCinema.MVC.CustomMiddlware
{
    public class Interceptor : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var accessToken = context.Session.GetString("accessToken");
            if (string.IsNullOrEmpty(accessToken))
            {
                await next(context);
                return;
            }

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);
            var expDate = token.ValidTo;

            if (expDate <= DateTime.Now)
            {
                await next(context);
                return;
            }

            var refreshToken = context.Session.GetString("refreshToken");
            if (string.IsNullOrEmpty(refreshToken))
            {
                await next(context);
                return;
            }
            var refreshTokenUrl = WebConstants.ngrok + "/api/User/refresh";
            using var httpClient = new HttpClient();
            var refreshContent = new StringContent(refreshToken, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(refreshTokenUrl, refreshContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponseDTO>(result);
                context.Session.Clear();
                context.Session.SetString("accessToken", tokenResponse.AccessToken);
                context.Session.SetString("refreshToken", tokenResponse.RefreshToken);
            }
            await next(context);
        }
    }
}
