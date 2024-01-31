namespace RABEB
{
    internal class PlayState : GameState<PlayController, KeyboardInputReader, PlayModel, PlayView>
    {
        public PlayState(IGame game)
            : base(game)
        {
            _controller = new PlayController();
            _inputReader = new KeyboardInputReader();
            _model = new PlayModel(game);
            _view = new PlayView();

            _inputReader.InputRead += _controller.HandleInput;

            _controller.OptionChanged += _view.ChangeOption;
            _controller.OptionConfirmed += _model.NextBranch;
            _controller.Paused += _model.Pause;

            _model.BranchChanged += _view.ChangeBranch;
            _model.BranchChanged += _controller.ChangeBranch;
        }
    }
}
