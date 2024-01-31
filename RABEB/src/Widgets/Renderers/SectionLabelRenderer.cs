namespace RABEB
{
    internal class SectionLabelRenderer : WidgetRenderer<SectionLabelData>
    {
        public SectionLabelRenderer(SectionLabelData sectionLabelData) 
            : base(sectionLabelData)
        {
        }

        protected override void RenderIfVisible(IBuffer<char> buffer)
        {
            if (_widgetData.Sections.IsNullOrEmpty())
            {
                return;
            }

            LabelData labelData = new LabelData(_widgetData.Position, _widgetData.AllText);
            LabelRenderer labelRenderer = new LabelRenderer(labelData);

            labelRenderer.Render(buffer);
        }
    }
}
