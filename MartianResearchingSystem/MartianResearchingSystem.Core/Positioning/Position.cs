namespace MartianResearchingSystem.Core.Positioning
{
	/// <summary>
	/// Определяет позицию объекта или точку на поверхности.
	/// </summary>
	public struct Position
	{
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
