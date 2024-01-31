namespace RABEB
{
    internal enum MainMenuOption
    {
        NewGame,
        Settings,
        Exit
    }

    internal class MainMenuView : GameStateView 
    {
        public override GameStateViewData Data => _data;
        public override GameStateViewDisplayer Displayer => _displayer;

        private MainMenuViewData _data;
        private GameStateViewDisplayer _displayer;

        public MainMenuView() 
        {
            _data = new MainMenuViewData();
            _displayer = new ConsoleViewDisplayer(_data);
        }

        public void ChangeOption(MainMenuOption option) 
        {
            _data.OptionsPointer.Data.Index = (int)option;
        }
    }
}
