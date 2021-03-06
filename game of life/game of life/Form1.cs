﻿using System;
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
        private bool _redraw;

        public Form1(Cell[] boardCells, int width, int length)
        {
            InitializeComponent();
            this._cells = boardCells;
            this._width = width;
            this._size = length;
            this._redraw = false;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void board_MouseDown(object sender, MouseEventArgs e)
        {
            //using (Graphics g = this.board.CreateGraphics())
            //{
            //    Brush brush = new SolidBrush(Color.Red);
            //    int width = this.board.Width / _width;
            //    int height = this.board.Height / _width;
            //    g.FillRectangle(brush, e.X, e.Y, width, height);
            //    brush.Dispose();
            //}
        }

        protected override CreateParams CreateParams //make double draw buffer
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
            if (_redraw)
            {
                var xSize = this.board.Width / _width;
                var ySize = this.board.Height / _width;
                var brush = new SolidBrush(Color.Black);
                for (int i = 0; i < _width; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        if (_cells[(i * _width) + j].IsAlive)
                        {
                            e.Graphics.FillRectangle(brush, j * xSize, i * ySize, xSize, ySize);
                        }
                    }
                }
                _redraw = false;
            }
        }

        private void board_Click(object sender, EventArgs e)
        {

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //timer1.Interval = 2000;
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
                    if (_cells[(i * _width) + j].Rules())
                    {
                        _redraw = true;
                    }
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
            if(_cells.Length>=10000)
            {
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

                _redraw = true;
                Refresh();
            }
            
        }

        private void board_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                MouseEventArgs m = e as MouseEventArgs;
                var i = (int)m.X / (this.board.Width / _width);
                var j = (int)m.Y / (this.board.Height / _width);
                if ((j * _width + i)< _size && !_cells[j * _width + i].IsAlive)
                {
                    _cells[j * _width + i].IsAlive = true;
                    _redraw = true;
                    Refresh();
                    System.Console.WriteLine((j * _width + i));
                }
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in _cells)
            {
                item.IsAlive = false;
                item.NextLivingState = false;
            }
            _redraw = true;
            Refresh();
        }

        private void tickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1_Tick(this, new EventArgs());
        }

        private void testgliderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cells[10].IsAlive = true;
            _cells[2].IsAlive = true;
            _cells[12].IsAlive = true;
            _cells[22].IsAlive = true;
            _cells[21].IsAlive = true;
            _redraw = true;
            Refresh();
        }
    }
}