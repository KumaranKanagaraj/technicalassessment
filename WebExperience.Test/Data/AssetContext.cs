using System.Data.Entity;
using WebExperience.Test.DataModel;

namespace WebExperience.Test.Data
{
	//Enable-Migrations -ContextTypeName WebExperience.Test.Data.AssetContext
	//add-migration InitialCreate
	//update-database
	public class AssetContext : DbContext
	{
		public AssetContext() : base("DefaultConnection")
		{

		}
		public virtual DbSet<Asset> Assets { get; set; }
	}
}