using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Models
{
    public class tblUser
    {

        public int tblUserId { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        public int RoleId { get; set; }
        public virtual Role Roles { get; set; }
    }
    public class Role
    {
        public Role()
        {
            tblUsers = new HashSet<tblUser>();
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<tblUser> tblUsers { get; set; }
    }
}
