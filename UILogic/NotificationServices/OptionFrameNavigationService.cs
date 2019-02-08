using GalaSoft.MvvmLight.Messaging;
using Infrastructure.OptionEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UILogic.Messages.OptionMessage;

namespace UILogic.NotificationServices
{
    class OptionFrameNavigationService : IFrameNavigationService, INotifyPropertyChanged
    {
        private readonly IList<string> _pagesByKey;
        private readonly List<string> _historic;
        private string _currentPageKey;
        private Option _option;

  
        public string CurrentPageKey
        {
            get
            {
                return _currentPageKey;
            }

            private set
            {
                if (_currentPageKey == value)
                {
                    return;
                }

                _currentPageKey = value;
                OnPropertyChanged("CurrentPageKey");
            }
        }

        public object Parameter { get; private set; }
        
        Option IFrameNavigationService.option { get => _option; set => _option = value; }

        public OptionFrameNavigationService()
        {
            _pagesByKey = new List<string>();
            _historic = new List<string>();
        }


        public void GoBack()
        {
            if (_historic.Count > 1)
            {
                _historic.RemoveAt(_historic.Count - 1);
                NavigateTo(_historic.Last(), null);
            }
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {

                Messenger.Default.Send<OpenOptionView>(new OpenOptionView() { ViewName = pageKey });
                Parameter = parameter;
                _historic.Add(pageKey);
                CurrentPageKey = pageKey;
            }
        }

        public void Configure(string key)
        {
            lock (_pagesByKey)
            {
                _pagesByKey.Add(key);             
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
