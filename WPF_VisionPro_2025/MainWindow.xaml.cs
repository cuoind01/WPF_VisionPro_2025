using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPF_VisionPro_2025.UserControls;

namespace WPF_VisionPro_2025
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum eUserControl { Auto, Teach, Setting}
        Dictionary<eUserControl, UserControl> DicUserControl;
        public ClassCamera ClassCamera;
        public string strPath = @"D:\8. CSharp 2024\WPF_VisionPro_2025\WPF_VisionPro_2025\Jobs\ToolBlock_Count_Hole_Camera.vpp";
        public MainWindow(ClassCamera ClassCamera)
        {
            InitializeComponent();
            this.ClassCamera = ClassCamera;
            Initialize();
            CurrentUserControl.Content = DicUserControl[eUserControl.Auto];
            BtnAuto.Click += BtnAuto_Click;
            BtnTeach.Click += BtnTeach_Click;
            BtnSetting.Click += BtnSetting_Click;
        }

        private void BtnSetting_Click(object sender, RoutedEventArgs e)
        {
            CurrentUserControl.Content = DicUserControl[eUserControl.Setting];
        }

        private void BtnTeach_Click(object sender, RoutedEventArgs e)
        {
            CurrentUserControl.Content = DicUserControl[eUserControl.Teach];
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            CurrentUserControl.Content = DicUserControl[eUserControl.Auto];
        }

        void Initialize()
        {
            DicUserControl = new Dictionary<eUserControl, UserControl>();
            DicUserControl.Add(eUserControl.Auto, new UCAuto(this));
            DicUserControl.Add(eUserControl.Teach, new UCTeach(this));
            DicUserControl.Add(eUserControl.Setting, new UCSetting(this));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ClassCamera.Close();
        }
    }
}
