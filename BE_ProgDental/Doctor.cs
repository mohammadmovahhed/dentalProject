using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BE_ProgDental
{
    public partial class Doctor
    {
        public Doctor()
        {
            this.Visits = new HashSet<Visit>();
        } 
        [Key]
        public int Id { get; set; }
        public string NezamPezeshki { get; set; }
        public string Name { get; set; }
        public string Takhasos { get; set; }
        public string Univercity { get; set; }
        public string Phone { get; set; }
        public string Darsad { get; set; }
        public byte Age { get; set; }
        public string Address { get; set; }
        public string PictureAddress { get; set; }
        
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
