using System.ComponentModel;

namespace MartianResearchingSystem.Core.Positioning
{
	/// <summary>
	/// Ориентации в пространстве.
	/// </summary>
	public enum SpaceOrientation
	{
		/// <summary>
		/// Север.
		/// </summary>
		[Description("N")]
		North = 1,

		/// <summary>
		/// Юг.
		/// </summary>
		[Description("E")]
		East = 2,

		/// <summary>
		/// Восток.
		/// </summary>
		[Description("S")]
		South = 3,

		/// <summary>
		/// Запад.
		/// </summary>
		[Description("W")]
		West = 4
	}
}
