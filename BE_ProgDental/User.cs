using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BE_ProgDental
{
    public partial class User
    {
        public User()
        {
            this.Visits = new HashSet<Visit>();
        }
        [Key]
        public int Id { get; set; }
        public string CodeMelli { get; set; }
        public string Name { get; set; }
        public string TimeEnter { get; set; }
        public string Tahsilat { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public string Moaref { get; set; }
        public string Jop { get; set; }
        public string GroupBload { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
