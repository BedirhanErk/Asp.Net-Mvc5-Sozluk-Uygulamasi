using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class AdminDto
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public bool AdminStatus { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public int RoleId { get; set; }
    }
}
