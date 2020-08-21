using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Repository.Entities.Lookups;

namespace Repository.Entities
{
	public class User
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[Required]
		public Gender Gender { get; set; }

		[Required, StringLength(30, MinimumLength = 1)]
		public string FirstName { get; set; }

		[Required, StringLength(30, MinimumLength = 1)]
		public string FamilyName { get; set; }

		public string FullName => $"{FirstName} {FamilyName}";

		public virtual ICollection<TaskItem> Tasks { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime CreatedAt { get; set; }



		internal User() { }

		public User(Gender gender, string firstName, string familyName)
		{
			Gender = gender;
			FirstName = firstName;
			FamilyName = familyName;
		}
	}
}
