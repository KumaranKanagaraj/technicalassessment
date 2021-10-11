using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebExperience.Test.DataModel;

namespace WebExperience.Test.Data
{
	public class AssetRepository
	{
		private AssetContext _context;
		private const int MAX_LIMIT = 10;
		public AssetRepository()
		{
			_context = new AssetContext();
		}

		public IEnumerable<TResult> GetAssets<TResult>(int page, int limit, Expression<Func<Asset, TResult>> selector)
		{
			var pageSize = limit > MAX_LIMIT ? MAX_LIMIT : limit;
			var skip = page > 0 ? (page - 1) * pageSize : 0;
			return _context.Assets.OrderByDescending(x=>x.CreatedOn).ThenBy(x=>x.FileName).Skip(skip).Take(pageSize).Select(selector);
		}

		public void AddAsset(Asset asset)
		{
			_context.Assets.Add(asset);
			_context.SaveChanges();
		}

		public TResult GetAsset<TResult>(Guid id, Expression<Func<Asset, TResult>> selector) => _context.Assets.Where(x => x.Id == id).Select(selector).SingleOrDefault();

		public void DeleteAsset(Guid id)
		{
			_context.Assets.Remove(_context.Assets.Where(x => x.Id == id).SingleOrDefault());
			_context.SaveChanges();
		}
	}
}