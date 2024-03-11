namespace GuessGame
{
    public class Game
    {
        /// <summary>
        /// Количество попыток отгадывания
        /// </summary>
        public static int NumberGuessingAttempts => 3;

        private readonly Random _random = new();

        public void Start()
        {
            int minValue = 1;
            int maxValue = 10;

            Console.WriteLine($"Игра «Угадай число».");
            Console.WriteLine($"Программа рандомно сгенерирует число с {minValue} по {maxValue}, вы должны угадать это число.");
            Console.WriteLine($"У вас {NumberGuessingAttempts} попыток.");

            int generatedNumber = _random.Next(minValue, maxValue);
            int attemptsNumber = 1;
            IComparer comparer = ComparerFactory.CreateComparer();

            while (attemptsNumber <= NumberGuessingAttempts)
            {
                Console.Write($"Попытка {attemptsNumber}. Введите число:");
                int userNumber = Convert.ToInt32(Console.ReadLine());                
                int result = comparer.Compare(userNumber, generatedNumber);
                if (result == 0)
                {
                    Console.WriteLine("Вы отгадали загаданное число!");
                    break;
                }

                if (result == 1)
                {
                    Console.WriteLine("Ваше число больше загаданного.");
                }

                if (result == -1)
                {
                    Console.WriteLine("Ваше число меньше загаданного.");
                }

                attemptsNumber++;
            }

            if (attemptsNumber > NumberGuessingAttempts)
            {
                Console.WriteLine($"Вы не отгадали число за {NumberGuessingAttempts} попыток. Загаданное число {generatedNumber}.");
            }
        }
    }
}
