using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
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
    /// Interaction logic for UCSetting.xaml
    /// </summary>
    public partial class UCSetting : UserControl
    {
        private readonly MainWindow MainWindow;
        private readonly ClassCamera ClassCamera;
        public UCSetting(MainWindow MainWindow)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            this.ClassCamera = MainWindow.ClassCamera;
            ClassToolBlock.CogToolBlock.Subject = CogSerializer.LoadObjectFromFile(MainWindow.strPath) as CogToolBlock; 
            BtnGrab.Click += BtnGrab_Click;


        }

        private void BtnGrab_Click(object sender, RoutedEventArgs e)
        {
            ClassToolBlock.CogToolBlock.Subject.Inputs[0].Value = ConvertBitmap2ICogImage(ClassCamera.Grab());
            ClassToolBlock.CogToolBlock.Subject.Run();
        }
        private ICogImage ConvertBitmap2ICogImage(Bitmap bitmap)
        { return new CogImage8Grey(bitmap); }
    }
}
