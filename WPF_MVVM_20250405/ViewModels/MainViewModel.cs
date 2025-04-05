using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_MVVM_20250405.Models;

namespace WPF_MVVM_20250405.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ClassSystem _classSystem;
        public MainViewModel(ClassSystem classSystem)
        {
            _classSystem = classSystem;
            CurrentViewModel = _classSystem.autoViewModel;
            BottomViewModel = _classSystem.BottomBarViewModel;
            TopViewModel = _classSystem.TopBarViewModel;
            _classSystem.ChangeCurrentViewModel += _classSystem_ChangeCurrentViewModel;
           
        }

        private void _classSystem_ChangeCurrentViewModel(object sender, BaseViewModel e)
        {
            CurrentViewModel = e;
        }

       
        #region ViewModels
        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

        private BaseViewModel topViewModel;
        private BaseViewModel bottomViewModel;

        public BaseViewModel BottomViewModel
        {
            get { return bottomViewModel; }
            set
            {
                bottomViewModel = value;
                OnPropertyChanged();
            }
        }
        public BaseViewModel TopViewModel
        {
            get { return topViewModel; }
            set
            {
                topViewModel = value;
                OnPropertyChanged();
            }
        }
        #endregion


    }

}
