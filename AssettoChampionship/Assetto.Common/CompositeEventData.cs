using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common
{
    public class CompositeEventData
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string FriendlyName { get; set; }

        public List<EventData> Events { get; set; }
    }
}
