using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppKursovaya.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Tournament { get; set; }
        public int Fighter_1 { get; set; }
        public int Fighter_2 { get; set; }
        public int Victory_method { get; set; }
        public string Result { get; set; }

    }
}
