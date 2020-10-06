/*Lucas Shearer
10956939
321
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public interface IUndoRedoCommand
    {
        //this is for our interface of our undo/redo
        IUndoRedoCommand Execute(Spreadsheet spreadsheet);
    }

    public class UndoRedo
    {//we make a stack for undo and stack for redo to be able to manipulate current spreadsheet with undo/redo
        
        private Stack<UndoRedoCollection> undoStack = new Stack<UndoRedoCollection>();
        private Stack<UndoRedoCollection> redoStack = new Stack<UndoRedoCollection>();

        public bool CanRedo
        {//check if we CAN redo something
            get { return redoStack.Count != 0; }
        }

        public bool CanUndo
        {//check if we CAN undo something
            get { return undoStack.Count != 0; }
        }

        public void AddUndo(UndoRedoCollection undos)
        {
            //add undo's and clear
            undoStack.Push(undos);
            redoStack.Clear();
        }


        public string CheckUndo
        {//check undo availability
            get
            {
                if (CanUndo)
                {
                    return undoStack.Peek().title;
                }
                return string.Empty;
            }
        }

        public string CheckRedo
        {//check redo availabliity
            get
            {
                if (CanRedo)
                {
                    return redoStack.Peek().title;
                }
                return string.Empty;
            }
        }

        public void ClearStacks()
        {//clear our redo/undo memory
            redoStack.Clear();
            undoStack.Clear();
        }

        public void Undo(Spreadsheet sheet)
        {//this is what undo does
            UndoRedoCollection commands = undoStack.Pop();
            redoStack.Push(commands.Restore(sheet));
        }

        public void Redo(Spreadsheet sheet)
        {//this is what redo does
            UndoRedoCollection commands = redoStack.Pop();
            undoStack.Push(commands.Restore(sheet));
        }

    }

    public class UndoRedoCollection
    {
        //array of undo redo calls
        private IUndoRedoCommand[] commandObjects;
        public string title;

        public UndoRedoCollection()
        { }

        public UndoRedoCollection(IUndoRedoCommand[] commands, string title)
        {//undoredo collectoin commands for array
            commandObjects = commands;
            this.title = title;
        }

        public UndoRedoCollection(List<IUndoRedoCommand> commands, string title)
        {//undo redo collections for list
            commandObjects = commands.ToArray();
            this.title = title;
        }

        public UndoRedoCollection Restore(Spreadsheet spreadsheet)
        {
            //a list for commands
            List<IUndoRedoCommand> commandList = new List<IUndoRedoCommand>();
            //for each command in the commandObjects array, Call each command
            foreach (IUndoRedoCommand command in commandObjects)
            {
                commandList.Add(command.Execute(spreadsheet));
            }
            return new UndoRedoCollection(commandList.ToArray(), this.title);
        }

    }
}
