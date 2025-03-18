using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_VisionPro_2025.Models
{
    public class ClassSystem
    {
       public ClassCamera ClassCamera;
        public ClassSystem()
        {
                
        }
        private void Initialize()
        {
            ClassCamera = new ClassCamera();
        }
    }
}
