using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using System.IO;
using Dart.Optionen.DataModul;

namespace Dart.Optionen.Utils
{
    public class OptionIni
    {
        private FileIniDataParser _parser = new FileIniDataParser();


        public OptionIni()
        {
            _parser = new FileIniDataParser();
        }

        public OptionGame readIniGame()
        {
            OptionGame optGame = new OptionGame();
            int ParseResult = -1;
            if (File.Exists("game.ini"))
            {
                IniData IniData = _parser.ReadFile("game.ini");
                if(int.TryParse(IniData.Sections["Game"].GetKeyData("Punktzahl").Value, out ParseResult)) 
                    optGame.Punktzahl   = int.Parse(IniData.Sections["Game"].GetKeyData("Punktzahl").Value);

                if (int.TryParse(IniData.Sections["Game"].GetKeyData("Leg").Value, out ParseResult))
                    optGame.LegZumSet   = int.Parse(IniData.Sections["Game"].GetKeyData("Leg").Value );

                if (int.TryParse(IniData.Sections["Game"].GetKeyData("Set").Value, out ParseResult))
                    optGame.SetZumSieg  = int.Parse(IniData.Sections["Game"].GetKeyData("Set").Value );
            }
            return optGame;
        }

        public void writeIniGame( OptionGame inOptionGame )
        {
            IniData IniData = new IniData();
            IniData.Sections.AddSection("Game");

            IniData.Sections.GetSectionData("Game").Keys.AddKey("Punktzahl", inOptionGame.Punktzahl.ToString());
            IniData.Sections.GetSectionData("Game").Keys.AddKey("Leg", inOptionGame.LegZumSet.ToString());
            IniData.Sections.GetSectionData("Game").Keys.AddKey("Set", inOptionGame.SetZumSieg.ToString());

            _parser.WriteFile("game.ini", IniData);
        }
    }
}
