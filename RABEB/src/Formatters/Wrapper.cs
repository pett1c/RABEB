namespace RABEB
{
    internal class Wrapper : IFormatter
    {
        private int _maxCharCount;

        public Wrapper(int maxCharCount) 
        {
            _maxCharCount = maxCharCount;
        }

        public string Format(string text)
        {
            if (string.IsNullOrEmpty(text)) 
            {
                return "";
            }

            int charCount = 0;
            string result = "";

            foreach (string word in text.Split(' '))
            {
                charCount += word.Length;
                result += word;

                if (charCount <= _maxCharCount)
                {
                    result += ' ';
                }
                else
                {
                    charCount = 0;
                    result += '\n';
                }
            }

            return result.RemoveFromEnd(1);
        }
    }
}
