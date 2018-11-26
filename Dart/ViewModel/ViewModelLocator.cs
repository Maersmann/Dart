

using CommonServiceLocator;
using Dart.Person;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Dart.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);


            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AddPersonViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AddPersonViewModel AddPerson => ServiceLocator.Current.GetInstance<AddPersonViewModel>();

        public static void Cleanup()
        {
           
        }
    }
}