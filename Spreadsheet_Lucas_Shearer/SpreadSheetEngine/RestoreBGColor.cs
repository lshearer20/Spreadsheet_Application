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
    public class RestoreBGColor : IUndoRedoCommand
    {
        //this class if for restoring our background colors of our cells for our undo/redo implementation
        private Cell cell;
        private uint color;

        public RestoreBGColor(Cell updateCell, uint updateColor)
        {
            cell = updateCell;
            color = updateColor;
        }

        //revert back to old color cell had
        public IUndoRedoCommand Execute(Spreadsheet sheet)
        {
            //save the previous color and get the cell name and change the cell color
            string cellName = this.cell.ColumnIndex.ToString() + this.cell.RowIndex.ToString();
            uint currentColor = cell.BGColor;
            cell.BGColor = color;
            return new RestoreBGColor(cell, currentColor);

        }

    }
}
