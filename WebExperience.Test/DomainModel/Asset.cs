using System;

namespace WebExperience.Test.DataModel
{
	public class Asset
	{
		public Guid Id { get; set; }
		public string FileName { get; set; }
		public string MimeType { get; set; }
		public string CreatedBy { get; set; }
		public string Email { get; set; }
		public string Country { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}