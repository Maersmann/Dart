using GalaSoft.MvvmLight;
using Infrastructure.OptionEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using UILogic.BaseTypes;
using UILogic.Helper;
using UILogic.NotificationServices;

namespace UILogic.ViewModels.OptionVM
{
    public class OptionMatchViewModel: TextboxViewModel
    {
        private Option _Option;

        private IFrameNavigationService _navigationService;

        public OptionMatchViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            _Option = _navigationService.option;
            
            if (_Option == null)
            {
                _Option = new Option();
                LegZumSet = 3;
                SetZumSieg = 5;
                Punktzahl = 501;

            }
        }

        #region BindingObjects

        public int LegZumSet
        {
            get { return _Option.LegZumSet; }
            set
            {
                _Option.LegZumSet = value;
                RaisePropertyChanged("LegZumSet");
            }
        }

        public int SetZumSieg
        {
            get { return _Option.SetZumSieg; }
            set
            {
                _Option.SetZumSieg = value;
                RaisePropertyChanged("SetZumSieg");
            }
        }


        public int Punktzahl
        {
            get
            {
                return PunktzahlHelper.PunkzahlToIndex(_Option.Punktzahl);
            }
            set
            {
                _Option.Punktzahl = PunktzahlHelper.IndexToPunktzahl(value);
                RaisePropertyChanged("Punktzahl");
            }
        }
        #endregion
    }
}

