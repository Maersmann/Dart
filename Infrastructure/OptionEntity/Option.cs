using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.OptionEntity
{
    [Table("Option")]
    public class Option
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; } 

        public int LegZumSet { get; set; }

        public int SetZumSieg { get; set; }

        public int Punktzahl { get; set; }


    }
}
