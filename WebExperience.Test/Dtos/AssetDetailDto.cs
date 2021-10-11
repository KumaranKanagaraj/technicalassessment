using System;
using System.Linq.Expressions;
using WebExperience.Test.DataModel;

namespace WebExperience.Test.Dtos
{
	public class AssetDetailDto
	{
		public Guid Id { get; set; }
		public string FileName { get; set; }
		public string MimeType { get; set; }
		public string CreatedBy { get; set; }
		public string Email { get; set; }
		public string Country { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }

		public static Expression<Func<Asset, AssetDetailDto>> Selector
		{
			get
			{
				return entity => new AssetDetailDto()
				{
					Id = entity.Id,
					FileName = entity.FileName,
					MimeType = entity.MimeType,
					CreatedBy = entity.CreatedBy,
					Email = entity.Email,
					Country = entity.Country,
					Description = entity.Description,
					CreatedOn = entity.CreatedOn
				};
			}
		}
	}
}