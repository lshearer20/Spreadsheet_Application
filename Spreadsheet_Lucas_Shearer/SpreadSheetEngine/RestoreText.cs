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
    public class RestoreText : IUndoRedoCommand
    {
        //This class will be for resotring the text for the undo//redo functionality
        private Cell cell;
        private string text;

        public RestoreText(Cell c, string t)
        {
            cell = c;
            text = t;
        }


        public IUndoRedoCommand Execute(Spreadsheet spreadsheet)
        {
            //get the name so we can the cell, then get the text of the cell and updated text
            string cellName = this.cell.ColumnIndex.ToString() + this.cell.RowIndex.ToString();
            Cell cell = spreadsheet.GetCell(cellName);
            string currentText = cell.Text;
            cell.Text = this.text;
            return new RestoreText(cell, currentText);
        }
    }
}
