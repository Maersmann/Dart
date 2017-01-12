using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dart.Match.Matchobjekte
{
    public class HighScore
    {
        public int[] FinishScore { get; set; }
        public int[] Scores { get; set; }
        public int[] AnzahlFinish { get; set; }
        public int[] AnzahlScore { get; set; }

        public HighScore()
        {
            FinishScore = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Scores = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            AnzahlFinish = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            AnzahlScore = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
    }
}
