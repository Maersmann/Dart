using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Memento
{
    public class MatchCaretaker
    {
        private List<MatchMemento> _ListMatchMemento;
        private int _Pos;

        public MatchCaretaker()
        {
            _ListMatchMemento = new List<MatchMemento>();
            _Pos = -1;
        }

        public void AddMemento(MatchMemento pMemento)
        {
            AlteMementoEntfernen(); 
            _ListMatchMemento.Add(pMemento);
            _Pos++;
        }

        private void AlteMementoEntfernen()
        {
            int ListCount = _ListMatchMemento.Count-1;
            for (int i = ListCount; i > _Pos; i--)
            {
                _ListMatchMemento.RemoveAt(i);
            }
        }

        public Boolean CanRedo()
        {
            return (_ListMatchMemento.Count-1 > _Pos);
        }

        public Boolean canUndo()
        {
            return (_Pos > 0);
        }

        public MatchMemento Undo()
        {
            if (CanRedo() == false && _Pos > 1)
            {
                _Pos -= 1;
            }
            else
            {
                _Pos--;
            }
            MatchMemento returnMemento = _ListMatchMemento[_Pos].getMatchModel().getMemento();

            return returnMemento;
        }

        public  MatchMemento Redo()
        {
            _Pos++;
            return _ListMatchMemento[_Pos];
        }
    }
}
