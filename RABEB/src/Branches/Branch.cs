using Newtonsoft.Json;
using System.Linq;

namespace RABEB
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class Branch : IBranchData
    {
        public string Name => _name;
        public string[] Options => _options.Select(option => option.Text).ToArray();
        public string Text => _text;

        [JsonProperty] private string _name;
        [JsonProperty] private BranchOption[] _options;
        [JsonProperty] private string _text;

        public Branch(string name, string text, BranchOption[] options) 
        {
            _name = name;
            _options = options;
            _text = text;
        }

        public string GetNextBranchName(int optionIndex) 
        {
            return _options[optionIndex].GetNextBranchName();
        }
    }
}
