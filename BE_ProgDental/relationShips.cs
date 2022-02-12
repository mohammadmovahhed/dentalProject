using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_ProgDental
{
    public class relationShips
    {
        public int Id { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual PatientInfo Patient { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
