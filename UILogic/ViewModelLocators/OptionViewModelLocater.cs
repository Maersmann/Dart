using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILogic.NotificationServices;
using UILogic.ViewModels.OptionVM;

namespace UILogic.ViewModelLocators
{
    public class OptionViewModelLocater
    {
        public OptionViewModelLocater()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<OptionViewModel>();
            SimpleIoc.Default.Register<OptionMatchViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new OptionFrameNavigationService();
            navigationService.Configure("Match");
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public OptionViewModel Option
        {
            get { return ServiceLocator.Current.GetInstance<OptionViewModel>(); }
        }

        public OptionMatchViewModel OptionMatch
        {
            get { return ServiceLocator.Current.GetInstance<OptionMatchViewModel>(); }
        }

        public static void ClearOption()
        {
            ServiceLocator.Current.GetInstance<OptionViewModel>().Cleanup();

            SimpleIoc.Default.Unregister<OptionViewModel>();
            SimpleIoc.Default.Register<OptionViewModel>();

            SimpleIoc.Default.Unregister<OptionMatchViewModel>();
            SimpleIoc.Default.Register<OptionMatchViewModel>();
        }
    }
}
