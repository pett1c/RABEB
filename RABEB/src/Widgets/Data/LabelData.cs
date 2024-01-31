using System.Drawing;

namespace RABEB
{
    internal class LabelData : WidgetData
    {
        public PointF Position { get; set; }
        public string Text { get; set; }

        public LabelData(PointF position, string text) 
        {
            Position = position;
            Text = text;
        }
    }
}
