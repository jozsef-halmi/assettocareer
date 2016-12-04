using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Framework
{
    public class OpenDialogMessage
    {
        public readonly OpenDialogMessageParameters Data;

        public OpenDialogMessage(OpenDialogMessageParameters data)
        {
            Data = data;
        }
    }
}
