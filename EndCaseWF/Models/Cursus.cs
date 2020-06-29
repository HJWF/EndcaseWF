using System;
using System.ComponentModel.DataAnnotations;

namespace EndCaseWF.Models
{
    public class Cursus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AantalDagen { get; set; }

        [Required]
        public string Titel { get; set; }

        [Required]
        public string Code { get; set; }
    }
}