using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Samples.WcfWeb
{
	[ServiceContract]
	public interface IServiceInfo
	{
		[OperationContract]
		[WebGet(UriTemplate = "/InfoJson", 
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		InfoData[] GetStates();

		[OperationContract]
		[WebGet(UriTemplate = "/InfoXml",
			ResponseFormat = WebMessageFormat.Xml,
			BodyStyle = WebMessageBodyStyle.Bare)]
		InfoData[] GetStatesX();

		[OperationContract]
		[WebGet(UriTemplate = "/InfoHtml/{*arguments}", BodyStyle = WebMessageBodyStyle.Bare)]
		Stream Get(string arguments);
	}

	[DataContract]
	public class InfoData
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "title")]
		public string Title { get; set; }
	}
}
