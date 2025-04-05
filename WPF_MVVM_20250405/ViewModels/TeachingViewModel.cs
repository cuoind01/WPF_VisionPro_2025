using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_20250405.Models;

namespace WPF_MVVM_20250405.ViewModels
{
    public class TeachingViewModel : BaseViewModel
    {
        private readonly ClassSystem _classSystem;

        public TeachingViewModel(ClassSystem classSystem)
        {
            _classSystem = classSystem;
        }
        private string _strSystem;

        public string strSystem
        {
            get { return _strSystem; }
            set
            {
                _strSystem = value;
                OnPropertyChanged();
                _classSystem.OnStrTempChanged(value);
            }
        }
    }
}
