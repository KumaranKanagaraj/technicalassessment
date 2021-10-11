using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExperience.Test.Data;
using WebExperience.Test.DataModel;
using WebExperience.Test.Dtos;

namespace WebExperience.Test.Services
{
	public class AssetService
	{
		private AssetRepository _access;
		public AssetService()
		{
			_access = new AssetRepository();
		}

		public IEnumerable<AssetOverviewDto> GetAssets(int page, int limit) => _access.GetAssets(page, limit, AssetOverviewDto.Selector);
		public AssetDetailDto GetAsset(Guid id) => _access.GetAsset(id, AssetDetailDto.Selector);
		public void AddAsset(Asset asset) => _access.AddAsset(asset);
		public void DeleteAsset(Guid id) => _access.DeleteAsset(id);
	}
}