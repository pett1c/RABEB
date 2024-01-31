namespace RABEB
{
    internal class Pointer : Widget<PointerData, PointerRenderer>
    {
        public Pointer(PointerData data)
            : base(data, new PointerRenderer(data))
        {
        }
    }
}
