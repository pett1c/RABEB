namespace RABEB
{
    internal abstract class GameState<TController, TInputReader, TModel, TView> : IGameState
        where TController : GameStateController
        where TInputReader : GameStateInputReader
        where TModel : GameStateModel
        where TView : GameStateView
    {
        public IGameStateController Controller => _controller;
        public IGameStateInputReader InputReader => _inputReader;
        public IGameStateView View => _view;

        protected TController _controller { get; set; }
        protected TInputReader _inputReader { get; set; }
        protected TModel _model { get; set; }
        protected TView _view { get; set; }

        protected GameState(IGame game) { }

        public void Enter()
        {
            _controller?.Start();
            _inputReader?.Start();
            _model?.Start();
            _view?.Start();
        }

        public void Exit()
        {
            _controller?.End();
            _inputReader?.End();
            _model?.End();
            _view?.End();
        }
    }
}
