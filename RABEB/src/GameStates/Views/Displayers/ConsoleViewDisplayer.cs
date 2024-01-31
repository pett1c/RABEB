using System;
using System.IO;

namespace RABEB
{
    internal class ConsoleViewDisplayer : GameStateViewDisplayer
    {
        public ConsoleViewDisplayer(IGameStateViewData viewData)
            : base(viewData)
        {
        }
        
        public override void Display()
        {
            try
            {
                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            }
            catch (Exception exception) when (
                exception is IOException
                || exception is ArgumentOutOfRangeException
            )
            {
                return;
            }

            ConsoleHelper.HideCursor();

            IBuffer<char> buffer = new Buffer<char>(Console.BufferHeight, Console.BufferWidth, ' ');

            foreach (IWidget widget in _viewData.Widgets) 
            {
                widget?.Renderer?.Render(buffer);
            }

            ConsoleHelper.SetConsoleBuffer(buffer);
        }
    }
}
