using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OA.DTO.Auths
{
    public class LoginModels
    {
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Password { get; set; }
    }

    public class LoginResponseModels
    {
        public string JwtToken { get; set; }
        public string AvatarURL { get; set; }
        public string FullName { get; set; }
    }
}
