using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_of_life
{
    public partial class Form1 : Form
    {
        private Cell[] _cells;
        private int _width;
        private int _size;

        public Form1(Cell[] boardCells, int width, int length)
        {
            InitializeComponent();
            this._cells = boardCells;
            this._width = width;
            this._size = length;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void board_MouseDown(object sender, MouseEventArgs e)
        {
            using (Graphics g = this.board.CreateGraphics())
            {
                Brush brush = new SolidBrush(Color.Red);
                int width = this.board.Width / _width;
                int height = this.board.Height / _width;
                g.FillRectangle(brush, e.X, e.Y, width, height);
                brush.Dispose();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        private void board_Paint(object sender, PaintEventArgs e)
        {
            var a = _cells;
            var xSize = this.board.Width/_width;
            var ySize = this.board.Height/ _width;
            var brush = new SolidBrush(Color.Black);
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (_cells[(i*_width)+j].IsAlive)
                    {
                        e.Graphics.FillRectangle(brush, j*xSize,i*ySize, xSize, ySize);
                    }
                }
            }
        }

        private void board_Click(object sender, EventArgs e)
        {

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _cells[(i * _width) + j].Rules();
                }
            }
            for (int i = 0; i < _size; i++)
            {
                _cells[i].updateState();
            }
            Refresh();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = _width;
            _cells[(50 * _width) + 21].IsAlive = true;
            _cells[(50 * _width) + 22].IsAlive = true;
            _cells[(51 * _width) + 21].IsAlive = true;
            _cells[(51 * _width) + 22].IsAlive = true;

            _cells[(51 * _width) + 31].IsAlive = true;
            _cells[(51 * _width) + 32].IsAlive = true;
            _cells[(52 * _width) + 30].IsAlive = true;
            _cells[(52 * _width) + 32].IsAlive = true;
            _cells[(53 * _width) + 30].IsAlive = true;
            _cells[(53 * _width) + 31].IsAlive = true;

            _cells[(53 * _width) + 38].IsAlive = true;
            _cells[(53 * _width) + 39].IsAlive = true;
            _cells[(54 * _width) + 38].IsAlive = true;
            _cells[(54 * _width) + 40].IsAlive = true;
            _cells[(55 * _width) + 38].IsAlive = true;

            _cells[(48 * _width) + 45].IsAlive = true;
            _cells[(48 * _width) + 46].IsAlive = true;
            _cells[(49 * _width) + 44].IsAlive = true;
            _cells[(49 * _width) + 46].IsAlive = true;
            _cells[(50 * _width) + 44].IsAlive = true;
            _cells[(50 * _width) + 45].IsAlive = true;

            _cells[(48 * _width) + 56].IsAlive = true;
            _cells[(48 * _width) + 57].IsAlive = true;
            _cells[(49 * _width) + 56].IsAlive = true;
            _cells[(49 * _width) + 57].IsAlive = true;

            _cells[(55 * _width) + 57].IsAlive = true;
            _cells[(55 * _width) + 58].IsAlive = true;
            _cells[(56 * _width) + 57].IsAlive = true;
            _cells[(56 * _width) + 59].IsAlive = true;
            _cells[(57 * _width) + 57].IsAlive = true;

            _cells[(58 * _width) + 46].IsAlive = true;
            _cells[(58 * _width) + 47].IsAlive = true;
            _cells[(58 * _width) + 48].IsAlive = true;
            _cells[(59 * _width) + 46].IsAlive = true;
            _cells[(60 * _width) + 47].IsAlive = true;
            Refresh();
        }


    }
}