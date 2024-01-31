namespace RABEB
{
    internal abstract class WidgetUpdater<TWidget> : Updater
        where TWidget : IWidget
    {
        protected TWidget _widget;

        protected WidgetUpdater(TWidget widget, double intervalInMilliseconds) 
            : base(intervalInMilliseconds)
        {
            _widget = widget;
        }
    }
}
