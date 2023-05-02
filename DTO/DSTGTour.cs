using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DSTGTour
    {
        public string MATOUR { get; set; }
        public int STT { get; set; }
        public string HOTEN { get; set; } 
        public string CMND { get; set; }
        public DSTGTour()
        {
            // Set the default values of the properties.
            MATOUR = "";
            STT = 0;
            HOTEN = "";
            CMND = "";
        }
    }
}
