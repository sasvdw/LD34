namespace Common.Wrappers
{
    public class Point {
        protected System.Drawing.Point point;

        public int X
        {
            get
            {
                return this.point.X;
            }
        }

        public int Y
        {
            get
            {
                return this.point.Y;
            }
        }

        public Point(int x, int y)
        {
            this.point = new System.Drawing.Point(x, y);
        }
    }
}