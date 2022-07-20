namespace Script
{
    public class MapSize
    {
        public MapSize(int _x, int _y, int _stx, int _sty, int _finx, int _finy)
        {
            this.X = _x;
            this.Y = _y;
            this.StartX = _stx;
            this.StartY = _sty;
            this.FinX = _finx;
            this.FinY = _finy;
        }
    
        public int X { get; set; }

        public int Y { get; set; }

        public int StartX { get; set; }

        public int StartY { get; set; }
        
        public int FinX { get; set; }
        
        public int FinY { get; set; }
    }
}
