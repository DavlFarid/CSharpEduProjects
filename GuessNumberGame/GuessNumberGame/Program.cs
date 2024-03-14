using GuessGame;
using GuessGame.Services;

IComparer comparer = new NumberComparer();
IValidation validation = new Validation(comparer);
ISettings settings = new Settings();

new Game(validation, settings)
    .Start();
