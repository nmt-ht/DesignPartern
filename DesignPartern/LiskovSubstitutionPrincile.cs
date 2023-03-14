namespace DesignPartern.SOLID
{
    /// <summary>
    /// LSP
    /// Danh sách các nguyên tắc thay thế được đặt tên của Barbara Lescott
    /// </summary>
    public class LiskovSubstitutionPrincile
    {
        public class Rectangle
        {
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }
            public Rectangle()
            {

            }

            public Rectangle(int width, int height)
            {
                this.Width = width;
                this.Height = height;
            }

            public override string ToString()
            {
                return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
            }
        }

        public class Square : Rectangle 
        {
            public override int Width { set { base.Width = base.Height = value; } }
            public override int Height { set { base.Width = base.Height = value; } }
        }

        public static int Area(Rectangle rc) => rc.Width * rc.Height;
    }
}
