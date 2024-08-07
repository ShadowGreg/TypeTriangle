using TypeTriangle;

namespace TypeTriangleTest
{
    public class TriangleTypeTests
    {
        private readonly ITriangleType _triangleType = new TriangleType();

        [Theory]
        [InlineData(new double[] { 3.0, 4.0, 5.0 }, TriangleKind.Right)]
        [InlineData(new double[] { 7.0, 24.0, 25.0 }, TriangleKind.Right)]
        [InlineData(new double[] { 5.0, 5.0, 5.0 }, TriangleKind.Acute)]
        [InlineData(new double[] { 3.0, 4.0, 6.0 }, TriangleKind.Obtuse)]
        [InlineData(new double[] { 5.0, 12.0, 13.0 }, TriangleKind.Right)]
        public void DetermineTriangleType_ValidTriangles_ReturnsCorrectType(double[] sides,
            TriangleKind expected)
        {
            var result = _triangleType.DetermineTriangleType(sides);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new double[] { 1.0, 2.0, 3.0 })] // Не треугольник
        [InlineData(new double[] { 0.0, 1.0, 1.0 })] // Одна из сторон равна нулю
        [InlineData(new double[] { -1.0, 1.0, 1.0 })] // Одна из сторон отрицательная
        [InlineData(new double[] { 1.0, 1.0, 2.0 })] // Неравенство треугольника
        [InlineData(new double[] { 1.0, 1.0, 1.0, 1.0 })] // Больше трех сторон
        public void DetermineTriangleType_InvalidTriangles_ThrowsArgumentException(double[] sides)
        {
            Assert.Throws<ArgumentException>(() => _triangleType.DetermineTriangleType(sides));
        }

        [Fact]
        public void DetermineTriangleType_LessThanThreeSides_ThrowsArgumentException()
        {
            var sides = new double[] { 1.0, 1.0 }; // Меньше трех сторон
            Assert.Throws<ArgumentException>(() => _triangleType.DetermineTriangleType(sides));
        }

        [Fact]
        public void DetermineTriangleType_ZeroSides_ThrowsArgumentException()
        {
            var sides = new double[] { 0.0, 0.0, 0.0 }; // Все стороны равны нулю
            Assert.Throws<ArgumentException>(() => _triangleType.DetermineTriangleType(sides));
        }

        [Fact]
        public void DetermineTriangleType_NegativeSides_ThrowsArgumentException()
        {
            var sides = new double[] { -1.0, -1.0, -1.0 }; // Все стороны отрицательные
            Assert.Throws<ArgumentException>(() => _triangleType.DetermineTriangleType(sides));
        }
    }
}