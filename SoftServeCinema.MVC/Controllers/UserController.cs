using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoftServeCinema.Core.DTOs.Users;
using SoftServeCinema.Core.DTOs.Token;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Helpers;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace SoftServeCinema.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }
        public async Task<IActionResult> Index()
        {
           
           var accessToken = HttpContext.Session.GetString("accessToken");
           var refreshToken =  HttpContext.Session.GetString("refreshToken");
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var url = WebConstants.ngrok + "/api/User/login";
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(userLoginDTO);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<TokenDTO>(result);
                    HttpContext.Session.SetString("accessToken", token.accessToken);
                    HttpContext.Session.SetString("refreshToken", token.refreshToken);
                    
                    return RedirectToAction("Index");
                }
            }
            
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            var url = WebConstants.ngrok + "/api/User/register";
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(userRegisterDTO);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    await _userService.Create(userRegisterDTO);
                    return RedirectToAction("SuccessRegister");
                }
            }

            return View();
        }
        
        public async Task RegisterByGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(GoogleResponse))

            });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Type,
                claim.Value,
                claim.Issuer,
                claim.OriginalIssuer,
            });
            return Json(claims);

        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var url = WebConstants.ngrok + "/api/User/";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return RedirectToAction("SuccessRegister");
                }
            }

            return View();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var url = WebConstants.ngrok + "/api/User/";
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    await _userService.Delete(Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value), CancellationToken.None);

                    return RedirectToAction("SuccessRegister");
                }
            }

            return View();
        }

        public IActionResult SuccessRegister()
        {
            return View();
        }
        public IActionResult EmailConfirmed()
        {
            return View();
        }

        public IActionResult EmailNotConfirmed()
        {
            return View();
        }
    }
}
