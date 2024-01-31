namespace RABEB
{
    internal class RoundCounter : ICounter
    {
        public int Index => _index;

        private int _index = 0;
        private int _maxIndex;

        public RoundCounter(int maxIndex) 
        {
            _maxIndex = maxIndex;
        }

        public RoundCounter(int initialIndex, int maxIndex)
        {
            _index = initialIndex;
            _maxIndex = maxIndex;
        }

        public void Next() 
        {
            _index = ++_index % _maxIndex;
        }

        public void Previous() 
        {
            _index = (--_index + _maxIndex) % _maxIndex;
        }

        public void Reset() 
        {
            _index = 0;
        }
    }
}
