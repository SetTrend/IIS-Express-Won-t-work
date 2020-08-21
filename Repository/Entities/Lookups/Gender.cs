using System.ComponentModel.DataAnnotations;

namespace Repository.Entities.Lookups
{
	public class Gender
	{
		public byte Id { get; set; }

		[Required, StringLength(10, MinimumLength = 1)]
		public string Name { get; set; }

		[Required, StringLength(20, MinimumLength = 1)]
		public string Anrede { get; set; }



		internal Gender() { }

		public Gender(byte id, string name, string anrede)
		{
			Id = id;
			Name = name;
			Anrede = anrede;
		}
	}
}