using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WinFormsAppKursovaya.Classes
{

    public class Trainer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Rank { get; set; }
        public int Age { get; set; }
    }
}