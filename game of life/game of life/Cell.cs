using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace game_of_life
{
    public enum Oretation { Top = 1,Right,Bottom,Left,TopRight,BottomRight,BottomLeft,TopLeft}

    public class Cell
    {
        private bool _isAlive;
        private bool _nextLivingState;

        private Dictionary<Oretation, Cell> _neighboor;
        

        public bool IsAlive { get => _isAlive; set => _isAlive = value; }

        public Cell(bool isAlive = false)
        {
            _isAlive = isAlive;
            _nextLivingState = false;
            _neighboor = new Dictionary<Oretation, Cell>();
        }

        public void SetConnections(ref Cell top,ref Cell right, ref Cell bottom, ref Cell left)
        {

        }

        public bool Rules()
        {
            int aliveNeighboors = 0;
            foreach (var item in _neighboor)
            {
                if (item.Value != null && item.Value.IsAlive)
                    aliveNeighboors++;
            }
            if (IsAlive && !(aliveNeighboors == 2 || aliveNeighboors == 3))
            {
                _nextLivingState = false;
            }
            else if(aliveNeighboors == 3)
            {
                _nextLivingState = true;
            }
            return _nextLivingState;
        }
        public bool updateState()
        {
            return this._isAlive = this._nextLivingState;
        }

        internal void SetConnections(ref Cell top, ref Cell right, ref Cell bottom, ref Cell left, ref Cell topRight, ref Cell bottomRight, ref Cell bottomLeft, ref Cell topLeft)
        {
            _neighboor.Add(Oretation.Top, top);
            _neighboor.Add(Oretation.Right, right);
            _neighboor.Add(Oretation.Bottom, bottom);
            _neighboor.Add(Oretation.Left, left);
            _neighboor.Add(Oretation.TopRight, topRight);
            _neighboor.Add(Oretation.BottomRight, bottomRight);
            _neighboor.Add(Oretation.BottomLeft, bottomLeft);
            _neighboor.Add(Oretation.TopLeft, topLeft);
        }
    }
}
