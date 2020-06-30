using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class CursusInstantie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StartDatum { get; set; }

        [Required]
        public Cursus Cursus { get; set; }
    }
}