namespace RABEB
{
    internal abstract class GameStateController : IGameStateController, IStartEnd
    {
        public virtual void End() { }
        public virtual void Start() { }
        public virtual void Update() { }
    }
}