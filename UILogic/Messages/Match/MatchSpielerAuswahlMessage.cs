using infrastructure.SpielerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILogic.Messages.Match
{
    public class OpenAuswahlSpielerViewMessage
    {

    }

    public class AddNeuenSpielerMessage
    {
        public Spieler newSpieler { get; set; }
    }


}
