using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Cursus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Duur { get; set; }

        [Required]
        public string Titel { get; set; }

        [Required]
        public string Code { get; set; }
    }
}