using System;
using System.Linq.Expressions;
using WebExperience.Test.DataModel;

namespace WebExperience.Test.Dtos
{
	public class AssetOverviewDto
	{
		public Guid Id { get; set; }
		public string FileName { get; set; }
		public DateTime CreatedOn { get; set; }

        public static Expression<Func<Asset, AssetOverviewDto>> Selector
        {
            get
            {
                return entity => new AssetOverviewDto()
                {
                    Id = entity.Id,
                    FileName = entity.FileName,
                    CreatedOn = entity.CreatedOn
                };
            }
        }
    }


}