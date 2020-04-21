using Firefly.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viktor.Providers
{
    [RegisterTransient]
    public class TestProvider
    {

        public string Test()
        {
            return "prdel";
        }
    }

}
