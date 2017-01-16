
using System;
using System.Collections.Generic;

namespace Dart.SpielerObjekte
{
    public class Spieler
    {
        private String Name;

        public Spieler(String pName)
        {
            Name = pName;
        }

        public String GetName()
        {
            return Name;
        }

        public Spieler getSpielerMemento()
        {
            Spieler memento = new Spieler(Name);
            return memento;
        }
    }
}
