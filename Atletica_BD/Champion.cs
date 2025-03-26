using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atletica_BD
{
    public class Champion : BaseEntity
    {
        public string? name { get; set; }
        public string? urlImage { get; set; }//Imagem do campeão

    }
}
