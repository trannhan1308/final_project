using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OA.DTO.Auths
{
    public class UsersDTO
    {
        public string Code { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Address { get; set; }
        public int Gender { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Phone { get; set; }
        public int Position { get; set; }
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public List<SelectListItem> Genders { get; set; }
        public List<SelectListItem> Positions { get; set; }

        public UsersDTO()
        {
            Genders = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Nam",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "Nữ",
                    Value = "0"
                }
            };

            Positions = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "1",
                    Text = "Nhân viên quản lý hệ thống"
                },
                new SelectListItem
                {
                    Value = "2",
                    Text = "Bác sĩ"
                }
            };
        }
    }
}
