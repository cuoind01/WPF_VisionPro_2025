using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using WPF_VisionPro_2025.Tools;

namespace WPF_VisionPro_2025.UserControls
{
    /// <summary>
    /// Interaction logic for UCAuto.xaml
    /// </summary>
    public partial class UCAuto : UserControl
    {
        private readonly MainWindow MainWindow;
        private readonly ClassCamera ClassCamera;
        public UCAuto(MainWindow MainWindow)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            this.ClassCamera = MainWindow.ClassCamera;
            BtnGrab.Click += BtnGrab_Click;
        }

        private void BtnGrab_Click(object sender, RoutedEventArgs e)
        {
            ClassCogDisplay.cogDisplay.Image = ConvertBitmap2ICogImage(ClassCamera.Grab());
            ClassCogDisplay.cogDisplay.Fit(true);
            ClassCogDisplay.cogDisplay.HorizontalScrollBar = false;
            ClassCogDisplay.cogDisplay.VerticalScrollBar = false;
        }
        private ICogImage ConvertBitmap2ICogImage(Bitmap bitmap)
        {  return new CogImage8Grey(bitmap); }
       
    }
}
