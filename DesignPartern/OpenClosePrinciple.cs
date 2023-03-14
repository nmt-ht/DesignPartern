namespace DesignPartern.SOLID
{
    /// <summary>
    /// OCP
    /// Nguyên tắc đóng mở nói rằng các lớp phải được mở để mở rộng, có nghĩa là
    /// có thể mở rộng bộ lọc cho sản phẩm, có thể tạo các bộ lọc mới, nhưng chúng phải được đóng lại để sửa đổi
    /// có nghĩa là không ai được quay lại bộ lọc và thực hiện chỉnh sửa mã, mã đã có ở đó, và chúng ta giả định rằng bộ lọc đã được
    /// vận chuyển cho một khách hàng.
    /// Bây giờ, làm thế nào chúng ta có thể mở rộng mọi thứ mà không thực hiện trở lại và thay đổi cơ thể chúng?
    /// Answer: Kế thừa, interface
    /// </summary>
    public class OpenClosePrinciple
    {
        public enum Color
        {
            Red, Green, Blue
        }
        public enum Size
        {
            Small, Medium, Large, Yuge
        }
        public class Product
        {
            public string Name;
            public Color Color;
            public Size Size;
            public Product(string name, Color color, Size size)
            {
                Name = name;
                Color = color;
                Size = size;
            }
        }

        public class ProductFiler
        {
            public IEnumerable<Product> FillerBySize(IEnumerable<Product> products, Size size)
            {
                foreach (Product product in products)
                {
                    if (product.Size == size)
                        yield return product;
                }
            }
            public IEnumerable<Product> FillerByColor(IEnumerable<Product> products, Color color)
            {
                foreach (Product product in products)
                {
                    if (product.Color == color)
                        yield return product;
                }
            }
        }

        public interface ISpecification<T>
        {
            bool IsSatisfied(T t);
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
        }

        public class ColorSpecification : ISpecification<Product>
        {
            private Color color;
            public ColorSpecification(Color color)
            {
                this.color = color;
            }
            public bool IsSatisfied(Product t)
            {
                return t.Color == color;
            }
        }

        public class SizeSpecification : ISpecification<Product>
        {
            private Size size;
            public SizeSpecification(Size size)
            {
                this.size = size;
            }
            public bool IsSatisfied(Product t)
            {
                return t.Size == size;
            }
        }

        public class AndSpecification<T> : ISpecification<T>
        {
            private ISpecification<T> first, second;
            public AndSpecification(ISpecification<T> first, ISpecification<T> second)
            {
                this.first = first;
                this.second = second;
            }

            public bool IsSatisfied(T t)
            {
                return first.IsSatisfied(t) && second.IsSatisfied(t);
            }
        }

        public class BetterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
            {
                foreach (var i in items)
                {
                    if (spec.IsSatisfied(i)) yield return i;
                }
            }
        }
    }
}
