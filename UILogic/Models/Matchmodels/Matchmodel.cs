using infrastructure.MatchEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILogic.Models.Matchmodels
{
    public class Matchmodel
    {
        

        public Matchmodel()
        {
            this.SpielerList = new ObservableCollection<MatchspielerModel>();
        }

        public ObservableCollection<MatchspielerModel> SpielerList { get; set; }

        public int AnzahlLeg { get; set; }

        public int AnzahlSet { get; set; }

        public int Punktzahl { get; set; }

    }
}
