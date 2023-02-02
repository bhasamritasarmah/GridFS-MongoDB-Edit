using GridFSMongoDBEdit.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.GridFS;

namespace GridFSMongoDBEdit.Controllers
{
	public class GridFSController : Controller
	{
		private readonly PicturesInfoServices _picturesInfoServices;
		IGridFSBucket bucket;
		Object Id;
		byte[] source;

		public GridFSController(PicturesInfoServices picturesInfoServices) 
		{
			_picturesInfoServices = picturesInfoServices;
		}
		public IActionResult Index()
		{
			var bytes = bucket.DownloadAsBytes((MongoDB.Bson.ObjectId)Id);
			return View(_picturesInfoServices.GetAsync());
		}

		public IActionResult Privacy()
		{
			var id = bucket.UploadFromBytes("picture1.jpg", source);
			return View(id);
		}
	}
}
