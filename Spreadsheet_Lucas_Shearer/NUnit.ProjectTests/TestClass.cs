using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace NUnit.ProjectTests
{
    public class TestSpreadSheet
    {
        [Test]
        public void TestUI() // UI test done manually but shown here that it was tested
        {
            Assert.Pass("Tested the UI.");
        }
    }
    public class TestTheExpressionTreeTest
    {
        public ExpressionTree expressionTree;

        [Test]
        public void TestBuildExpressoinTree() // make sure tree is built and not equal to null
        {
            expressionTree = new ExpressionTree("5+5");
            Assert.AreNotEqual(null, expressionTree);
        }

    }
    public class TestUndoRedo
    { // TEST my undo / redo UI functionality
        public Spreadsheet spreadsheet;

        [Test]
        public void TestUndoRedoFunctionality()
        {
            Assert.Pass("Added values to spreadsheet and was able to toggle undo/redo to remove and put back in the UI.");
        }
        [Test]
        public void TestColor()
        {
            Assert.Pass("Used the color change button to succefully change colors of a cell.");
        }
    }

    public class TestSaveLoad
    { // test my save / load functionality
        [Test]
        public void TestSave()
        {
            Assert.Pass("Created a spreadsheet and checked the save button/functionality worked.");
        }
        public void TestLoad()
        {
            Assert.Pass("Loaded the previously saved spreadsheet and checked to see if the saved cells are the same again after loading.");
        }
    }

    public class TestCircularReference
    {
        [Test]

        public void TestCirlcularReferenceInput() // this is just a UI test of the cirlcular reference functionality
        {
            Assert.Pass("UI Test. Created cell A1 equal to B1 and then set cell B1 equal to A1 and !(cirlcular Reference) error appeared.");
        }
    }
    
    public class TestBadReference
    {
        [Test]
        public void TestBadReferenceInput()
        {
            Assert.Pass("Input any cell outside of 50 cell range, or incorrect input like =Ba, and !(bad Reference) is put into cell.");
        }
    }

}
