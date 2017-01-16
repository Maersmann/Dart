using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Match.Matchobjekte
{
    public class MatchObjekt
    {
        public int LegZumSet { get; set; }
        public int SetZumSieg { get; set; }
        public int PunktZahlzumLeg { get; set; }
        public List<MatchSpieler>  SpielerList { get; set; }

        public MatchObjekt()
        {
            SpielerList = new List<MatchSpieler>();
             
        }

        public MatchObjekt getMatchMemento()
        {
            MatchObjekt memento = new MatchObjekt();
            memento.LegZumSet = this.LegZumSet;
            memento.SetZumSieg = this.SetZumSieg;
            memento.PunktZahlzumLeg = this.PunktZahlzumLeg;

            foreach(MatchSpieler spieler in SpielerList)
            {
                memento.SpielerList.Add(spieler.getMatchSpielerMemento());
            }

                
            return memento;
        }

    }
}
