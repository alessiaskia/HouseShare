using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseShare.Models
{
    public class LoginRegisterModel
    {
        public LoginModel LoginModel { get; set; }
        public MembreModel ClientModel { get; set; }
    }
}