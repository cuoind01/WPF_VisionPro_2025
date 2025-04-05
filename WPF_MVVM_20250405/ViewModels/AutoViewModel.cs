using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF_MVVM_20250405.Models;

namespace WPF_MVVM_20250405.ViewModels
{

    public class AutoViewModel : BaseViewModel
    {
        private readonly ClassSystem _classSystem;
        private ObservableCollection<Data> _DataCollection;

        public ObservableCollection<Data> DataCollection
        {
            get { return _DataCollection; }
            set { _DataCollection = value; }
        }


        public AutoViewModel(ClassSystem classSystem)
        {
            _classSystem = classSystem;
            _classSystem.strTempChanged += _classSystem_strTempChanged;
            DataCollection  =new ObservableCollection<Data>();
            DataCollection.Add(new Data(1, 2, 3, Brushes.Crimson));
            DataCollection.Add(new Data(1, 2, 3, Brushes.Black));
            DataCollection.Add(new Data(1, 2, 3, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00FF00"))));
            DataCollection.Add(new Data(1, 2, 3, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0000FF"))));

        }
        private BaseViewModel _SubViewModel = new SubViewModel();

        public BaseViewModel SubViewModel
        {
            get { return _SubViewModel; }
            set { _SubViewModel = value;
                OnPropertyChanged();
            }
        }

        private void _classSystem_strTempChanged(object sender, string e)
        {
            strSystem = e;
        }

        private string _strSystem;

        public string strSystem
        {
            get { return _strSystem; }
            set
            {
                _strSystem = value;
                OnPropertyChanged();
            }
        }

    }
    public class Data
    {
        public Data(int stt, int name, int age, Brush fg)
        {
            Stt = stt;
            Name = name;
            Age = age;
            Fg = fg;
        }

        public int Stt { get; set; }
        public int Name { get; set; }
        public int Age { get; set; }
        public Brush Fg { get; set; }
    }
}
