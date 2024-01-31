namespace RABEB
{
    internal class WidgetVisibilityToggler : WidgetUpdater<IWidget>
    {
        public WidgetVisibilityToggler(IWidget widget, double intervalInMilliseconds)
            : base(widget, intervalInMilliseconds)
        {
        }

        protected override void Update()
        {
            _widget.Data.IsVisible = !_widget.Data.IsVisible;
        }
    }
}
