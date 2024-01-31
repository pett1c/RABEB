namespace RABEB
{
    internal abstract class WidgetRenderer<TWidgetData> : IWidgetRenderer
        where TWidgetData : WidgetData
    {
        protected TWidgetData _widgetData { get; private set; }

        protected WidgetRenderer(TWidgetData widgetData) 
        {
            _widgetData = widgetData;
        }

        public void Render(IBuffer<char> buffer) 
        {
            if (_widgetData.IsVisible) 
            {
                RenderIfVisible(buffer);
            }
        }

        protected abstract void RenderIfVisible(IBuffer<char> buffer);
    }
}
