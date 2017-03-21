using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fuzzzers
{
	public class UrlParser
	{
		public static string urlToParse = "";
		public UrlParser(string url = "")
		{
			urlToParse = url;
		}

		public Dictionary<string, string> GetParamValue()
		{
			var paramValue = new Dictionary<string, string>();
			foreach (Match matched in Regex.Matches(urlToParse, @"(?:(?:\&|\?)(\w*)(?:=)(\w*))"))
			{
				//param as key, value as value
				paramValue[matched.Groups[1].Value] = matched.Groups[2].Value;
			}
			return paramValue;
		}

		public string GetCleanUrl()
		{
			var cleanUrl = urlToParse;
			foreach (Match matched in Regex.Matches(urlToParse, @"(?:(?:\&|\?)(\w*)(?:=)(\w*))"))
			{
				cleanUrl = cleanUrl.Replace(matched.Groups[1].Value + "=" + matched.Groups[2].Value, "").Trim('?', '&');
			}
			return cleanUrl;
		}
	}
}
