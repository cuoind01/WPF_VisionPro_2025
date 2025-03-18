using Cognex.VisionPro.Display;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;

namespace WPF_VisionPro_2025.Tools
{
    public class ClassCogDisplay:WindowsFormsHost
    {
        public CogDisplay cogDisplay;
        public ClassCogDisplay()
        {
                this.Child = this.cogDisplay = new CogDisplay();
            this.Loaded += ClassCogDisplay_Loaded;
        }

        private void ClassCogDisplay_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.cogDisplay.BackColor = Color.DimGray;
            cogDisplay.Fit(true);
            cogDisplay.HorizontalScrollBar = false;
            cogDisplay.VerticalScrollBar = false;
        }
    }
}
