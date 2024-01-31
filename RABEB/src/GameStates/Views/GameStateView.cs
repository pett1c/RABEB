namespace RABEB
{
    internal abstract class GameStateView : IGameStateView, IStartEnd
    {
        public abstract GameStateViewData Data { get; }
        public abstract GameStateViewDisplayer Displayer { get; }

        IGameStateViewDisplayer IGameStateView.Displayer => Displayer;

        public void End()
        {
            Data?.End();
            Displayer?.End();
        }

        public void Start()
        {
            Data?.Start();
            Displayer?.Start();
        }
    }
}
