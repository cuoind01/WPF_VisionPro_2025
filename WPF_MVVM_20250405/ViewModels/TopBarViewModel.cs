using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPF_MVVM_20250405.Models;

namespace WPF_MVVM_20250405.ViewModels
{
    public class TopBarViewModel:BaseViewModel
    {
        private readonly ClassSystem _classSystem;

        public TopBarViewModel(ClassSystem classSystem)
        {
            _classSystem = classSystem;
            Init();
        }

       
        private void Init()
        {

            Task.Factory.StartNew(() =>
            {
                while (_classSystem.isStart)
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        LbTime = DateTime.Now.ToString("HH:mm:ss");
                        LbDate = DateTime.Now.ToString("dd-MM-yyyy");
                    });
                    Thread.Sleep(500);
                }
            });
        }

        #region Fields
        private string lbTime;
        private string lbDate;

        #endregion
        #region Properties
        private string _TxtData;

        public string TxtData
        {
            get { return _TxtData; }
            set { _TxtData = value; OnPropertyChanged(); }
        }

        public string LbTime
        {
            get { return lbTime; }
            set
            {
                lbTime = value;
                OnPropertyChanged();
            }
        }


        public string LbDate
        {
            get { return lbDate; }
            set
            {
                lbDate = value;
                OnPropertyChanged();
            }
        }


        #endregion
    }
}
