using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Framework
{
    public class UpdateDialogMessage
    {
        public readonly UpdateDialogMessageParameters Data;

        public UpdateDialogMessage(UpdateDialogMessageParameters data)
        {
            Data = data;
        }
    }
}
