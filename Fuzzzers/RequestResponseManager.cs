using System.Collections.Generic;
using System.Text;
using System.Net;
using System;

namespace Fuzzzers
{
	public class RequestResponseManager
	{
		public string GetHeadersFromResponse(string urlToRequest, string proof)
		{
			var header = "";
			try
			{
				var reqUrl = WebRequest.Create(urlToRequest);
				using (WebResponse response = reqUrl.GetResponse())
				{
					header = response.Headers.Get(proof);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Could not connect. " + ex.Message);
			}
			return header;
		}
	}
}

