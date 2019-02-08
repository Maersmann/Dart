using GalaSoft.MvvmLight.Views;
using Infrastructure.OptionEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILogic.NotificationServices
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }

        Option option { get; set; }
    }
}
