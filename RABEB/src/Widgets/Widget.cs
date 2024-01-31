namespace RABEB
{
    internal abstract class Widget<TData, TRenderer> : IWidget
        where TData : WidgetData
        where TRenderer : WidgetRenderer<TData>
    {
        public TData Data { get; private set; }
        public TRenderer Renderer { get; private set; }

        IWidgetData IWidget.Data => Data;
        IWidgetRenderer IWidget.Renderer => Renderer;

        protected Widget(TData data, TRenderer renderer) 
        {
            Data = data;
            Renderer = renderer;
        }
    }
}
