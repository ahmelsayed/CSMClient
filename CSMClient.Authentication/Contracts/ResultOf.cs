using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMClient.Authentication.Contracts
{
    internal class ResultOf<T>
    {
        public T[] value { get; set; }
    }
}
