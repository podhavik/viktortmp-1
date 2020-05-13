using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViktorDataModel
{
    public interface IParameter
    {
        string Name { get; set; }
        string GetDescription();
    }
}
