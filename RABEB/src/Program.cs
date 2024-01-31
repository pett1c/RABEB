namespace RABEB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WindowHelper.MaximizeWindow();

            GameSettings gameSettings = new GameSettings()
            {
                Language = "",
                UPS = 60
            };

            Game game = new Game(gameSettings);
            game.State = new MainMenuState(game);
            game.Run();
        }
    }
}
