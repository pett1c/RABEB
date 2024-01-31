namespace RABEB
{
    internal class PauseState : GameState<PauseController, KeyboardInputReader, PauseModel, PauseView>
    {
        public PauseState(IGame game, IGameState previousState) 
            : base(game)
        {
            _controller = new PauseController();
            _inputReader = new KeyboardInputReader();
            _model = new PauseModel(game, previousState);
            _view = new PauseView();

            _inputReader.InputRead += _controller.HandleInput;

            _controller.OptionChanged += _view.ChangeOption;
            _controller.OptionConfirmed += _model.ConfirmOption;
        }
    }
}