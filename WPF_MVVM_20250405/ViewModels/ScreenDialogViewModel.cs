using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_20250405.Models;

namespace WPF_MVVM_20250405.ViewModels
{
    public class ScreenDialogViewModel : BaseViewModel
    {
        private readonly ClassSystem classSystem;

        public ScreenDialogViewModel(ClassSystem classSystem)
        {
            this.classSystem = classSystem;
        }
        private string _TxtAlarm;

        public string TxtAlarm
        {
            get { return _TxtAlarm; }
            set
            {
                _TxtAlarm = value;
                OnPropertyChanged();
            }
        }

    }
}
