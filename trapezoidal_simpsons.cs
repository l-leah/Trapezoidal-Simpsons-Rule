using org.mariuszgromada.math.mxparser;
using System;

namespace Integration
{
    class Program
    {
        static void Mp()
        {
            Console.Write("_______________________________________________");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n         TRAPEZOIDAL AND SIMPSON'S RULE");
            Console.ResetColor();
            Console.Write("_______________________________________________\n");
            Console.Write("\n Input Instructions for f(x):\n\n Use '^' for exponent                                            ex.: x ^ 2 instead of x2 \n Use '*' in coefficient on the term                              ex:. 2 * x instead of 2x \n Use 'e' for euler's number 			                 ex.: e^(x-1) instead of exp(x-1) \n Use proper operation between terms                              ex.: sin(x) * cos(x) instead of sin(x) cos(x) \n Enclose the x value with() in every trigonometric function      ex.: cos(x) instead of cos x\n");
            Console.Write("_______________________________________________\n");
            Console.Write("\n f(x): ");
            string m = Convert.ToString(Console.ReadLine());
            Console.Write("\n Enter beginning of Interval: ");
            double begin = Convert.ToDouble(Console.ReadLine());
            Console.Write("\n Enter end of Interval: ");
            double end = Convert.ToDouble(Console.ReadLine());
            Console.Write("\n Enter number of subdivisions: ");
            int iterations = Convert.ToInt32(Console.ReadLine());

            Console.Write("_______________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n TRAPEZOIDAL RULE\n");
            Console.ResetColor();
            double first = Math.Round(Trapezoidal(m, begin, end, iterations)
                            * 10000.0) / 10000.0;
            double second = Math.Round(Trapezoidal(m, begin, end, iterations + 1)
                            * 10000.0) / 10000.0;
            Console.WriteLine(" Value of Integral in Trapezoidal Rule: " + first);
            Console.WriteLine(" Percentage Error: " + Math.Abs((second - first) / first * 100) + "%");

            Console.Write("_______________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n SIMPSON'S RULE\n");
            Console.ResetColor();
            double simpsonfirst = Validation(m, begin, end, iterations);
            double simpsonsecond = Validation2(m, begin, end, iterations + 2);
            Console.WriteLine(" Value of Integral in Simpson's Rule: " + simpsonfirst);
            Console.WriteLine(" Percentage Error: " + Math.Abs((simpsonsecond - simpsonfirst) / simpsonfirst * 100) + "%");
        }
        static double Function(string m, double x)
        {
            Argument pol = new Argument("x", x);
            Expression f = new Expression(m, pol);
            return (double)f.calculate();
        }

        // Function to evalute the value
        // of integral
        static double Trapezoidal(string m, double a,
                           double b, double n)
        {
            // Grid spacing
            double h = (b - a) / n;

            // Computing sum of first and
            // last terms in above formula
            double s = Function(m, a) + Function(m, b);

            // Adding middle terms in above
            // formula
            for (int i = 1; i < n; i++)
                s += 2 * Function(m, a + i * h);

            // h/2 indicates (b-a)/2n.
            // Multiplying h/2 with s.
            return (h / 2) * s;
        }

        //simpsons
        static double Validation(string m, double ll, double ul, int n)
        {
            double answer;
            if (n % 2 != 0)
            {
                Console.WriteLine(" The Iteration is not even number. The Iteration will be the next number. " +
                    "The new Iteration will be: " + (n + 1) + "\n");
                answer = Simpsons_(m, ll, ul, n + 1);
            }
            else
            {
                answer = Simpsons_(m, ll, ul, n);
            }
            return answer;
        }

        static double Validation2(string m, double ll, double ul, int n)
        {
            double answer;
            if (n % 2 != 0)
            {
                answer = Simpsons_(m, ll, ul, n + 1);
            }
            else
            {
                answer = Simpsons_(m, ll, ul, n);
            }
            return answer;
        }

        static double Simpsons_(string m, double ll, double ul, int n)
        {
            // Calculating the value of h
            double h = (ul - ll) / n;

            // Array for storing value of x
            // and f(x)
            double[] x = new double[100];
            double[] fx = new double[100];

            // Calculating values of x and f(x)
            for (int i = 0; i <= n; i++)
            {
                x[i] = ll + i * h;
                fx[i] = Function(m, x[i]);
            }

            // Calculating result
            double res = 0;
            for (int i = 0; i <= n; i++)
            {
                if (i == 0 || i == n)
                    res += fx[i];
                else if (i % 2 != 0)
                    res += 4 * fx[i];
                else
                    res += 2 * fx[i];
            }

            res = res * (h / 3);
            return res;
        }
        static void AboutAuthor()
        {
            Console.Write("_______________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n         About the Author");
            Console.ResetColor();
            Console.Write("_______________________________________________\n");
            Console.WriteLine("\nThis program is created by:\n vitamin-abc");
        }
        static void MainMenu()
        {
            string choice;
            Console.Write("_______________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n         TRAPEZOIDAL AND SIMPSON'S RULE\n");
            Console.ResetColor();
            Console.Write("_______________________________________________\n");
            Console.Write("\n[1] Trapezoidal & Simpson's Rule\n[2] About the Author\n[3] Exit\n");
            Console.Write("\nCHOICE: ");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Mp();
                    Loop();
                    break;
                case "2":
                    Console.Clear();
                    AboutAuthor();
                    Loop();
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("_______________________________________________\n\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("                     Exit");
                    Console.ResetColor();
                    Console.Write("_______________________________________________\n");
                    Console.WriteLine("\nThank you for using the program!");
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("_______________________________________________\n\n");
                    Console.Write($"Error! '{choice}' is an invalid choice. Please select again.".PadRight(Console.WindowWidth));
                    Console.ResetColor();
                    MainMenu();
                    break;
            }
        }
        static void Loop()
        {
            string mainchoice;
            Console.Write("_______________________________________________");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n[1] Back to Menu [2] Exit program\n");
            Console.ResetColor();
            Console.Write("\nCHOICE: ");
            mainchoice = Console.ReadLine();

            switch (mainchoice)
            {
                case "1":
                    Console.Clear();
                    MainMenu();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("_______________________________________________\n\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("                     Exit");
                    Console.ResetColor();
                    Console.Write("_______________________________________________\n");
                    Console.WriteLine("\nThank you for using the program!");
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Error! '{mainchoice}' is an invalid choice. Please select again.".PadRight(Console.WindowWidth));
                    Console.ResetColor();
                    Loop();
                    break;
            }
        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}
