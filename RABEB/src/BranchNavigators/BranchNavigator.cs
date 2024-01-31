using System.Linq;

namespace RABEB
{
    internal class BranchNavigator
    {
        public IBranchData Branch => _branch;

        private Branch[] _branches;
        private Branch _branch;

        public BranchNavigator(Branch[] branches, Branch initialBranch) 
        {
            _branches = branches;
            _branch = initialBranch;
        }

        public void Next(int optionIndex) 
        {
            string nextBranchName = _branch.GetNextBranchName(optionIndex);
            _branch = _branches.Where(branch => (branch.Name == nextBranchName)).FirstOrDefault();
        }
    }
}
