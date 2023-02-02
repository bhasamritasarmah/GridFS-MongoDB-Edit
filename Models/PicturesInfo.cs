using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GridFSMongoDBEdit.Models
{
	[BsonIgnoreExtraElements]
	public class PicturesInfo
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("info")]
		public string Info { get; set; }

		[BsonElement("picture_id")]
		public string PictureId { get; set; }
	}
}
