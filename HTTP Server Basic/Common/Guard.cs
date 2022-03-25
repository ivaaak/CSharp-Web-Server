using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Server_Basic.Common
{
    public static class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if(value == null)
            {
                name ??= "Value"; //name = name ?? "value"

                throw new ArgumentNullException($"{name} can not be null");
            }
        }
    }
}
