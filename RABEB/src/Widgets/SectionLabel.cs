namespace RABEB
{
    internal class SectionLabel : Widget<SectionLabelData, SectionLabelRenderer>
    {
        public SectionLabel(SectionLabelData data) 
            : base(data, new SectionLabelRenderer(data))
        {
        }
    }
}
