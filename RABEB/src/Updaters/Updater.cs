using System.Timers;

namespace RABEB
{
    internal abstract class Updater : IUpdater
    {
        private Timer _timer;

        protected Updater(double intervalInMilliseconds) 
        {
            _timer = new Timer(intervalInMilliseconds);
            _timer.AutoReset = true;
            _timer.Elapsed += (object s, ElapsedEventArgs e) => Update();
        }

        public void End() 
        {
            _timer.Stop();
        }
        
        public void Start() 
        {
            _timer.Start();
        }

        protected abstract void Update();
    }
}
