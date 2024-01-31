using System.Drawing;

namespace RABEB
{
    internal class LabelRenderer : WidgetRenderer<LabelData>
    {
        private string[] _lines => _widgetData.Text.Split('\n');
        private int _numberOfLines => _lines.Length;

        public LabelRenderer(LabelData labelData)
            : base(labelData)
        {
        }

        protected override void RenderIfVisible(IBuffer<char> buffer)
        {
            if (string.IsNullOrEmpty(_widgetData.Text))
            {
                return;
            }

            TextDrawer[] textDrawers = new TextDrawer[_numberOfLines];

            for (int i = 0; i < textDrawers.Length; i++)
            {
                Point lineTopLeft = GetLineTopLeft(buffer.Size, i);
                textDrawers[i] = new TextDrawer(lineTopLeft, _lines[i]);
            }

            foreach (TextDrawer textDrawer in textDrawers)
            {
                textDrawer.Draw(buffer);
            }
        }

        private Point GetLineOffset(int lineIndex)
        {
            return new Point(
                -_lines[lineIndex].Length / 2,
                -_numberOfLines / 2 + lineIndex
            );
        }

        private Point GetLineTopLeft(Point bufferSize, int lineIndex)
        {
            Point scaledPosition = GetScaledPosition(bufferSize);
            Point offset = GetLineOffset(lineIndex);

            return scaledPosition.Add(offset);
        }

        private Point GetScaledPosition(Point bufferSize)
        {
            Point scaledPosition = _widgetData.Position.Multiply(bufferSize).Truncate();
            return scaledPosition;
        }
    }
}
