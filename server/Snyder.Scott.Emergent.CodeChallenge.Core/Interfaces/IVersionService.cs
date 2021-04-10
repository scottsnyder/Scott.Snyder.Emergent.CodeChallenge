using Semver;
using System.Collections.Generic;

namespace Snyder.Scott.Emergent.CodeChallenge.Core.Interfaces
{
    public interface IVersionService
    {
        IEnumerable<Software> GetSoftwareWithGreaterVersion(string version);
        IEnumerable<Software> GetSoftwareWithGreaterVersion(SemVersion version);
    }
}
