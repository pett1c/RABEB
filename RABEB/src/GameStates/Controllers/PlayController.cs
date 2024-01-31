using System;

namespace RABEB
{
    internal class PlayController : GameStateController
    {
        public event Action<int> OptionChanged;
        public event Action<int> OptionConfirmed;
        public event Action Paused;

        private ICounter _optionCounter;
        private int _optionIndex => _optionCounter.Index;

        public void HandleInput(InputAction inputEvent)
        {
            switch (inputEvent)
            {
                case InputAction.Next:
                    _optionCounter.Next();
                    break;
                case InputAction.Previous:
                    _optionCounter.Previous();
                    break;
                case InputAction.Confirm:
                    OptionConfirmed?.Invoke(_optionIndex);
                    break;
                case InputAction.Cancel:
                    Paused?.Invoke();
                    break;
            }

            if (inputEvent == InputAction.Next
                || inputEvent == InputAction.Previous) 
            {
                OptionChanged?.Invoke(_optionIndex);
            }
        }

        public void ChangeBranch(IBranchData branchData) 
        {
            int numberOfOptions = branchData.Options.Length;
            _optionCounter = new RoundCounter(numberOfOptions);
            OptionChanged?.Invoke(_optionIndex);
        }
    }
}
