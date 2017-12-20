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
            this._cells = boardCells;
            this._width = width;
            this._size = length;
            InitializeComponent();
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
                        e.Graphics.FillRectangle(brush, i*xSize,j*ySize, xSize, ySize);
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
            Refresh();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _cells[32].IsAlive = true;
            _cells[21].IsAlive = true;
            _cells[22].IsAlive = true;
            _cells[33].IsAlive = true;

            Refresh();
        }


    }
}