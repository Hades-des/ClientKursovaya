using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CurseWork.Classes
{

    public class Fighter
    {
        public int Id { get; set; }
        public int Weight_Category { get; set; }
        public int Coach { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}