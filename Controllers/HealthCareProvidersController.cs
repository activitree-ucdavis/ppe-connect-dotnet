using System.Collections.Generic;
using HackCOVID19.Models;
using HackCOVID19.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackCOVID19.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCareProvidersController : ControllerBase
    {
        private readonly HealthCareProviderService _healthCareProviderService;

        public HealthCareProvidersController(HealthCareProviderService healthCareProviderService)
        {
            _healthCareProviderService = healthCareProviderService;
        }

        [HttpGet]
        public ActionResult<List<HealthCareProvider>> Get() =>
            _healthCareProviderService.Get();

        [HttpGet("{id:length(24)}", Name = "GetHealthCareProvider")]
        public ActionResult<HealthCareProvider> Get(string id)
        {
            var healthCareProvider = _healthCareProviderService.Get(id);

            if (healthCareProvider == null)
            {
                return NotFound();
            }

            return healthCareProvider;
        }

        [HttpPost]
        public ActionResult<HealthCareProvider> Create(HealthCareProvider healthCareProvider)
        {
            _healthCareProviderService.Create(healthCareProvider);

            return CreatedAtRoute("GetHealthCareProvider", new { id = healthCareProvider.Id.ToString() }, healthCareProvider);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, HealthCareProvider healthCareProviderIn)
        {
            var healthCareProvider = _healthCareProviderService.Get(id);

            if (healthCareProvider == null)
            {
                return NotFound();
            }

            _healthCareProviderService.Update(id, healthCareProviderIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var healthCareProvider = _healthCareProviderService.Get(id);

            if (healthCareProvider == null)
            {
                return NotFound();
            }

            _healthCareProviderService.Remove(healthCareProvider.Id);

            return NoContent();
        }
    }
}