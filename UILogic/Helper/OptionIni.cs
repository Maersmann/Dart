using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UILogic.Helper
{
    public class OptionIni
    {/*
        private static string FILENAME = "conf.ini";
        private String IniPath;

        private int _ParseResult = -1;
        private String _KeyResult = "";

        private FileIniDataParser _parser = new FileIniDataParser();
        private IniData _IniData;

        public OptionGame OptionGame { get; set; }
        public OptionStatistik OptionStatistik { get; set; }



        public OptionIni()
        {

            IniPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Dart\\";
            if (!Directory.Exists(IniPath))
                Directory.CreateDirectory(IniPath);

            IniPath += FILENAME;


            OptionGame = new OptionGame();
            _parser = new FileIniDataParser();
            OptionStatistik = new OptionStatistik();
            if (File.Exists(IniPath))
            { 
                _IniData = _parser.ReadFile(IniPath);

                readIniGame();
                readStatistik();
            }
        }

        private void readIniGame()
        {
            if (_IniData.Sections["Game"]== null) return;
            if (_IniData.Sections["Game"].GetKeyData("Punktzahl") == null) return ;
            if (_IniData.Sections["Game"].GetKeyData("Leg") == null) return ;
            if (_IniData.Sections["Game"].GetKeyData("Set") == null) return ;

            if (int.TryParse(_IniData.Sections["Game"].GetKeyData("Punktzahl").Value, out _ParseResult))
                OptionGame.Punktzahl   = int.Parse(_IniData.Sections["Game"].GetKeyData("Punktzahl").Value);

            if (int.TryParse(_IniData.Sections["Game"].GetKeyData("Leg").Value, out _ParseResult))
                OptionGame.LegZumSet   = int.Parse(_IniData.Sections["Game"].GetKeyData("Leg").Value );

            if (int.TryParse(_IniData.Sections["Game"].GetKeyData("Set").Value, out _ParseResult))
                OptionGame.SetZumSieg  = int.Parse(_IniData.Sections["Game"].GetKeyData("Set").Value );
      
        }

        private void readStatistik()
        {

            if (_IniData.Sections["Statistik"] == null) return;
            if (_IniData.Sections["Statistik"].GetKeyData("ListSizeHighfinish") == null) return;
            if (_IniData.Sections["Statistik"].GetKeyData("ListSizeHighscore") == null) return;

            if (int.TryParse(_IniData.Sections["Statistik"].GetKeyData("ListSizeHighfinish").Value, out _ParseResult))
                OptionStatistik.HighfinishListSize = int.Parse(_IniData.Sections["Statistik"].GetKeyData("ListSizeHighfinish").Value);

            if (int.TryParse(_IniData.Sections["Statistik"].GetKeyData("ListSizeHighscore").Value, out _ParseResult))
                OptionStatistik.HighscoreListSize = int.Parse(_IniData.Sections["Statistik"].GetKeyData("ListSizeHighscore").Value);

        }


        public void WriteIni()
        {
            _IniData = new IniData();
            _IniData.Sections.AddSection("Game");

            _IniData.Sections.GetSectionData("Game").Keys.AddKey("Punktzahl", OptionGame.Punktzahl.ToString());
            _IniData.Sections.GetSectionData("Game").Keys.AddKey("Leg", OptionGame.LegZumSet.ToString());
            _IniData.Sections.GetSectionData("Game").Keys.AddKey("Set", OptionGame.SetZumSieg.ToString());

            _IniData.Sections.AddSection("Statistik");

            _IniData.Sections.GetSectionData("Statistik").Keys.AddKey("ListSizeHighfinish", OptionStatistik.HighfinishListSize.ToString());
            _IniData.Sections.GetSectionData("Statistik").Keys.AddKey("ListSizeHighscore", OptionStatistik.HighscoreListSize.ToString());

            _parser.WriteFile(IniPath, _IniData);
        }

        private bool CheckIni()
        {
            
            
            if (!_IniData.TryGetKey("Punktzahl", out _KeyResult)) return false;
            if (!_IniData.TryGetKey("Punktzahl", out _KeyResult)) return false;
            if (!_IniData.TryGetKey("Punktzahl", out _KeyResult)) return false;

            return true;
        }
        */
    }

}
