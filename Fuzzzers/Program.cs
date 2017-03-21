using System;
using System.Collections.Generic;

namespace Fuzzzers
{
	class MainClass
	{
		static void Main(string[] args)
		{
			var url = "http://progon.16mb.com/?s=1";
			var vulnType = "CRLF Injection";
			var parser = new UrlParser(url);
			var paramValueDict = parser.GetParamValue();
			var cleanUrl = parser.GetCleanUrl();
			var xmlParser = new XMLManager();
			var exploitProofDict = xmlParser.GetExploitAndProof(vulnType);
			var reqResWorker = new RequestResponseManager();
			var vulnParamsDict = new Dictionary<string, string>();

			foreach (var param in paramValueDict.Keys)
				foreach (var exploitProofList in exploitProofDict[vulnType])
				{
					var exploit = param + "=" + exploitProofList[0].ToString();
					var proof = exploitProofList[1].ToString();
					var dirtyUrl = cleanUrl + "?" + exploit;
					if (reqResWorker.GetHeadersFromResponse(dirtyUrl, proof) != null)
						vulnParamsDict[param] = exploit;
				}


			foreach (var param in vulnParamsDict.Keys)
				Console.WriteLine(param + " is vulnerable. That is exploit: " + vulnParamsDict[param]);
			Console.ReadLine();
		}
	}
}
