namespace NumberGuess
{
     /**
        თამაშების ზოგადი სუპერ კლასი რომლისგანაც
         შემდეგ სხვა თამაშები აიღებენ მემკვიდრეობას
        **/
    public abstract class Game
    {

        public string Title { get; protected set; }

        public Game(string title)
        {
            Title = title;
        }
        // მეთოდი რომლის იმპლემენტაციაც უნდა მოხდეს შვილობილ კლასებში
        public abstract void Start();
    }

    // Game კლასისგან მემკვიდრეობით შექმნილი NumberGuessingGame კლასი

    public class NumberGuessingGame : Game
    {

        // თამაშისთვის საჭირო ფორეფერთები რომლებიც თამაშის მიმდინარეობის დეოს აღარ იცვლება
        private readonly int _targetNumber;
        private readonly int _maxAttempts;


        public NumberGuessingGame(string title, int maxAttempts) : base(title)
        {
            var random = new Random();
            _targetNumber = random.Next(1, 21);
            _maxAttempts = maxAttempts;
        }

        // მეთოდი რომელიც გამოიძახება თამაშის დაწყების დროს
        public override void Start()
        {
            Console.WriteLine($"Welcome to {Title}!");
            Console.WriteLine($"Try to guess the number between 1 and 100. You have {_maxAttempts} attempts.");

            int attempts = 0;
            bool guessedCorrectly = false;

            // ვაილ ლუპი რომელიც მუშაობს იქამდე სანამ მაქსიმალური ცდები არ ამოიწურება ან რიცხვს არ გამოვიცნობთ
            while (attempts < _maxAttempts)
            {
                attempts++;
                Console.Write($"Attempt {attempts}/{_maxAttempts}: Enter your guess: ");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    attempts--;
                    continue;
                }
                // რიცხვის გამოცნობის შემთხვევაში იუსერს ვუბრუნებთ შესაბამისს მესიჯს
                if (guess == _targetNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the correct number: {_targetNumber} in {attempts} attempts.");
                    guessedCorrectly = true;
                    break;
                }

                if (guess < _targetNumber)
                {
                    Console.WriteLine("Too low!");
                }
                else
                {
                    Console.WriteLine("Too high!");
                }
            }

            if (!guessedCorrectly)
            {
                Console.WriteLine($"Game over! The correct number was {_targetNumber}.");
            }
        }
    }

    class Program
    {
        // მეინ მეთოდი რომელიც ეშვება ავტომატურად
        static void Main(string[] args)
        {
            NumberGuessingGame game = new NumberGuessingGame("Number Guessing Game", 10);

            game.Start();
        }
    }
}