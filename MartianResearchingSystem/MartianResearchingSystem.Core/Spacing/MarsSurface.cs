using System.Collections.Generic;

using MartianResearchingSystem.Utils;

namespace MartianResearchingSystem.Core.Spacing
{
	/// <summary>
	/// Представляет собой поверхность Марса.
	/// </summary>
	public class MarsSurface
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="MarsSurface"/>.
		/// </summary>
		/// <param name="length">Длина поверхности.</param>
		/// <param name="width">Ширина поверхности.</param>
		public MarsSurface(int length, int width)
		{
			Length = Guard.ArgumentGreaterThanZero(length, nameof(length));
			Width = Guard.ArgumentGreaterThanZero(width, nameof(width));

			_scendedPositions = new List<Position>();
		}

		/// <summary>
		/// Длина поверхности Марса.
		/// </summary>
		public int Length { get; }

		/// <summary>
		/// Ширина поверхности Марса.
		/// </summary>
		public int Width { get; }

		/// <summary>
		/// Позиции на поверхности, в которых остался "запах" робота.
		/// </summary>
		private List<Position> _scendedPositions;

		/// <summary>
		/// Добавляет на поверхность позицию с "запахом" робота.
		/// </summary>
		/// <param name="scentedPosition">Данные позиции.</param>
		public void AddScentedPosition(Position scentedPosition)
		{
			_scendedPositions.Add(scentedPosition);
		}

		/// <summary>
		/// Определяет, содержит ли указанная позиция "запах" робота.
		/// </summary>
		/// <param name="position">Проверяемая позиция.</param>
		/// <returns>true - если позиция содержит запах робота, false - в противном случае.</returns>
		public bool IsPositionScented(Position position)
		{
			var isPositionScented = _scendedPositions.Contains(position);

			return isPositionScented;
		}
	}
}
