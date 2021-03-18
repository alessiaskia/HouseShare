using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseShare.Models
{
    public class LoginModel
    {
        private string __login, _password;

        [Required]
        public string Login
        {
            get
            {
                return __login;
            }

            set
            {
                __login = value;
            }
        }

        [Required]
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

    }
}
