using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Infrastructure.OptionEntity.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UILogic.Messages.OptionMessage;
using UILogic.NotificationServices;
using UILogic.ViewModelLocators;

namespace UILogic.ViewModels.OptionVM
{
    public class OptionViewModel: ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private RelayCommand _loadedCommand;
        private RelayCommand _CloseWindowCommand;
        private OptionRepository _Openrepo;
        public ICommand ISaveOptionAndClose { get; private set; }

        public OptionViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;

            ISaveOptionAndClose = new RelayCommand<IClosable>(this.SaveOptionAndClose);

            _Openrepo = new OptionRepository();
            _navigationService.option = _Openrepo.getOption();
        }

        private void SaveOptionAndClose(IClosable parameter)
        {
            //Messenger.Default.Send<OpenOptionFrame>(new OpenOptionFrame() { newSpieler = _SelectedSpieler });
            var closable = parameter as IClosable;
            if (closable != null)
            {
                _Openrepo.AktualisiereOption(_navigationService.option);
                closable.Close();
                OptionViewModelLocater.ClearOption();
            }
        }

        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Match");
                    }));
            }
        }
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _CloseWindowCommand
                    ?? (_CloseWindowCommand = new RelayCommand(
                    () =>
                    {
                        OptionViewModelLocater.ClearOption();
                    }));
            }
        }

        public void Cleanup()
        {
            _navigationService.option = null;
        }


    }
}
