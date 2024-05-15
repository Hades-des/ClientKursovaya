using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WinFormsAppKursovaya.Classes
{
    public class WeightCategory
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Weight { get; set; }
    }
}
