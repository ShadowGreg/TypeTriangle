namespace TypeTriangle
{
    public struct TriangleType : ITriangleType
    {
        /// <summary>
        /// Определяет тип треугольника (остроугольный, прямоугольный, тупоугольный) по длинам его сторон.
        /// </summary>
        /// <param name="args">Массив, содержащий три стороны треугольника.</param>
        /// <returns>Тип треугольника (остроугольный, прямоугольный, тупоугольный).  
        ///1, Остроугольный TriangleKind.Acute
        ///2, // Прямоугольный TriangleKind.Right
        ///3, // Тупоугольный TriangleKind.Obtuse
        ///</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если массив не содержит ровно три стороны или стороны не образуют треугольник.</exception>
        public int DetermineTriangleType(double[] args)
        {
            if (args.Length != 3)
            {
                throw new ArgumentException("Треугольник должен иметь ровно 3 стороны.");
            }

            double a = args[0];
            double b = args[1];
            double c = args[2];

            // Сначала проверяем, могут ли такие стороны образовать треугольник
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Заданные длины сторон не образуют треугольник.");
            }

            // Определяем максимальную сторону и присваиваем остальные стороны
            double max = a;
            double side1 = b, side2 = c;
            if (b > max)
            {
                max = b;
                side1 = a;
                side2 = c;
            }

            if (c > max)
            {
                max = c;
                side1 = a;
                side2 = b;
            }

            // Используем теорему Пифагора для определения типа углов
            double side1Squared = side1 * side1;
            double side2Squared = side2 * side2;
            double maxSquared = max * max;

            // Определяем разницу между суммой квадратов меньших сторон и квадратом наибольшей стороны
            double difference = side1Squared + side2Squared - maxSquared;

            // Используем switch для определения типа треугольника
            return difference switch
            {
                > 0 => 1, // Остроугольный TriangleKind.Acute
                0 => 2, // Прямоугольный TriangleKind.Right
                < 0 => 3, // Тупоугольный TriangleKind.Obtuse
            };
        }
    }
}