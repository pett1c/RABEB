using System.Drawing;
using System.IO;

namespace RABEB
{
    internal class MainMenuViewData : GameStateViewData
    {
        public Image LogoImage { get; private set; }
        public SectionLabel OptionsLabel { get; private set; }
        public Pointer OptionsPointer { get; private set; }

        public WidgetVisibilityToggler OptionsPointerVisibilityToggler { get; private set; }

        public MainMenuViewData() 
        {
            ImageData logoImageData;
            using (Bitmap small_logo = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), "small_logo.png")))
            {
                BitmapConverter bitmapConverter = new BitmapConverter(new ColorConverter());
                logoImageData = new ImageData(
                    bitmapConverter.Convert(small_logo),
                    new PointF(0.5f, 7f / 24f)
                );
            };
            SectionLabelData optionsLabelData = new SectionLabelData(
                new PointF(0.5f, 0.5f),
                1,
                new string[]
                {
                    "New Game",
                    "Settings",
                    "Exit"
                }
            );
            PointerData optionsPointerData = new PointerData(optionsLabelData, 1, ">", "<");

            LogoImage = new Image(logoImageData);
            OptionsLabel = new SectionLabel(optionsLabelData);
            OptionsPointer = new Pointer(optionsPointerData);

            OptionsPointerVisibilityToggler = new WidgetVisibilityToggler(OptionsPointer, 400.0);

            _widgets.Add(LogoImage);
            _widgets.Add(OptionsLabel);
            _widgets.Add(OptionsPointer);

            _widgetUpdaters.Add(OptionsPointerVisibilityToggler);
        }
    }
}
