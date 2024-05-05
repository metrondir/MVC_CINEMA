using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoftServeCinema.Core.DTOs.Users;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.Core.Services;
using SoftServeCinema.MVC.Helpers;
using System.Text;
using X.PagedList;

namespace SoftServeCinema.MVC.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]

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

            var tags = await _superAdminService.GetAllUsers();

            if (tags.Count() <= (page - 1) * pageSize) return BadRequest();

            return View(await tags.ToPagedListAsync(page, pageSize));
        }

        public IActionResult Error()
        {
            return View();
        }
       
        public async Task<IActionResult> ChangeRole(ChangeRoleDTO changeRoleDTO)
        {
           
            var url = WebConstants.ngrok + "/api/User/changeRole";
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(changeRoleDTO);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    var result = await _superAdminService.ChangeRoleAsync(changeRoleDTO);
                    if(result)
                        return RedirectToAction("Manage");
                    return View();
                }
                return View();
            }
        }

    }
}
