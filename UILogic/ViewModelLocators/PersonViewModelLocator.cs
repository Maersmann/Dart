

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using UILogic.ViewModels.MatchVM;
using UILogic.ViewModels.PersonVM;

namespace UILogic.ViewModelLocators
{

    public class PersonViewModelLocator
    {

        private static AuswahlPersonViewModel _auswahlPersonViewModel;

        public PersonViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);


            SimpleIoc.Default.Register<AddPersonViewModel>();

        }

        public static AuswahlPersonViewModel AuswahlPersonViewModelStatic
        {
            get
            {
                if (_auswahlPersonViewModel == null)
                    CreateAuswahPersonViewModel();

                return _auswahlPersonViewModel;
            }
        }

        public AuswahlPersonViewModel AuswahlPersonViewModel
        {
            get
            {
                return AuswahlPersonViewModelStatic;
            }
        }

        public static void CreateAuswahPersonViewModel()
        {
            if (_auswahlPersonViewModel == null)
                _auswahlPersonViewModel = new AuswahlPersonViewModel();
        }

        public static void ClearAuswahlPersonViewModel()
        {
            _auswahlPersonViewModel = null;
        }



        public static AddPersonViewModel AddPerson => ServiceLocator.Current.GetInstance<AddPersonViewModel>();

        

       

        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<AuswahlPersonViewModel>();
        }
    }
}