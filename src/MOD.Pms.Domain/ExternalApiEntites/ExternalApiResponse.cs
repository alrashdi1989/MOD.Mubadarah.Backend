using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD.Pms.ExternalApiEntites
{
    public class ExternalApiResponse<T>
    {
        public ICollection<T> Items { get; set; }
        public bool HasMore { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
        public ICollection<NavigationLink> Links { get; set; }
    }
}
