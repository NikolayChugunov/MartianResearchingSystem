using System;
using System.ComponentModel;
using System.Reflection;

namespace MartianResearchingSystem.Utils
{
	/// <summary>
	/// Содержит методы расширения для работы с перечислениями.
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Осуществляет получение значения атрибута [Description], имеющегося у элемента перечисления.
		/// </summary>
		/// <param name="val">Элемент перечисления, описание которого требуется получить.</param>
		/// <returns>Значение атрибута [Description] элемента перечисления если указано, в противном случае - пустую строку.</returns>
		public static string GetDescription(this Enum val)
		{
			var fieldInfo = val
				.GetType()
				.GetField(val.ToString());

            if (fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute), false) is DescriptionAttribute descriptionAttribute)
            {
                return descriptionAttribute.Description;
            }

            return string.Empty;
		}
	}
}
