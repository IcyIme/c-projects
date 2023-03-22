using Quadratic;

internal class Program
{
    private static void Main()
    {
        float  a = 0,
            b = 0,
            c = 0;

        var isConfirned = false;

        var UI = new UiAdd();
        var CheckIsNumber = new CheckIsNumber();

        while (!isConfirned)
        {
            var promnt = "x = (-b +- _/-(b^2 - 4ac)) / (2a)";
            string[] option =
            {
                $"A: {CheckIsNumber.IsSomethingThere(a)}",
                $"B: {CheckIsNumber.IsSomethingThere(b)}",
                $"C: {CheckIsNumber.IsSomethingThere(c)}",
                "ENTER CHANGES"
            };

            string[] dsc =
            {
                $"x = (-b +- _/-(b^2 - 4<{a}>c)) / (2<{a}>)",
                $"x = (-<{b}> +- _/-(<{b}>^2 - 4ac)) / (2a)",
                $"x = (-b +- _/-(b^2 - 4a<{c}>)) / (2a)",
                "Accept"
            };


            UI.OptionSetup(promnt, option, dsc, null);
            var selectedIndedx = UI.run();

            switch (selectedIndedx)
            {
                case 0:
                    Console.Write("Enter number: ");
                    a = CheckIsNumber.IsNumber(Console.ReadLine());
                    break;
                case 1:
                    Console.Write("Enter number: ");
                    b = CheckIsNumber.IsNumber(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Enter number: ");
                    c = CheckIsNumber.IsNumber(Console.ReadLine());
                    break;
                case 3:
                    if (CheckIsNumber.IsIvalidOutput(a, b, c))
                    {
                        Console.WriteLine("Invalid input detected");
                    }
                    else
                    {
                        double x1 = (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
                        double x2 = (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);

                        promnt = $"Result\nx1 = {x1}\nx2 = {x2}";
                        string[] opti =
                        {
                            $"Online Results",
                            $"Reset",
                            $"End"
                        };

                        string[] dcs2 =
                        {
                            $"Requiers internet connection",
                            $"Reset vars",
                            $"Exit program",
                        };

                        UI.OptionSetup(promnt, opti, dcs2, null);
                        selectedIndedx = UI.run();

                        switch (selectedIndedx)
                        {
                            case 0:
                                Thread.Sleep(1000);
                                var ai = new OpenAiRequest(
                                    $"Vytvor postup riešenia tejto kvadratickej rovnice {a}x^2 + {b}x + {c} = 0 podla vzorca na riešenie korenu rovnice: x = (-b ± √(b² - 4ac)) / (2a) a, keď budeš mať výsledok zapisho ako x1 = niečo a x2 = niečo. pokus sa to urobit bez chyby");
                                ai.AiRun();
                                Console.WriteLine("Press any key to continue");
                                Reset(ref a, ref b, ref c);
                                Console.ReadKey();
                                break;
                            case 1:
                                Reset(ref a, ref b, ref c);
                                break;
                            case 2:
                                isConfirned = true;
                                break;
                        }
                    }

                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    private static void Reset(ref float a, ref float b, ref float c)
    {
        a = 0;
        b = 0;
        c = 0;
    }
}