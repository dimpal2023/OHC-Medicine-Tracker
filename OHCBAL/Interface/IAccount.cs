﻿using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IAccount
    {
        LoginRespone Login(LoginModel model);
        LoginModel CheckUserEmail(LoginModel model);
        LoginModel ChangePassword(LoginModel model);
    }
}
