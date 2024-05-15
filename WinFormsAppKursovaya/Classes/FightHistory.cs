using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WinFormsAppKursovaya.Classes
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

