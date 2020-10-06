/*
Lucas Shearer
10956939
CPTS 321
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.ComponentModel;

namespace CptS321
{
    public abstract class Cell : INotifyPropertyChanged
    {
        //class for cell's in our spreadsheet
        public Cell(int row, char col)
        {
            rowIndex = row;
            columnIndex = col;
        }

        private readonly int rowIndex;
        public int RowIndex
        {//row index
            get { return rowIndex; }
        }

        private readonly char columnIndex;
        public char ColumnIndex
        {//col index
            get { return columnIndex; }
        }

        protected string value;
        public string Value
        {//value
            get { return value; }
        }

        // all cells default is white which is this number
        private uint bgcolor = 4294967295;
        public uint BGColor
        {//manage bg color
            get { return bgcolor; }
            set
            {
                if (value != bgcolor)
                {
                    bgcolor = value;

                    OnPropertyChanged("BGColor");
                }
            }
        }

        protected string text = string.Empty;
        public string Text
        {//manage text in cells by checking text and changeing text value
            get { return text; }
            set
            {
                if (text == value)
                { return; }
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public void Clear()
        {//clear cell
            Text = string.Empty;
            BGColor = 4294967295;
        }

        public string GetCellName()
        {//get cell name
            string cellname = ColumnIndex.ToString() + RowIndex.ToString();

            return cellname;
        }


        #region INotifyPropertyChanged Members
        //notify chnage on property changed event handler
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }


}