using System.ComponentModel.DataAnnotations;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace Quadratic;

public class OpenAiRequest
{
    [Required] private string promptString { get; }
    
    public OpenAiRequest(string promptString)
    {
        this.promptString = promptString;
    }

    private List<Choice> OpenAiChat()
    {
        Console.WriteLine("<SYSTEM> Getting request from OpenAI / model: OpenAI_API.Models.Model.DavinciText \n" +
                          "         Please be patient it will take some time.");
        Console.WriteLine("<WARNING> The online answer may not always be 100% correct");

        var client = new OpenAIAPI("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");

        var request = new CompletionRequest
        {
            Model = Model.DavinciText,
            Prompt = promptString,
            MaxTokens = 500,
            Temperature = 0.5
        };

        var response = client.Completions.CreateCompletionAsync(request);
        return response.Result.Completions;
    }

    public void AiRun()
    {
        int reconnectTries = 1,
            connectNum = 5 + 1;
        var NetworkConnectionCheck = new NetworkConnectionCheck();
        do
        {
            if (NetworkConnectionCheck.IsInternetAvailable())
            {
                Console.WriteLine("<SYSTEM> Connected");
                Thread.Sleep(5000);
                var idk = OpenAiChat();
                foreach (var var in idk) Console.WriteLine(var);
                break;
            }

            if (reconnectTries < connectNum)
            {
                Console.WriteLine("<SYSTEM> internet is not available!");
                Thread.Sleep(5000);
                Console.WriteLine($"<SYSTEM> Checking (is internet available?) <{reconnectTries}>");
                Thread.Sleep(1000);
                reconnectTries++;
            }
            else
            {
                Console.WriteLine("<SYSTEM> All attempts failed");
                break;
            }
        } while (reconnectTries <= connectNum);
    }
}