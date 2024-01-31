using System;
using System.Collections.Generic;

namespace RABEB
{
    internal class KeyboardInputReader : GameStateInputReader
    {
        private Dictionary<ConsoleKey, InputAction> _inputActionByConsoleKey;

        public KeyboardInputReader() 
        {
            _inputActionByConsoleKey = new Dictionary<ConsoleKey, InputAction>()
            {
                { ConsoleKey.Enter, InputAction.Confirm },
                { ConsoleKey.Escape, InputAction.Cancel },
                { ConsoleKey.DownArrow, InputAction.Next },
                { ConsoleKey.UpArrow, InputAction.Previous }
            };
        }

        public override void ReadInput()
        {
            ConsoleKey? key = ConsoleHelper.ReadKeyWhileAvailableOrGetNull();

            if (key == null) 
            {
                return;
            }

            InputAction inputAction;

            if (_inputActionByConsoleKey.TryGetValue((ConsoleKey)key, out inputAction)) 
            {
                OnInputRead(inputAction);
            }
        }
    }
}
