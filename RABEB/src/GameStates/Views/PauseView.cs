namespace RABEB
{
    internal enum PauseOption 
    {
        Resume,
        MainMenu
    }

    internal class PauseView : GameStateView
    {
        public override GameStateViewData Data => _data;
        public override GameStateViewDisplayer Displayer => _displayer;

        private PauseViewData _data;
        private GameStateViewDisplayer _displayer;

        public PauseView()
        {
            _data = new PauseViewData();
            _displayer = new ConsoleViewDisplayer(_data);
        }
        
        public void ChangeOption(PauseOption option) 
        {
            _data.OptionsPointer.Data.Index = (int)option;
        }
    }
}
