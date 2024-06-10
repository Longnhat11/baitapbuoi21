using DataAccess.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IServices
{
    public interface IAccountServices
    {
        Task<ReturnData> LogIn(AccountsRequestData requestData);
        Task<ReturnData> LogOut(AccountsRequestData requestData);
        Task<ReturnData> SingIn(AccountsRequestData requestData);
        IEnumerable<Accounts> GetAccount();
    }
}
