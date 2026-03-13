using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffmpeg_mini_gui.Repository
{
    internal interface  IAction
    {
        void Validate(ConversionProperties props);
    }
}
