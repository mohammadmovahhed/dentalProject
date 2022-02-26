using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ProgDental
{
    public partial class Visit
    {
        public int Id { get; set; }
        public string NameBimar { get; set; }
        public string MoshkelBimar { get; set; }
        public string Bimeh { get; set; }
        public string DoctorName { get; set; }
        public string ZamanVisit { get; set; }
        public string HazineKol { get; set; }
        public string HazineVisit { get; set; }

        //relations 
        [ForeignKey(nameof(Doctor))]
        public int? Doctor_Id { get; set; }
        public virtual Doctor Doctor { get; set; }


        [ForeignKey(nameof(User))]
        public int? User_Id { get; set; }
        public virtual User User { get; set; }
    }
}
