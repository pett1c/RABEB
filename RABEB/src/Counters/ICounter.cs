namespace RABEB
{
    internal interface ICounter
    {
        int Index { get; }

        void Next();
        void Previous();
        void Reset();
    }
}
