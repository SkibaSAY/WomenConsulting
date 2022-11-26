using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WomenConsulting.Class;

namespace WomenConsulting
{
    public class Protocol
    {
        public List<Fetus> fetuses;
        public GeneralSettings generalSettigns;

        public Protocol()
        {
            fetuses = new List<Fetus>();
            generalSettigns = new GeneralSettings();
        }
        
    }
}
