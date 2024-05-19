using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoftServeCinema.Core.DTOs.Tags;
using SoftServeCinema.Core.DTOs.Users;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.Core.Services;
using SoftServeCinema.MVC.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{
    [Authorize(Roles = "SuperAdmin")]

    public class SuperAdminController : Controller
    {
        private readonly ISuperAdminService _superAdminService;
        public SuperAdminController(ISuperAdminService superAdminService)
        {
            _superAdminService = superAdminService;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;

            var allUsers = await _superAdminService.GetAllUsers();
            var userId = new JwtSecurityTokenHandler().ReadJwtToken(HttpContext.Session.GetString("accessToken")).Claims.FirstOrDefault(c => c.Type == "nameid").Value;

            var users = allUsers.Where(s => s.Id.ToString() != userId.ToString());

            if (users.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await users.ToPagedListAsync(page, pageSize));
        }

        public IActionResult Error()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> ChangeRole(ChangeRoleDTO changeRoleDTO)
        {
            var accessToken = HttpContext.Session.GetString("accessToken");

            var queryParams = new List<string>
            {
                $"Role={Uri.EscapeDataString(changeRoleDTO.RoleName)}",
                $"Email={Uri.EscapeDataString(changeRoleDTO.Email)}"
            };

            var queryString = string.Join("&", queryParams);
            var url = $"{WebConstants.ngrok}/api/User/change-role?{queryString}";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await _superAdminService.ChangeRoleAsync(changeRoleDTO);
                    if (result)
                    {
                        TempData[WebConstants.alertSuccessKey] = $"Роль користувача {changeRoleDTO.Email}  успішно змінена на {changeRoleDTO.RoleName}";
                        return RedirectToAction(nameof(Index));
                    }

                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));

            }
        }

    }
}
