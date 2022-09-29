using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Cache
{
    public class Errors
    {
        public partial class CacheNotFoundException : Exception
        {
            public CacheNotFoundException(string message) : base(message) { }
        }
    }
}
