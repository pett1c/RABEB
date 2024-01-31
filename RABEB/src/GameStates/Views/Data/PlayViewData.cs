using System.Drawing;

namespace RABEB
{
    internal class PlayViewData : GameStateViewData
    {
        public SectionLabel OptionsLabel { get; private set; }
        public Pointer OptionsPointer { get; private set; }
        public Label TextLabel { get; private set; }

        public WidgetVisibilityToggler OptionsPointerVisibilityToggler { get; private set; }
        public LabelCharAdder TextLabelCharAdder { get; private set; }

        public PlayViewData() 
        {
            SectionLabelData optionsLabelData = new SectionLabelData(
                new PointF(0.5f, 0.5f), 
                1, 
                new string[0]
            );
            PointerData optionsPointerData = new PointerData(
                optionsLabelData, 
                1, 
                ">", 
                "<"
            );
            LabelData textLabelData = new LabelData(
                new PointF(0.5f, 7f / 24f), 
                ""
            );

            OptionsLabel = new SectionLabel(optionsLabelData);
            OptionsPointer = new Pointer(optionsPointerData);
            TextLabel = new Label(textLabelData);

            OptionsPointerVisibilityToggler = new WidgetVisibilityToggler(OptionsPointer, 400.0);
            TextLabelCharAdder = new LabelCharAdder(TextLabel, 12.0);

            _widgets.Add(OptionsLabel);
            _widgets.Add(OptionsPointer);
            _widgets.Add(TextLabel);

            _widgetUpdaters.Add(OptionsPointerVisibilityToggler);
            _widgetUpdaters.Add(TextLabelCharAdder);
        }
    }
}
