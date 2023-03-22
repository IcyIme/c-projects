namespace Quadratic;

public class UiAdd
{
    private int selectedIdenx;
    private string[]  options;
    private string[] action_Description;
    private string[] addtion;
    private string promnt;
    
    
    public void OptionSetup(string promnt, string[] options, string[] actionDescription, string[] addtion)
    {
        this.promnt = promnt;
        this.options = options;
        this.action_Description = actionDescription;
        this.addtion = addtion;
        selectedIdenx = 0;
    }

    private void DisplayOptions()
    {
        Console.WriteLine(promnt);
        if (addtion == null)
        {
            Console.WriteLine("");
        }
        else
        {
           Console.WriteLine(addtion[selectedIdenx]); 
        }
        
        
        
        Console.WriteLine("====================");
        
        
        for (var i = 0; i < options.Length; i++)
        {
            var currentOption = options[i];
            string prefix;
            string postfix;

            if (i == selectedIdenx)
            {
                prefix = ">";
                postfix = "<";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                prefix = " ";
                postfix = " ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.WriteLine($"{prefix} | {currentOption} | {postfix}");
            //Console.WriteLine($"Debug index {i}");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine($" \n |?| {action_Description[selectedIdenx]}");
    }

    public int run()
    {
        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            DisplayOptions();
            var keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;

            //update
            if (keyPressed == ConsoleKey.UpArrow)
            {
                selectedIdenx--;
                if (selectedIdenx == -1) selectedIdenx = options.Length - 1;
                }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                selectedIdenx++;
                if (selectedIdenx == options.Length) selectedIdenx = 0;
            }else if (keyPressed == ConsoleKey.F1)
            {
                
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        } while (keyPressed != ConsoleKey.Enter);

        return selectedIdenx;
    }

    private void Color()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
    }
}