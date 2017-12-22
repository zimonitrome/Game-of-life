using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_of_life
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Cell[] cells = new Cell[150*150];
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell();
            }

            int width = (int)Math.Sqrt(cells.Length);
            for (int i = 0; i < cells.Length; i++)
            {
                Cell top = (i - width) >= 0 ? cells[i - width] : null;
                Cell right = (i + 1) < cells.Length ? cells[i + 1] : null;
                Cell bottom = (i + width) < cells.Length ? cells[i + width] : null;
                Cell left = (i - 1) >= 0 ? cells[i - 1] : null;

                Cell topRight = (top!=null && right!=null) ? cells[i - width+1]  : null;
                Cell bottomRight = (bottom != null && right != null && (i + width + 1)<cells.Length) ? cells[i + width + 1] : null;
                Cell bottomLeft = (bottom != null && left != null) ? cells[i + width - 1] : null;
                Cell topLeft = (top != null && left != null && (i - width - 1)>=0 ) ? cells[i - width - 1] : null;

                cells[i].SetConnections(ref top, ref right, ref bottom, ref left, ref topRight, ref bottomRight, ref bottomLeft, ref topLeft);
            }
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var Form1 = new Form1(cells, width, cells.Length);
            Application.Run(Form1);
        } 
    }
}
