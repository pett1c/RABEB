using System;

namespace RABEB
{
    internal enum InputAction
    {
        Confirm,
        Cancel,
        Next,
        Previous
    }

    internal abstract class GameStateInputReader : IGameStateInputReader, IStartEnd
    {
        public event Action<InputAction> InputRead;

        public virtual void End() { }
        public virtual void ReadInput() { }
        public virtual void Start() { }

        protected void OnInputRead(InputAction inputAction) 
        {
            InputRead?.Invoke(inputAction);
        }
    }
}
