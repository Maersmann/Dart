using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILogic.ViewModels.MatchVM;

namespace UILogic.ViewModelLocators
{
    public class MatchViewModelLocater
    {
        public MatchViewModelLocater()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MatchSpielerAuswahlViewModel>();
        }

        public static MatchSpielerAuswahlViewModel MatchSpielerAuswahl => ServiceLocator.Current.GetInstance<MatchSpielerAuswahlViewModel>();
    }
}
