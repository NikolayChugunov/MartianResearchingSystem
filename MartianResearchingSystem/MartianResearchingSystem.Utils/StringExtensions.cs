
namespace MartianResearchingSystem.Utils
{
	/// <summary>
	/// Содержит методы расширени для работы со строками.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Определяет, является ли строка эквивалентной null, пустой или состоящей только из пробелов.
		/// </summary>
		/// <param name="arg">Анализируемая строка</param>
		/// <returns>true, если строка равна null, пустая или состоит только из пробелов, в противном случае - false.</returns>
		public static bool IsNullOrWhiteSpace(this string arg)
		{
			return string.IsNullOrWhiteSpace(arg);
		}
	}
}
