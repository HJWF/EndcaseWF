using System.Collections.Generic;

namespace BackEnd.Models
{
    public class CursusDto
    {
        public List<Cursus> Cursussen { get; set; }

        public List<CursusInstantie> CursusInstanties { get; set; }
    }
}