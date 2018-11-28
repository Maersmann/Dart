using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.MatchEntity
{
    [Table("Match")]
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int Legs { get; set; }

        public int Sets { get; set; }

        public int PunktZahl { get; set; }


        //public List<MatchSpieler>  SpielerList { get; set; }

        public Match()
        { }
        // SpielerList = new List<MatchSpieler>();

    
        /*
        public Match getMatchMemento()
        {
            //   Match memento = new Match();
            //   memento.LegZumSet = this.LegZumSet;
            //   memento.SetZumSieg = this.SetZumSieg;
            //   memento.PunktZahlzumLeg = this.PunktZahlzumLeg;

              foreach(MatchSpieler spieler in SpielerList)
              {
                  memento.SpielerList.Add(spieler.getMatchSpielerMemento());
              }


            return null; //memento;
        }*/

    }
}
