using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class CursusInstantie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StartDatum { get; set; }
    }
}