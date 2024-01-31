using System.Drawing;

namespace RABEB
{
    internal class PauseViewData : GameStateViewData
    {
        public SectionLabel OptionsLabel { get; private set; }
        public Pointer OptionsPointer { get; private set; }

        public WidgetVisibilityToggler OptionsPointerVisibilityToggler { get; private set; }

        public PauseViewData() 
        {
            SectionLabelData optionsLabelData = new SectionLabelData(
                new PointF(0.5f, 0.5f),
                1,
                new string[] 
                {
                    "Resume",
                    "Main menu"
                }
            );
            PointerData optionsPointerData = new PointerData(
                optionsLabelData, 
                1, 
                ">", 
                "<"
            );

            OptionsLabel = new SectionLabel(optionsLabelData);
            OptionsPointer = new Pointer(optionsPointerData);

            OptionsPointerVisibilityToggler = new WidgetVisibilityToggler(OptionsPointer, 400.0);

            _widgets.Add(OptionsLabel);
            _widgets.Add(OptionsPointer);

            _widgetUpdaters.Add(OptionsPointerVisibilityToggler);
        }
    }
}
