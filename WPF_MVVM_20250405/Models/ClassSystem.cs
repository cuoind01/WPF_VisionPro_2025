using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_20250405.ViewModels;

namespace WPF_MVVM_20250405.Models
{
    public class ClassSystem
    {
       public bool isStart = true;

        public AutoViewModel autoViewModel { get; set; }
        public TeachingViewModel teachingViewModel { get; set; }
        public BottomBarViewModel BottomBarViewModel { get; set; }
        public  TopBarViewModel TopBarViewModel { get; set; }


        public event EventHandler<string> strTempChanged;
        public event EventHandler<BaseViewModel> ChangeCurrentViewModel;
        public ClassSystem()
        {
            autoViewModel = new AutoViewModel(this);
            teachingViewModel = new TeachingViewModel(this);
            BottomBarViewModel = new BottomBarViewModel(this);
            TopBarViewModel = new TopBarViewModel(this);
        }
        public string strTemp { get; set; }
        public void OnStrTempChanged(string newValue)
        {
            strTemp = newValue;
            this.strTempChanged?.Invoke(this, strTemp);
        }
        public void OnChangeCurrentViewModel(BaseViewModel currentViewModel)
        {
            this.ChangeCurrentViewModel.Invoke(this, currentViewModel);
        }
    }
}
