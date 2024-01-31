namespace RABEB
{
    internal class Label : Widget<LabelData, LabelRenderer> 
    {
        public Label(LabelData data) 
            : base(data, new LabelRenderer(data))
        {
        }
    }
}
