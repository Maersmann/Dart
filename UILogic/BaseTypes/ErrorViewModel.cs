using GalaSoft.MvvmLight;
using Infrastructure.BaseType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILogic.BaseTypes
{
    public class ErrorViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        public readonly Dictionary<string, ICollection<string>>
            _validationErrors = new Dictionary<string, ICollection<string>>();

        public ErrorViewModel()
        {
            
        }


        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)
                || !_validationErrors.ContainsKey(propertyName))
                return null;

            return _validationErrors[propertyName];
        }

        public bool HasErrors
        {
            get { return _validationErrors.Count > 0; }
        }
    }
}
