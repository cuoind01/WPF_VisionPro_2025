using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_MVVM_20250405.Models;
using WPF_MVVM_20250405.Views;

namespace WPF_MVVM_20250405.ViewModels
{
    public class BottomBarViewModel : BaseViewModel
    {
        private readonly ClassSystem _classSystem;

        public BottomBarViewModel(ClassSystem classSystem)
        {
            _classSystem = classSystem;
            ContentAuto = "Auto";
            ContentTeaching = "Teaching";
            ContentSetting = "Setting";
            ContentExit = "Exit";   
            AutoCommand = new RelayCommand<MainViewModel>(p => { classSystem.OnChangeCurrentViewModel(classSystem.autoViewModel); }, p => true);
            TeachingCommand = new RelayCommand<MainViewModel>(p => { classSystem.OnChangeCurrentViewModel(classSystem.teachingViewModel); }, p => true);
            SettingCommand = new RelayCommand<MainViewModel>(p => { ScreenDialog(); }, p => true);
            ExitCommand = new RelayCommand<MainViewModel>(p => { ExitProgram(); }, p => true);
        }

        private void ScreenDialog()
        {
            ScreenDialogViewModel screenDialogViewModel = new ScreenDialogViewModel(_classSystem);
            screenDialogViewModel.TxtAlarm = "This is a test alarm message.";
            ScreenDialogView screenDialogView = new ScreenDialogView()
            {
                DataContext = screenDialogViewModel
            };
            ContentSetting = "ABC";
            OnPropertyChanged(nameof(ContentSetting));

            screenDialogView.ShowDialog();
        }
        #region Commands
        public string ContentAuto { get; set; }
        public string ContentTeaching { get; set; }
        public string ContentSetting { get; set; }
        public string ContentExit { get; set; }
        public ICommand AutoCommand { get; set; }
        public ICommand TeachingCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        #endregion
        private void ExitProgram()
        {
            _classSystem.isStart = false;   
            App.Current.Shutdown();
        }
    }
}
