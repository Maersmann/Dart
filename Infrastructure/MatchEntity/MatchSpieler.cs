using infrastructure.SpielerEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.MatchEntity
{
    [Table("MatchSpieler")]
    public class MatchSpieler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int SpielerID { get; set; }

        [ForeignKey("SpielerID")]
        public Spieler Spieler { get; set; }

    }
}
