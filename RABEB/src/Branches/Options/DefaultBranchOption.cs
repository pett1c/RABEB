using Newtonsoft.Json;

namespace RABEB
{
    internal class DefaultBranchOption : BranchOption
    {
        [JsonProperty] private string _nextBranchName;

        public DefaultBranchOption(string text, string nextBranchName)
            : base(text)
        {
            _nextBranchName = nextBranchName;
        }

        public override string GetNextBranchName()
        {
            return _nextBranchName;
        }
    }
}
