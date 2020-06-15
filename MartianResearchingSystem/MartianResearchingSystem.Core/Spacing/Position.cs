namespace MartianResearchingSystem.Core.Spacing
{
	/// <summary>
	/// Определяет позицию объекта или точку на поверхности.
	/// </summary>
	public struct Position
	{
        /// <summary>
        /// Инициализирует новый экземпляр структуры <see cref="Position"/>.
        /// </summary>
        /// <param name="x">Начальная координата точки по оси OX.</param>
        /// <param name="y">Начальная координата точки по оси OY.</param>
		public Position(int x, int y)
		{
			XCoord = x;
			YCoord = y;
		}

		/// <summary>
		/// Координата по оси OX.
		/// </summary>
		public int XCoord { get; set; }

		/// <summary>
		/// Координата по оси OY.
		/// </summary>
		public int YCoord { get; set;  }

		public override string ToString()
		{
			return $"X: {XCoord}, Y: {YCoord}";
		}
	}
}
