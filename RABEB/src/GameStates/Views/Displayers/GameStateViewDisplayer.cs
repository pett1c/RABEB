namespace RABEB
{
    internal abstract class GameStateViewDisplayer : IGameStateViewDisplayer, IStartEnd
    {
        protected IGameStateViewData _viewData { get; private set; }

        protected GameStateViewDisplayer(IGameStateViewData viewData) 
        {
            _viewData = viewData;
        }

        public abstract void Display();
        public virtual void End() { }
        public virtual void Start() { }
    }
}
