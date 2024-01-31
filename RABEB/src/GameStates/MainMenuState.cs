namespace RABEB
{
    internal class MainMenuState : GameState<MainMenuController, KeyboardInputReader, MainMenuModel, MainMenuView>
    {
        public MainMenuState(IGame game)
            : base(game)
        {
            _controller = new MainMenuController();
            _inputReader = new KeyboardInputReader();
            _model = new MainMenuModel(game);
            _view = new MainMenuView();

            _inputReader.InputRead += _controller.HandleInput;

            _controller.OptionChanged += _view.ChangeOption;
            _controller.OptionConfirmed += _model.ConfirmOption;
        }
    }
}
