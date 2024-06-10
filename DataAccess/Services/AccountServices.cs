using DataAccess.DBContext;
using DataAccess.DTO;
using DataAccess.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class AccountServices : IAccountServices
    {
        private AccountDbcontext db = new AccountDbcontext();
        public IEnumerable<Accounts> GetAccount()
        {
           var rs = db.accounts.ToList();
            return rs;
        }

        public async Task<ReturnData> LogIn(AccountsRequestData requestData)
        {
            ReturnData result = new ReturnData();
            try
            {
                //Check null
                if (requestData == null
                    || requestData.UserName == null
                    || requestData.PassWord == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                //check co tai khoan hay khong
                var Account = db.accounts.FirstOrDefault(a => a.UserName == requestData.UserName);
                if (Account == null)
                {
                    result.ReturnCode = -2;
                    result.ReturnMsg = "Tài Khoản KHông tồn tại!";
                    return result;
                }
                var user = db.accounts.FirstOrDefault(u => u.UserName == requestData.UserName && u.PassWord == requestData.PassWord);
                if (user== null)
                {
                    result.ReturnCode = -3;
                    result.ReturnMsg = "Sai mật khẩu đăng nhập!";
                    return result;
                }
                user.RememberMe = true;
                db.accounts.Update(user);
                db.SaveChanges();
                result.ReturnCode = 1;
                result.ReturnMsg = "Đăng nhập thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
        }

        public Task<ReturnData> LogOut(AccountsRequestData requestData)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnData> SingIn(AccountsRequestData requestData)
        {
            throw new NotImplementedException();
        }
    }
}
