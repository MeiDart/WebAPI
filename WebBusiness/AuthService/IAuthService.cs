﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.RequestModels.AuthRequestModel;

namespace WebBusiness.AuthService
{
    public interface IAuthService
    {
        public Task Register (UserModel userInfo);
        public Task Login (UserModel userInfo);
    }
}
