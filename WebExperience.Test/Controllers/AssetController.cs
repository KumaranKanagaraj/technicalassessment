using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebExperience.Test.DataModel;
using WebExperience.Test.Services;

namespace WebExperience.Test.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api")]
	public class AssetController : ApiController
	{
		private AssetService _service;
		public AssetController()
		{
			_service = new AssetService();
		}

		[HttpGet, Route("assets")]
		public HttpResponseMessage GetAssets(int page = 1, int limit = 5)
		{
			return Request.CreateResponse(HttpStatusCode.OK, _service.GetAssets(page, limit), Configuration.Formatters.JsonFormatter);
		}

		[HttpGet, Route("{id}/asset")]
		public HttpResponseMessage GetAsset(Guid id)
		{
			return Request.CreateResponse(HttpStatusCode.OK, _service.GetAsset(id), Configuration.Formatters.JsonFormatter);
		}

		[HttpPost, Route("add/asset")]
		public HttpResponseMessage AddAsset(Asset asset)
		{
			_service.AddAsset(asset);
			return Request.CreateResponse(HttpStatusCode.Created, Configuration.Formatters.JsonFormatter);

		}

		[HttpPost, Route("remove/{id}/asset")]
		public HttpResponseMessage DeleteAsset(Guid id)
		{
			_service.DeleteAsset(id);
			return Request.CreateResponse(HttpStatusCode.OK, Configuration.Formatters.JsonFormatter);
		}
	}
}
