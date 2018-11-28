

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using UILogic.ViewModels.MatchVM;
using UILogic.ViewModels.Person;

namespace UILogic
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);


            SimpleIoc.Default.Register<AuswahlPersonViewModel>();
            SimpleIoc.Default.Register<AddPersonViewModel>();
            SimpleIoc.Default.Register<MatchSpielerAuswahlViewModel>();
        }

        public AddPersonViewModel AddPerson => ServiceLocator.Current.GetInstance<AddPersonViewModel>();

        public AuswahlPersonViewModel PersonAuswahl => ServiceLocator.Current.GetInstance<AuswahlPersonViewModel>();

        public MatchSpielerAuswahlViewModel MatchSpielerAuswahl => ServiceLocator.Current.GetInstance<MatchSpielerAuswahlViewModel>();

        public static void Cleanup()
        {
           
        }
    }
}