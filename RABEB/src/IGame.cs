namespace RABEB
{
    internal interface IGame
    {
        IGameState State { get; set; }
        
        void Exit();
    }
}
