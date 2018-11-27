using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MatchEntity
{
    public class Match
    {
        public int LegZumSet { get; set; }
        public int SetZumSieg { get; set; }
        public int PunktZahlzumLeg { get; set; }
        //public List<MatchSpieler>  SpielerList { get; set; }

        public Match()
        { }
        // SpielerList = new List<MatchSpieler>();

    

        public Match getMatchMemento()
        {
            Match memento = new Match();
            memento.LegZumSet = this.LegZumSet;
            memento.SetZumSieg = this.SetZumSieg;
            memento.PunktZahlzumLeg = this.PunktZahlzumLeg;

          /*  foreach(MatchSpieler spieler in SpielerList)
            {
                memento.SpielerList.Add(spieler.getMatchSpielerMemento());
            }*/

                
            return memento;
        }

    }
}
