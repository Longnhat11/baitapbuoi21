using DataAccess.DTO;
using DataAccess.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Baitapbuoi21.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;
        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        public IActionResult Index()
        {
            var Acc = _accountServices.GetAccount();
            return View(Acc);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> LogIn(AccountsRequestData requestData)
        {
            var model = new ReturnData();
            try
            {
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.PassWord)
                    )
                {
                    model.ReturnCode = -1;
                    model.ReturnMsg = "Dữ liệu không được trống";
                    return Json(model);
                }
                var rs = await new DataAccess.Services.AccountServices().LogIn(requestData);

                model.ReturnCode = rs.ReturnCode;
                model.ReturnMsg = rs.ReturnMsg;
                return Json(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(model);
        }

    }
}
