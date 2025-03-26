using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atletica_BD
{
    public class Match : BaseEntity
    {
        //public string? Id { get; set; }
        public Team? winner { get; set; }
        public Team? loser { get; set; }
        public double duration { get; set; }
        public int totalKills { get; set; }
        public int totalDamage { get; set; }
        public int totalGold { get; set; }

    }
}
