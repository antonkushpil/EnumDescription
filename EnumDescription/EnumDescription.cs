using System;

namespace EnumDescription
{
	public class EnumDescription : Attribute
	{
		public string Description { get; }
		public EnumDescription(string description)
		{
			Description = description;
		}
	}
}
