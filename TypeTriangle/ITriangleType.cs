namespace TypeTriangle
{
    public interface ITriangleType
    {
        /// <summary>
        /// Определяет тип треугольника (остроугольный, прямоугольный, тупоугольный) по длинам его сторон.
        /// </summary>
        /// <param name="args">Массив, содержащий три стороны треугольника.</param>
        /// <returns>Тип треугольника (остроугольный, прямоугольный, тупоугольный).</returns>
        int DetermineTriangleType(double[] args);
    }
}