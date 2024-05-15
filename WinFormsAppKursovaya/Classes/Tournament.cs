using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WinFormsAppKursovaya.Classes
{
    public class Tournament
    {
        public int Id { get; set; }
        public DateTime Data_Held { get; set; }
        public string Arena { get; set; }
    }

}
