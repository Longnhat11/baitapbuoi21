using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
    }
    public class ReturnDataReturnAccount :ReturnData 
    { 
        public Accounts accounts { get; set; }
    }
}
