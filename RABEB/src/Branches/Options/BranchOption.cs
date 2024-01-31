using Newtonsoft.Json;

namespace RABEB
{
    [JsonObject(MemberSerialization.OptIn)]
    internal abstract class BranchOption
    {
        [JsonProperty] public string Text { get; private set; }

        protected BranchOption(string text)
        {
            Text = text;
        }

        public abstract string GetNextBranchName();
    }
}
