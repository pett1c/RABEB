using System.Drawing;

namespace RABEB
{
    internal class SectionLabelData : WidgetData
    {
        public string AllText => string.Join(new string('\n', SectionDistance + 1), Sections);
        public PointF Position { get; set; }
        public int SectionDistance { get; set; }
        public string[] Sections { get; set; }

        public SectionLabelData(PointF position, int sectionDistance, string[] sections) 
        {
            Position = position;
            SectionDistance = sectionDistance;
            Sections = sections;
        }
    }
}
