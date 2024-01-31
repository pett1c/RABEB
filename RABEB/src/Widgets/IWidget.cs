namespace RABEB
{
    internal interface IWidget
    {
        IWidgetData Data { get; }
        IWidgetRenderer Renderer { get; }
    }
}
