using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Details.Interfaces
{
    internal interface IImageViewer
    {
        internal void NotifyFrame(BitmapSource source);
    }
}
