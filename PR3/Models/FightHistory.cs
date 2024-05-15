using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppKursovaya.Models
{
    public class FightHistory
    {
        public int Id { get; set; }
        public int Fighter { get; set; }
        public int Tournament { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}
