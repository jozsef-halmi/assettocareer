using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Framework
{
    public class ChangePageMessage
    {
        public readonly Type ViewModelType;
        public readonly ChangePageParameters Data;

        public ChangePageMessage(Type viewModelType, ChangePageParameters data)
        {
            ViewModelType = viewModelType;
            Data = data;
        }
    }
}
