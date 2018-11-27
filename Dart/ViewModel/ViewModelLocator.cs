

using CommonServiceLocator;
using Dart.Person;
using Dart.Person.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Dart.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);


            SimpleIoc.Default.Register<AuswahlPersonViewModel>();
            SimpleIoc.Default.Register<AddPersonViewModel>();
        }

        public AddPersonViewModel AddPerson => ServiceLocator.Current.GetInstance<AddPersonViewModel>();

        public AuswahlPersonViewModel PersonAuswahl => ServiceLocator.Current.GetInstance<AuswahlPersonViewModel>();

        public static void Cleanup()
        {
           
        }
    }
}