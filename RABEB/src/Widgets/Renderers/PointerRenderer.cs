using System.Drawing;
using System.Linq;

namespace RABEB
{
    internal class PointerRenderer : WidgetRenderer<PointerData>
    {
        private string _section => _sectionLabelData.Sections[_widgetData.Index];
        private SectionLabelData _sectionLabelData => _widgetData.SectionLabelData;

        public PointerRenderer(PointerData pointerData) 
            : base(pointerData)
        {
        }

        protected override void RenderIfVisible(IBuffer<char> buffer)
        {
            if (_widgetData.SectionLabelData.Sections.IsNullOrEmpty())
            {
                return;
            }

            TextDrawer textDrawer = new TextDrawer(
                GetTopLeft(buffer.Size), 
                GetText()
            );
            textDrawer.Draw(buffer);
        }

        private Point GetOffset()
        {
            return new Point(GetOffsetX(), GetOffsetY());
        }

        private int GetOffsetX() 
        {
            return -GetText().Length / 2;
        }

        private int GetOffsetY()
        {
            string allText = _sectionLabelData.AllText;
            int indexOfSection = allText.IndexOf(_section);

            int topOffset = allText.Split('\n').Length / 2;
            int indexOffset = allText.Substring(0, indexOfSection).Split('\n').Length - 1;
            int sectionOffset = _section.Split('\n').Length / 2;

            return indexOffset - topOffset + sectionOffset;
        }

        private Point GetScaledPosition(Point bufferSize) 
        {
            PointF position = _sectionLabelData.Position;
            return position.Multiply(bufferSize).Truncate();
        }

        private string GetText()
        {
            int maxSectionLinesLength = _section.Split('\n').Select(line => line.Length).Max();
            int middleLength = maxSectionLinesLength + _widgetData.Distance * 2;

            string text = (
                _widgetData.StartString
                + new string(CharConstant.Transparent, middleLength)
                + _widgetData.EndString
            );

            return text;
        }

        private Point GetTopLeft(Point bufferSize)
        {
            Point scaledPosition = GetScaledPosition(bufferSize);
            return scaledPosition.Add(GetOffset());
        }
    }
}
