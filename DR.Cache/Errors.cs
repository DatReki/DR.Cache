using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

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