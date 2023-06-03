using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Resume
{
    public class UserResume
    {
        [Key]
        public int id_user_resume { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Pobatkovi { get; set; }
        public DateTime Date { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
       // public string Experience { get; set; }
       // public string Skills { get; set; }
     //   public string Personal_qualities { get; set; }
        public byte[] Picture { get; set; }
    }
}
