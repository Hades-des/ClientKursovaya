using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CurseWork.Classes
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
