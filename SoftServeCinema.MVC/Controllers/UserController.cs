using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoftServeCinema.Core.DTOs.Users;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.MVC.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Web;


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
                    var userWithToken = JsonConvert.DeserializeObject<UserDTOWithTokens>(result);
                    if(await _userService.Exist(userWithToken.Id))
                    {
                        HttpContext.Session.Clear();
                        HttpContext.Session.SetString("accessToken", userWithToken.AccessToken);
                        HttpContext.Session.SetString("refreshToken", userWithToken.RefreshToken);
                        return new JwtSecurityTokenHandler().ReadJwtToken(userWithToken.AccessToken).Claims.FirstOrDefault(c => c.Type == "role")?.Value is "Admin" or "SuperAdmin" ? RedirectToAction("Index", "Admin") : RedirectToAction("Index", "Home");
                    }
                    var user = new UserRegisterDTO()
                    {
                        Email = userLoginDTO.Email,
                        RoleName = userWithToken.Role,
                        Id = userWithToken.Id,
                        FirstName = HttpContext.Session.GetString("FirstName"),
                        LastName = HttpContext.Session.GetString("LastName")
                    };
                    HttpContext.Session.Clear();
                    await _userService.Create(user);
                    HttpContext.Session.SetString("accessToken", userWithToken.AccessToken);
                    HttpContext.Session.SetString("refreshToken", userWithToken.RefreshToken);

                    return new JwtSecurityTokenHandler().ReadJwtToken(userWithToken.AccessToken).Claims.FirstOrDefault(c => c.Type == "role")?.Value is "Admin" or "SuperAdmin" ? RedirectToAction("Index", "Admin") : RedirectToAction("Index", "Home");

                }
                var errorMessage = await response.Content.ReadAsStringAsync();
                dynamic errorObject = JsonConvert.DeserializeObject<dynamic>(errorMessage);
                string errorMessageString = errorObject.title.ToString();
                TempData["ErrorMessage"] = errorMessageString;
                TempData["Email"] = userLoginDTO.Email;
            }

            return RedirectToAction("Login", "User");
        }
        public IActionResult Register()
        {
            return View("Register");
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
                    HttpContext.Session.SetString("FirstName", userRegisterDTO.FirstName);
                    HttpContext.Session.SetString("LastName", userRegisterDTO.LastName);
                    return RedirectToAction("SuccessRegister");
                }
                var errorMessage = await response.Content.ReadAsStringAsync();
                dynamic errorObject = JsonConvert.DeserializeObject<dynamic>(errorMessage);
                string errorMessageString = errorObject.title.ToString();
                TempData["ErrorMessage"] = errorMessageString;
                TempData["Email"] = userRegisterDTO.Email;
                TempData["FirstName"] = userRegisterDTO.FirstName;
                TempData["LastName"] = userRegisterDTO.LastName;
                return View();
            }

        }

        public async Task<IActionResult> GoogleLoginAsync()
        {
            var redirectUrl = Url.Action(nameof(GoogleResponse), "User", null, Request.Scheme);
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            var token = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }


        public async Task<IActionResult> GoogleResponse(UserRegisterDTO userRegisterDTO)
         {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            if (result?.Succeeded != true)
                return RedirectToAction(nameof(Login));
            var url = $"{WebConstants.ngrok}/api/User/signin-google";
            using (var httpClient = new HttpClient())
            {
                userRegisterDTO = new UserRegisterDTO
                {
                    Email = result.Principal.FindFirst(ClaimTypes.Email).Value,
                    FirstName = result.Principal.FindFirst(ClaimTypes.GivenName).Value,
                    LastName = result.Principal.FindFirst(ClaimTypes.Surname).Value,
                    Password = result.Principal.FindFirst(ClaimTypes.NameIdentifier).Value,
                    RoleName = "User"
                };

                var json = JsonConvert.SerializeObject(userRegisterDTO);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    var securityResult = await response.Content.ReadAsStringAsync();
                    var userWithToken = JsonConvert.DeserializeObject<UserDTOWithTokens>(securityResult);

                    HttpContext.Session.SetString("accessToken", userWithToken.AccessToken);
                    HttpContext.Session.SetString("refreshToken", userWithToken.RefreshToken);
                   
                    if (await _userService.Exist(userWithToken.Id))
                        return RedirectToAction("Index", "Home");
                    userRegisterDTO.Id = userWithToken.Id;
                    await _userService.Create(userRegisterDTO);
                    return new JwtSecurityTokenHandler().ReadJwtToken(userWithToken.AccessToken).Claims.FirstOrDefault(c => c.Type == "role").Value == "Admin" ? RedirectToAction("Home", "Admin") : RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

      
        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> ForgetPassword(EmailDTO emailDTO)
        {
            var url = WebConstants.ngrok + "/api/User/reset";
            using (var httpClient = new HttpClient())
            {
                emailDTO.Subject = "ResetPassword";
                var json = JsonConvert.SerializeObject(emailDTO);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, data);
                if(response.IsSuccessStatusCode)
                    return RedirectToAction("SuccessResetCode");
                var errorMessage = await response.Content.ReadAsStringAsync();
                dynamic errorObject = JsonConvert.DeserializeObject<dynamic>(errorMessage);
                string errorMessageString = errorObject.title.ToString();
                TempData["ErrorMessage"] = errorMessageString;
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetCodeDTO resetPasswordDTO)
        {

            var refererUrl = Request.Headers["Referer"].ToString();
            var queryString = new Uri(refererUrl).Query;
            var queryParameters = HttpUtility.ParseQueryString(queryString);

            if (HttpContext.Session.GetString("code") == null || HttpContext.Session.GetString("email") == null)
            {
                HttpContext.Session.SetString("code", queryParameters["code"]);
                HttpContext.Session.SetString("email", queryParameters["email"]);
            }
            resetPasswordDTO.Email = HttpContext.Session.GetString("email");
            resetPasswordDTO.ResetToken = HttpContext.Session.GetString("code");

            var url = WebConstants.ngrok + "/api/User/verify-reset-code";
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(resetPasswordDTO);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("Login", "User");
                }
                var errorMessage = await response.Content.ReadAsStringAsync();
                dynamic errorObject = JsonConvert.DeserializeObject<dynamic>(errorMessage);
                string errorMessageString = errorObject.title.ToString();
                TempData["ErrorMessage"] = errorMessageString;
            }
            return View();
        }



        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var url = WebConstants.ngrok + "/api/User/logout";

            var accessToken = HttpContext.Session.GetString("accessToken");
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Index", "Home");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            if(User.FindFirst(ClaimTypes.NameIdentifier) == null)
                return RedirectToAction("Home", "Index");
            var url = WebConstants.ngrok + "/api/User/";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    HttpContext.Session.Clear();
                    await _userService.Delete(Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value), CancellationToken.None);
                    return RedirectToAction("Home","Index");
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
        public IActionResult ForgetPassword()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
        public IActionResult SuccessResetCode()
        {
            return View();
        }

    }
}
