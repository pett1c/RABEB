namespace RABEB
{
    internal class PointerData : WidgetData
    {
        public int Index { get; set; }
        public SectionLabelData SectionLabelData { get; set; }

        public int Distance { get; set; }
        public string EndString { get; set; }
        public string StartString { get; set; }

        public PointerData(SectionLabelData sectionLabelData, int distance, string startString, string endString)
        {
            SectionLabelData = sectionLabelData;
            Distance = distance;
            StartString = startString;
            EndString = endString;
        }
    }
}
