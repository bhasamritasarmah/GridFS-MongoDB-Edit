using GridFSMongoDBEdit.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace GridFSMongoDBEdit.Services
{
	public class PicturesInfoServices
	{
		private readonly IMongoCollection<PicturesInfo> _picturesInfoCollection;
		IGridFSBucket bucket;

		public PicturesInfoServices(IOptions<DatabaseSettings> settings) 
		{
			var mongoClient = new MongoClient(settings.Value.ConnectionString);
			var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
			_picturesInfoCollection = database.GetCollection<PicturesInfo>(settings.Value.CollectionName);

			bucket = new GridFSBucket(database);
		}

		public async Task<List<PicturesInfo>> GetAsync() =>
			await _picturesInfoCollection.Find(x => true).ToListAsync();

		public async Task CreateAsync(PicturesInfo picturesInfo) =>
			await _picturesInfoCollection.InsertOneAsync(picturesInfo);

		public async Task UpdateAsync(string picturesId, PicturesInfo picturesInfo) =>
			await _picturesInfoCollection.ReplaceOneAsync(x => x.PictureId == picturesId, picturesInfo);
	}

}
