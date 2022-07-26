using Umbraco.Headless.Client.Net.Delivery;

namespace MyHeartcoreLangauges
{
	public static class HeartcoreBusinessLogic
	{
		public static readonly string ProjectAlias = "mltlngl-wbsts-sng-mbrc-hrtcr";

		public static Dictionary<string, string> GetAllLangaugesInLangaugeSpecificName()
		{
			var service = new ContentDeliveryService(ProjectAlias);
			var languageLibraryNode = service.Content.GetRoot().Result.First(n => n.ContentTypeAlias == "languageLibrary");

			var returnValue = new Dictionary<string, string>();
			foreach (var language in service.Content.GetChildren(languageLibraryNode.Id).Result.Content.Items)
			{
				var langIsoCode = language.Properties.First(p => p.Key == "iSOCode").Value.ToString();
				returnValue.Add(key:langIsoCode , value: service.Content.GetById(language.Id, culture: langIsoCode).Result.Name);
			}
			return returnValue;
		}

		public static Dictionary<string, string> GetAllSupportedLangagues(string selectedLanguageIsoCode)
		{
			var service = new ContentDeliveryService(ProjectAlias);
			var languageLibraryNode = service.Content.GetRoot().Result.First(n => n.ContentTypeAlias == "languageLibrary");

			var returnValue = new Dictionary<string, string>();
			foreach (var language in service.Content.GetChildren(languageLibraryNode.Id, culture: selectedLanguageIsoCode).Result.Content.Items)
			{
				var langIsoCode = language.Properties.First(p => p.Key == "iSOCode").Value.ToString();
				returnValue.Add(key: langIsoCode, value: language.Name);
			}
			return returnValue;
		}
	}
}
