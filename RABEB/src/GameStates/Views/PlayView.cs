using System.Linq;

namespace RABEB
{
    internal class PlayView : GameStateView
    {
        public override GameStateViewData Data => _data;
        public override GameStateViewDisplayer Displayer => _displayer;

        private PlayViewData _data;
        private GameStateViewDisplayer _displayer;

        public PlayView()
        {
            _data = new PlayViewData();
            _displayer = new ConsoleViewDisplayer(_data);
        }

        public void ChangeBranch(IBranchData branchData)
        {
            IFormatter textFormatter = new Wrapper(70);
            string formattedText = textFormatter.Format(branchData.Text);

            IFormatter optionsFormatter = new Wrapper(20);
            string[] formattedOptions = branchData.Options.Select(option => optionsFormatter.Format(option)).ToArray();

            _data.TextLabelCharAdder.TextToAdd = formattedText;
            _data.OptionsLabel.Data.Sections = formattedOptions;
        }

        public void ChangeOption(int optionIndex) 
        {
            _data.OptionsPointer.Data.Index = optionIndex;
        }
    }
}
