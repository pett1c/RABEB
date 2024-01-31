using System;

namespace RABEB
{
    internal class PlayModel : GameStateModel
    {
        public event Action<IBranchData> BranchChanged;

        private BranchNavigator _branchNavigator;

        public PlayModel(IGame game) 
            : base(game)
        {
            BranchLoader branchLoader = new BranchLoader();
            Branch[] branches = branchLoader.Load();
            _branchNavigator = new BranchNavigator(branches, branches[0]);
        }

        public void NextBranch(int optionIndex) 
        {
            _branchNavigator.Next(optionIndex);

            if (_branchNavigator.Branch == null)
            {
                GoToMainMenu();
                return;
            }

            BranchChanged?.Invoke(_branchNavigator.Branch);
        }

        public void Pause() 
        {
            _game.State = new PauseState(_game, _game.State);
        }

        public override void Start() 
        {
            BranchChanged?.Invoke(_branchNavigator.Branch);
        }

        private void GoToMainMenu() 
        {
            _game.State = new MainMenuState(_game);
        }
    }
}
