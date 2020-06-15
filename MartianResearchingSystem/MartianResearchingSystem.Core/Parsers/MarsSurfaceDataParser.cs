using System;
using System.Linq;

using MartianResearchingSystem.Core.Spacing;
using MartianResearchingSystem.Utils;

namespace MartianResearchingSystem.Core.Parsers
{
	/// <summary>
	/// Пармер данных для поверхности Марса.
	/// </summary>
	public class MarsSurfaceDataParser
	{
		/// <summary>
		/// Выполняет парсинг строки в поверхность Марса с заданными в строке размерами.
		/// </summary>
		/// <param name="data">Данные для парсинга.</param>
		/// <returns>Поверхность марса <see cref="MarsSurface"/> с указанными размерами.</returns>
		public MarsSurface ParseMarsSurface(string data)
		{
			data = Guard.ArgumentIsNotNullOrWhiteSpace(data, nameof(data));

            var sizes = data
                .ToUpperInvariant()
                .Where(char.IsDigit)
                .Select(_ => _.ToString())
                .ToArray();

            if (sizes.Length != 2)
            {
                throw new InvalidOperationException("Mars surface sizes must be represent as two digits");
            }

			var xDimensionSize = Convert.ToInt32(sizes[0]);
			var yDimensionSize = Convert.ToInt32(sizes[1]);

			var surface = new MarsSurface(xDimensionSize, yDimensionSize);

			return surface;
		}
	}
}
