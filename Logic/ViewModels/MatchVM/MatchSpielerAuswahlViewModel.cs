using GalaSoft.MvvmLight;
using infrastructure.MatchEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILogic.ViewModels.MatchVM
{
    public class MatchSpielerAuswahlViewModel : ViewModelBase
    {
        private Match _Match;

        public MatchSpielerAuswahlViewModel()
        {
            _Match = new Match();

            AnzahlLeg = 3;
            AnzahlSet = 5;
            Punktzahl = 501;
        }

        public int AnzahlLeg { get; set; }

        public int AnzahlSet { get; set; }

        public int Punktzahl { get; set; }

    }
}
