using System.Collections.Generic;

namespace RABEB
{
    internal abstract class GameStateViewData : IGameStateViewData, IStartEnd
    {
        public IEnumerable<IWidget> Widgets => _widgets;
        public IEnumerable<IUpdater> WidgetUpdaters => _widgetUpdaters;

        protected List<IWidget> _widgets { get; private set; }
        protected List<IUpdater> _widgetUpdaters { get; private set; }

        protected GameStateViewData() 
        {
            _widgets = new List<IWidget>();
            _widgetUpdaters = new List<IUpdater>();
        }

        public void End()
        {
            foreach (IUpdater widgetUpdater in WidgetUpdaters) 
            {
                widgetUpdater.End();
            }
        }

        public void Start()
        {
            foreach (IUpdater widgetUpdater in WidgetUpdaters)
            {
                widgetUpdater.Start();
            }
        }
    }
}
