using OA.Entities.PhieuKham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Users
{
    public class UsersEntities : BaseEntities
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public int Position { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<PhieuKhamEntities> PhieuKhams { get; set; }
    }
}
