using System;
using System.Collections.Generic;

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
        public int Doctor_Id { get; set; }
        public int User_Id { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual User User { get; set; }
    }
}
