// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.AI.Translation.Text;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
string visionKey = "<your-vision-key>";
string endpoint = "https://myroscustomvision.cognitiveservices.azure.com/";
//string url = "https://kuluarpohod.com/wp-content/uploads/2022/01/109434484_3075711659184387_6942555446236946637_o.jpg";
string url = "https://babel.ua/static/content/frtlki9g/thumbs/x/f/88/0308a92d73150061a405a9d618b3788f.jpg";
ApiKeyServiceClientCredentials credentials = new ApiKeyServiceClientCredentials(visionKey);
ComputerVisionClient visionClient = new ComputerVisionClient(credentials)
{
    Endpoint = endpoint,
};
IList<VisualFeatureTypes?> visualFeatures = Enum
    .GetValues(typeof(VisualFeatureTypes))
    .OfType<VisualFeatureTypes?>()
    .ToList();
ImageAnalysis imageAnalysis = await visionClient.AnalyzeImageAsync(
    url: url,
    visualFeatures: visualFeatures);
if (imageAnalysis.Description is not null)
{
    foreach (var caption in imageAnalysis.Description.Captions)
    {
        Console.WriteLine($"Text: {caption.Text}");
        Console.WriteLine($"Confidence: {caption.Confidence}");
    }
}
Console.WriteLine($"------------Categories----------");
foreach (Category category in imageAnalysis.Categories)
{
    Console.WriteLine($"Name: {category.Name}");
    Console.WriteLine($"Score: {category.Score}");

    if (category.Detail is not null && category.Detail.Celebrities.Count > 0)
    {
        Console.WriteLine("---Celebrities------");
        foreach (var celebrity in category.Detail.Celebrities)
        {
            Console.WriteLine($"Celebrity {celebrity.Name} with confidence {celebrity.Confidence}");
        }
    }
}

//string apiKey = "";
//AzureKeyCredential keyCredential = new AzureKeyCredential(apiKey);
//TextTranslationClient translationClient = new TextTranslationClient(keyCredential);
//string sourceLanguage = "uk";
//string destinationLanguage = "en";
//string destinationLanguage2 = "pl";
//string sourceText = "Дуже добре, що компанія Майкрософт не зупиняється і завжди покращує свої сервіси";
//try
//{
//    var resp = await translationClient.TranslateAsync(
//        targetLanguages: new[] { destinationLanguage, destinationLanguage2 },
//        content: new[] { sourceText }//,
//        //sourceLanguage: sourceLanguage
//        );
//    IReadOnlyList<TranslatedTextItem> translatedTexts = resp.Value;
//    foreach(TranslatedTextItem translatedTextItem in translatedTexts)
//    {
//        Console.WriteLine($"Detected Language: {translatedTextItem.DetectedLanguage.Language}");
//        Console.WriteLine($"Detected Language Confidence: {translatedTextItem.DetectedLanguage.Confidence}");
//        foreach(var translation in translatedTextItem.Translations)
//        {
//            Console.WriteLine($"Translated text: {translation.Text}");
//            Console.WriteLine($"Translated text: {translation.TargetLanguage}");
//            Console.WriteLine("--------");

//        }

//        Console.WriteLine("--------------");
//    }
//}
//catch(RequestFailedException rfex)
//{
//    Console.WriteLine($"Message: {rfex.Message}");
//    Console.WriteLine($"Error COde: {rfex.ErrorCode}");
//}
