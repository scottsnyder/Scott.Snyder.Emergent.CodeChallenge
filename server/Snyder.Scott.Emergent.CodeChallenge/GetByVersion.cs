using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Semver;
using Snyder.Scott.Emergent.CodeChallenge.Core;
using Snyder.Scott.Emergent.CodeChallenge.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snyder.Scott.Emergent.CodeChallenge
{
    public class GetByVersion
    {
        private readonly IVersionService _versionService;
        private readonly ILogger<GetByVersion> _logger;

        public GetByVersion(IVersionService versionService, ILogger<GetByVersion> logger)
        {
            _versionService = versionService;
            _logger = logger;
        }

        [FunctionName("GetByVersion")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "version/{version}")] HttpRequest req,
            string version)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            IEnumerable<Software> software;
            try
            {
                software = _versionService.GetSoftwareWithGreaterVersion(version);
            }
            catch (ArgumentException aex)
            {
                _logger.LogInformation($"ArgumentException calling GetSoftwareWithGreaterVersion with Message: {aex.Message}");
                return new UnprocessableEntityObjectResult($"The value received for version is not valid for processing. Value: {version}");
            }

            return new OkObjectResult(software);
        }
    }
}
