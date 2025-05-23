using System.ComponentModel.DataAnnotations;

namespace EShopper.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)] // tipini belirtiyor yani yazarken yıldızlı
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
