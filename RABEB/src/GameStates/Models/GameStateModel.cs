namespace RABEB
{
    internal class GameStateModel : IGameStateModel, IStartEnd
    {
        protected IGame _game { get; private set; }

        protected GameStateModel(IGame game) 
        {
            _game = game;
        }

        public virtual void End() { }
        public virtual void Start() { }
    }
}
