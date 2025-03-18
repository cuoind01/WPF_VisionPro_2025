using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_VisionPro_2025.Models;

namespace WPF_VisionPro_2025.UserControls
{
    /// <summary>
    /// Interaction logic for UCTeach.xaml
    /// </summary>
    public partial class UCTeach : UserControl
    {
        private readonly MainWindow MainWindow;
        private readonly ClassCamera ClassCamera;
        public UCTeach(MainWindow MainWindow)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            this.ClassCamera = MainWindow.ClassCamera;
            BtnGrab.Click += BtnGrab_Click;
        }

        private void BtnGrab_Click(object sender, RoutedEventArgs e)
        {
            ImageTeach.Source = ClassCamera.BitmapToImageSource(ClassCamera.Grab());
        }
    }
}
