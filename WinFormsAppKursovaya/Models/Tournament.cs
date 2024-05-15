using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppKursovaya.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public DateTime Data_Held { get; set; }
        public string Arena { get; set; }
    }
}
