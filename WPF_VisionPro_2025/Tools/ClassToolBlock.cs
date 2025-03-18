using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;

namespace WPF_VisionPro_2025.Tools
{
    public class ClassToolBlock : WindowsFormsHost
    {
        public CogToolBlockEditV2 CogToolBlock;
        public ClassToolBlock()
        {
            this.Child = this.CogToolBlock = new CogToolBlockEditV2();
        }
    }
}
