using System;

namespace RABEB
{
    internal abstract class OptionsController<Option> : GameStateController
        where Option : Enum
    {
        public event Action<Option> OptionChanged;
        public event Action<Option> OptionConfirmed;

        private ICounter _optionCounter;
        private Option _option => EnumHelper.EnumFromInt<Option>(_optionCounter.Index);

        protected OptionsController() 
        {
            int numberOfOptions = Enum.GetNames(typeof(Option)).Length;
            _optionCounter = new RoundCounter(numberOfOptions);
        }

        public void HandleInput(InputAction inputAction)
        {
            switch (inputAction)
            {
                case InputAction.Next:
                    _optionCounter.Next();
                    break;
                case InputAction.Previous:
                    _optionCounter.Previous();
                    break;
                case InputAction.Confirm:
                    OptionConfirmed?.Invoke(_option);
                    break;
            }

            if (inputAction == InputAction.Next
                || inputAction == InputAction.Previous)
            {
                OptionChanged?.Invoke(_option);
            }
        }
    }
}
