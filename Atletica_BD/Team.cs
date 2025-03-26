using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atletica_BD
{
    public class Team : BaseEntity
    {
        //public string? Id { get; set; }
        public string? name { get; set; }
        public string? imageUrl { get; set; }
        public int totalKills { get; set; }
        public int totalDamage { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int totalGold { get; set; }
        public int totalDuration { get; set; }
    }
}
