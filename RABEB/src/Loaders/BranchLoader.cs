using System.IO;

namespace RABEB
{
    internal class BranchLoader : ILoader<Branch[]>
    {
        private string _globalPath => Path.Combine(Directory.GetCurrentDirectory(), _relativePath);
        private string _relativePath => "branches.json";

        private ISerializer _serializer = new JsonSerializer();

        public Branch[] Load()
        {
            string serializedBranches = File.ReadAllText(_globalPath);
            Branch[] branches = _serializer.Deserialize<Branch[]>(serializedBranches);

            return branches;
        }
    }
}
