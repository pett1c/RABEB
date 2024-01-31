using System;
using System.Threading;
using System.Threading.Tasks;

namespace RABEB
{
    internal class Game : IGame
    {
        public IGameState State 
        {
            get { return _state; } 
            set 
            {
                _state?.Exit();
                _state = value;
                _state.Enter();
            }
        }

        private GameSettings _settings;
        private IGameState _state;
        private bool _status = true;

        public Game(GameSettings settings) 
        {
            _settings = settings;
        }

        public void Run() 
        {
            while (_status) 
            {
                _state.InputReader.ReadInput();
                _state.Controller.Update();
                _state.View.Displayer.Display();

                Thread.Sleep(1000 / _settings.UPS);
            }
        }

        public void Exit() 
        {
            _state?.Exit();
            _status = false;
        }
    }
}
