using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
	public class TaskItem
	{
		public int Id { get; set; }

		public User Assignee { get; set; }
		public Guid? AssigneeId { get; set; }

		[Required, StringLength(200, MinimumLength = 1)]
		public string Name { get; set; }



		internal TaskItem() { }

		public TaskItem(string name) => Name = name;
	}
}
