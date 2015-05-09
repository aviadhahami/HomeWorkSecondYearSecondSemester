namespace B15_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            bool isNotValid = true;
            string insertedString = string.Empty;

            System.Console.WriteLine("Please enter a positive 8 digit number");
            while (isNotValid)
            {
                insertedString = System.Console.ReadLine();
                isNotValid = correctInput(insertedString);
                if (isNotValid)
                {
                    System.Console.WriteLine("Entry not valid: Please enter a positive 8 digit number");
                }
            }

            printAllChecks(insertedString);
        }

        private static bool correctInput(string i_Input)
        {
            int number;
            bool validator = int.TryParse(i_Input, out number);
            if (validator)
            {
                validator = (i_Input.Length == 8) & (number > 0);
            }
            
            return !validator;
        }

        private static void printAllChecks(string i_Input)
        {
            char lowest = i_Input[0];
            char highest = i_Input[0];
            int counterHigher = 0;
            int counterLower = 0;

            for (int i = 1; i < i_Input.Length; i++)
            {
                // $G$ NTT-004 (-3) You should have used Math classes methods Min & Max instead.
                lowest = (lowest <= i_Input[i]) ? lowest : i_Input[i];
                highest = (highest >= i_Input[i]) ? highest : i_Input[i];

                counterHigher += (i_Input[i] > i_Input[0]) ? 1 : 0;
                counterLower += (i_Input[i] < i_Input[0]) ? 1 : 0;
            }

            // $G$ NTT-999 (-5) Should use Environment.NewLine rather than \n.
            // $G$ NTT-999 (-3) Verbatim string (@) could be used to print once, rather than calling Console.WriteLine for each line.
            string printStringFormatted = string.Format("Highest number is: {0}   Lowest number is: {1}", highest, lowest);
            string printStringFormatted2 = string.Format("Amount of numbers higher then first digit is: {0} \n\rAmount of numbers lower then first digit is: {1}", counterHigher, counterLower);
            System.Console.WriteLine(printStringFormatted);
            System.Console.WriteLine(printStringFormatted2);
        }
    }
}