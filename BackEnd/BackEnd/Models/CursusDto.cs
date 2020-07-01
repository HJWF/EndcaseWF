using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class CursusDto
    {
        public List<Cursus> Cursussen { get; set; }

        public List<CursusInstantie> CursusInstanties { get; set; }
    }
}