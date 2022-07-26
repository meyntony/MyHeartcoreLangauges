using MyHeartcoreLangauges;
using System.Text;
using Umbraco.Headless.Client.Net.Delivery;

Dictionary<string, string> allLangaugesInLangaugeSpecificName = HeartcoreBusinessLogic.GetAllLangaugesInLangaugeSpecificName();

Console.OutputEncoding = Encoding.UTF8;

foreach (var language in allLangaugesInLangaugeSpecificName)
{ 
	Console.WriteLine($"ISO Code: {language.Key} = {language.Value}");
}
string selectedLanguageIsoCode = null;
do {
	Console.WriteLine("Pick and type the ISO Code of the langauge you want to select from the list above: ");
	selectedLanguageIsoCode = Console.ReadLine();
}while (!allLangaugesInLangaugeSpecificName.ContainsKey(selectedLanguageIsoCode));

Dictionary<string, string> allSupportedLangagues = HeartcoreBusinessLogic.GetAllSupportedLangagues(selectedLanguageIsoCode);
var service = new ContentDeliveryService(HeartcoreBusinessLogic.ProjectAlias);
var welcomeMessage = service.Content.GetRoot(culture: selectedLanguageIsoCode).Result.First(n => n.ContentTypeAlias == "home").Properties.First(p => p.Key == "welcomeMessage").Value;
Console.WriteLine(welcomeMessage);
foreach (var language in allSupportedLangagues)
{
	Console.WriteLine($"{language.Value}");
}
