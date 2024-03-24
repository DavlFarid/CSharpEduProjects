using GuessGame.Services;

namespace GuessGame;

public class Game(IValidation validation, ISettings settings)
{
    private readonly IValidation _validation = validation;
    private readonly ISettings _settings = settings;

    public void Start()
    {
        Console.WriteLine($"Игра «Угадай число».");
        Console.WriteLine($"Программа рандомно сгенерирует число с {_settings.MinValue} по {_settings.MaxValue}, вы должны угадать это число.");
        Console.WriteLine($"У вас {_settings.NumberGuessingAttempts} попыток.");

        Random random = new();
        int generatedNumber = random.Next(_settings.MinValue, _settings.MaxValue);
        int attemptsNumber = 1;

        while (attemptsNumber <= _settings.NumberGuessingAttempts)
        {
            Console.Write($"Попытка {attemptsNumber}. Введите число:");
            int userNumber = Convert.ToInt32(Console.ReadLine());
            if (_validation.Validate(userNumber, generatedNumber))
            {
                break;
            };

            attemptsNumber++;
        }

        if (attemptsNumber > _settings.NumberGuessingAttempts)
        {
            Console.WriteLine($"Вы не отгадали число за {_settings.NumberGuessingAttempts} попыток. Загаданное число {generatedNumber}.");
        }
    }
}
