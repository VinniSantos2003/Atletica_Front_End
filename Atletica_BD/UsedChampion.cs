using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atletica_BD
{
    public class UsedChampion : BaseEntity
    {
       // public string? id { get; set; }
        public bool win { get; set; }
        public Match? match { get; set; }
        public Player? player { get; set; }
        public Champion? champions { get; set; }
    }
    
}
