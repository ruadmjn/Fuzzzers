using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Fuzzzers
{
	class XMLManager
	{
		public static string fileToParse = "";
		public XMLManager(string file = @"Resources\Exploits.xml")
		{
			fileToParse = file;
		}
		public Dictionary<string, List<string>> GetExploitAndProof(string vulnType)
		{
			var paramValue = new Dictionary<string, List<string>>();
			var exploitAndProofList = new List<string>();
			var rootNode = XElement.Load(fileToParse).Elements("vuln");
			foreach (var vuln in rootNode)
			{
				if (!vuln.Attribute("name").Value.Equals(vulnType))
					continue;
				foreach (var exploit in vuln.Elements("exploit"))
				{
					exploitAndProofList.Add(exploit.Value);
				}
				foreach (var proof in vuln.Elements("proof"))
				{
					exploitAndProofList.Add(proof.Value);
				}
				paramValue[vuln.Attribute("name").Value] = exploitAndProofList;
			}
			return paramValue;
		}

	}
}
