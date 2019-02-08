using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.OptionEntity;

namespace UILogic.Messages.OptionMessage
{
    public class OpenOptionView
    {
        public String  ViewName { get; set;}
    }

    public class setOption
    {
        public Option option { get; set; }
    }
}
