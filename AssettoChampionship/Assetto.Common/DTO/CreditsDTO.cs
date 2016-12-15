using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Common.DTO
{
    public class CreditsDTO : CreditsData
    {

        public bool ToolTipAvailable
        {
            get { return !string.IsNullOrEmpty(ToolTip); }
        }

        public bool ExternalLinkAvailable
        {
            get { return !string.IsNullOrEmpty(ToolTip); }
        }

        public string TooltipTitle { get; set; }
    }
}
