using System.IO;
using System.ServiceModel.Web;
using System.Text;

namespace Samples.WcfWeb  
{
	public class ServiceInfo : IServiceInfo
	{
		public InfoData[] GetStates()
		{
			return new[]
			{
				new InfoData {Id = 1, Title = "Test1"},
				new InfoData {Id = 2, Title = "Test2"},
				new InfoData {Id = 3, Title = "Test3"}
			};
		}

		public InfoData[] GetStatesX()
		{
			return GetStates();
		}

		public Stream Get(string arguments)
		{
			if (WebOperationContext.Current == null)
				return null;

			var uriInfo = WebOperationContext.Current.IncomingRequest.UriTemplateMatch;
			WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

			var rawResponse = new MemoryStream();
			TextWriter response = new StreamWriter(rawResponse, Encoding.UTF8);
			response.Write("<html><head><title>Hello</title></head><body>");
			response.Write("<b>Path</b>: {0}<br/>", arguments);
			response.Write("<b>RequestUri</b>: {0}<br/>", uriInfo.RequestUri);
			response.Write("<b>QueryParameters</b>: {0}<br/>", uriInfo.QueryParameters);
			response.Write("</body></html>");
			response.Flush();

			rawResponse.Position = 0;
			return rawResponse;
		}
	}
}