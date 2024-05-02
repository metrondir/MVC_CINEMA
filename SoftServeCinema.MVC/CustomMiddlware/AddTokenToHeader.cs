
namespace SoftServeCinema.MVC.CustomMiddlware
{
    public class AddTokenToHeader : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var JWToken = context.Session.GetString("accessToken");
            if (!string.IsNullOrEmpty(JWToken))
            {
                context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
            }
             await next(context);
        }
    }
}
