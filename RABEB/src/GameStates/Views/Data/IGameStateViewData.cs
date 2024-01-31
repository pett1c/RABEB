using System.Collections.Generic;

namespace RABEB
{
    internal interface IGameStateViewData
    {
        IEnumerable<IWidget> Widgets { get; }
        IEnumerable<IUpdater> WidgetUpdaters { get; }
    }
}
