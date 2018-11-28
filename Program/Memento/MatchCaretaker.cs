using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programm.Memento
{
    public class MatchCaretaker
    {
        private Stack<MatchMemento> _UndoStack;
        private Stack<MatchMemento> _RedoStack;

        public MatchCaretaker()
        {
            _UndoStack = new Stack<MatchMemento>();
            _RedoStack = new Stack<MatchMemento>();
           
        }

        public void AddMemento(MatchMemento pMemento)
        {
            _UndoStack.Push(pMemento);
            _RedoStack.Clear();
        }

        public Boolean CanRedo()
        {
            return (_RedoStack.Count != 0);
        }

        public Boolean canUndo()
        {
            return (_UndoStack.Count >= 1);
        }

        public MatchMemento Undo(MatchMemento pMemento)
        {
            MatchMemento returnMemento = _UndoStack.Pop();
            _RedoStack.Push(pMemento);
            return returnMemento;   
        }

        public  MatchMemento Redo(MatchMemento pMemento)
        {


            MatchMemento returnMemento = _RedoStack.Pop();
            _UndoStack.Push(pMemento);

            return returnMemento;
        }
    }
}
