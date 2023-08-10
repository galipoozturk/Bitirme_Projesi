using Microsoft.VisualBasic;
using NTierSample.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSample.BLL.Abstract
{
    public interface IUserBLL : IBaseBLL<User>
    {
        User GetUserByLoginData(string mail, string password);
    }
}
