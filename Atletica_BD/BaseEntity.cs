using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Atletica_BD
{
    public class BaseEntity
    {
       
        public Guid Id { get; set; }
        //private string name { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }

}
 