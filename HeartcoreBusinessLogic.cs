using Umbraco.Headless.Client.Net.Delivery;

namespace MyHeartcoreLangauges
{
	public static class HeartcoreBusinessLogic
	{
		public static readonly string ProjectAlias = "mltlngl-wbsts-sng-mbrc-hrtcr";
		public static readonly string LanguageLibraryAlias = "languageLibrary";
		public static readonly string ISOCodeAlias = "iSOCode";

		public static Dictionary<string, string> GetAllLangaugesInLangaugeSpecificName()
		{
			var service = new ContentDeliveryService(ProjectAlias);
			var languageLibraryNode = service.Content.GetRoot().Result.First(n => n.ContentTypeAlias == LanguageLibraryAlias);

			var returnValue = new Dictionary<string, string>();
			foreach (var language in service.Content.GetChildren(languageLibraryNode.Id).Result.Content.Items)
			{
				var langIsoCode = language.Properties.First(p => p.Key == ISOCodeAlias).Value.ToString();
				returnValue.Add(key:langIsoCode , value: service.Content.GetById(language.Id, culture: langIsoCode).Result.Name);
			}
			return returnValue;
		}

		public static Dictionary<string, string> GetAllSupportedLangagues(string selectedLanguageIsoCode)
		{
			var service = new ContentDeliveryService(ProjectAlias);
			var languageLibraryNode = service.Content.GetRoot().Result.First(n => n.ContentTypeAlias == LanguageLibraryAlias);
			return service.Content.GetChildren(languageLibraryNode.Id, culture: selectedLanguageIsoCode).Result.Content.Items
				.ToDictionary(
				language => language.Properties.First(p => p.Key == ISOCodeAlias).Value.ToString() ?? "",
				language => language.Name);
		}
	}
}
