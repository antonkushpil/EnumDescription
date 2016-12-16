using System;

namespace EnumDescription
{
	public static class EnumExtension
	{
		public static T ParseEnum<T>(this string property)
		{
			var enumType = typeof(T);
			if(!enumType.IsEnum) throw new ArgumentException("T must be an enumerated type");

			foreach(var field in enumType.GetFields())
			{
				object[] attributes = field.GetCustomAttributes(false);
				foreach(var attribute in attributes)
				{
					EnumDescription description = attribute as EnumDescription;
					if(description != null)
					{
						if(description.Description == property)
						{
							return (T)field.GetValue(typeof(T));
						}
					}
				}
			}
			throw new Exception($"Couldn't parse \"{property}\" parameter to \"{typeof(T)}\" Enum");
		}
	}
}
