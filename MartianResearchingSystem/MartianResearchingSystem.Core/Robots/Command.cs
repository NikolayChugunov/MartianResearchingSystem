namespace MartianResearchingSystem.Core.Robots
{
	/// <summary>
	/// Возможные команды робота.
	/// </summary>
	public enum Command
	{
		/// <summary>
		/// Двигаться вперед.
		/// </summary>
		MoveForward = 1,

		/// <summary>
		/// Поворот на 90 градусов влемо.
		/// </summary>
		TurnLeft = 2,

		/// <summary>
		/// Поворот на 90 градусов вправо.
		/// </summary>
		TurnRight = 3
	}
}
