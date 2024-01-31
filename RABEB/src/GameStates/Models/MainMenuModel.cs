namespace RABEB
{
    internal class MainMenuModel : GameStateModel
    {
        public MainMenuModel(IGame game) 
            : base(game)
        {
        }

        public void ConfirmOption(MainMenuOption option) 
        {
            switch (option) 
            {
                case MainMenuOption.NewGame:
                    _game.State = new PlayState(_game);
                    break;
                case MainMenuOption.Settings:
                    break;
                case MainMenuOption.Exit:
                    _game.Exit();
                    break;
            }
        }
    }
}
