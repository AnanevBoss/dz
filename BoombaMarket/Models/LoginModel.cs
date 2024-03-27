using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoombaMarket.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Поле 'Login' обязательно для заполнения")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле 'Password' обязательно для заполнения")]
        public string Password { get; set; }
    }
}