using System.Linq.Expressions;

namespace RABEB
{
    internal class PauseModel : GameStateModel
    {
        private IGameState _previousState;

        public PauseModel(IGame game, IGameState previousState) 
            : base(game)
        {
            _previousState = previousState;
        }

        public void ConfirmOption(PauseOption option) 
        {
            switch (option) 
            {
                case PauseOption.Resume:
                    _game.State = _previousState;
                    break;
                case PauseOption.MainMenu:
                    _game.State = new MainMenuState(_game);
                    break;
            }
        }
    }
}