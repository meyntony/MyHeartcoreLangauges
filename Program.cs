using MyHeartcoreLangauges;

Dictionary<string, string> allLangaugesInLangaugeSpecificName = HeartcoreBusinessLogic.GetAllLangaugesInLangaugeSpecificName();

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

foreach (var language in allSupportedLangagues)
{
	Console.WriteLine($"ISO Code: {language.Key} = {language.Value}");
}