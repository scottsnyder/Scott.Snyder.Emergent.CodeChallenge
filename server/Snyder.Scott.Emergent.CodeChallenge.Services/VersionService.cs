using Microsoft.Extensions.Logging;
using Semver;
using Snyder.Scott.Emergent.CodeChallenge.Core;
using Snyder.Scott.Emergent.CodeChallenge.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Snyder.Scott.Emergent.CodeChallenge.Services
{
    public class VersionService : IVersionService
    {
        private readonly ILogger<VersionService> _logger;

        public VersionService(ILogger<VersionService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Software> GetSoftwareWithGreaterVersion(string version)
        {
            if (!SemVersion.TryParse(version, out var parsedVersion))
            {
                _logger.LogInformation($"TryParse failure on input version value: {version}");
                throw new ArgumentException($"The value received for version is not valid for processing. Value: {version}");
            }

            return GetSoftwareWithGreaterVersion(parsedVersion);
        }

        public IEnumerable<Software> GetSoftwareWithGreaterVersion(SemVersion version)
        {
            var softwareResult = new List<Software>();

            var allSoftware = SoftwareManager.GetAllSoftware();
            foreach (var software in allSoftware)
            {
                if (!SemVersion.TryParse(software.Version, out var parsedVersion))
                {
                    _logger.LogWarning($"Unable to parse version from source date.{Environment.NewLine}\tName: {software.Name};{Environment.NewLine}\tVersion: {software.Version}");
                    continue;
                }

                if (parsedVersion > version)
                {
                    softwareResult.Add(software);
                }
            }

            return softwareResult;
        }
    }
}
