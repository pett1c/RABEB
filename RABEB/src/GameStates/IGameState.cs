namespace RABEB
{
    internal interface IGameState
    {
        IGameStateController Controller { get; }
        IGameStateInputReader InputReader { get; }
        IGameStateView View { get; }

        void Enter();
        void Exit();
    }
}
