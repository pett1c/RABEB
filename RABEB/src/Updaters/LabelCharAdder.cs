using System.Text;

namespace RABEB
{
    internal class LabelCharAdder : WidgetUpdater<Label>
    {
        public string TextToAdd
        {
            get
            {
                return _textToAdd;
            }
            set
            {
                _widget.Data.Text = "";
                _charIndex = 0;
                _textToAdd = value;
            }
        }
        
        private int _charIndex;
        private string _textToAdd;

        public LabelCharAdder(Label label, double intervalInMilliseconds)
            : base(label, intervalInMilliseconds) 
        {
        }

        protected override void Update()
        {
            if (string.IsNullOrEmpty(TextToAdd) 
                || _charIndex >= TextToAdd.Length)
            {
                return;
            }

            StringBuilder stringBuilder = new StringBuilder(_widget.Data.Text);
            stringBuilder.Append(TextToAdd[_charIndex]);

            _widget.Data.Text = stringBuilder.ToString();
            _charIndex++;
        }
    }
}
