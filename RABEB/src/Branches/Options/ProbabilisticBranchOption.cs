using Newtonsoft.Json;
using System.Linq;

namespace RABEB
{
    [JsonObject(MemberSerialization.OptIn)]
    internal struct BranchInfo 
    {
        [JsonProperty] public string Name { get; private set; }
        [JsonProperty] public int Weight { get; private set; }

        public BranchInfo(string name, int weight) 
        {
            Name = name;
            Weight = weight;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class ProbabilisticBranchOption : BranchOption
    {
        [JsonProperty] private BranchInfo[] _nextPossibleBranchInfos;

        public ProbabilisticBranchOption(string text, BranchInfo[] nextPossibleBranchInfos)
            : base(text)
        {
            _nextPossibleBranchInfos = nextPossibleBranchInfos;
        }

        public override string GetNextBranchName()
        {
            int[] weights = _nextPossibleBranchInfos.Select(branchInfo => branchInfo.Weight).ToArray();
            int? index = RandomHelper.GetRandomIndex(weights);
            
            return _nextPossibleBranchInfos.ElementAtOrDefault(index).Name;
        }
    }
}
