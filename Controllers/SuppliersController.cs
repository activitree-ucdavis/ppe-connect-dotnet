using System.Collections.Generic;
using HackCOVID19.Models;
using HackCOVID19.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackCOVID19.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierService _supplierService;

        public SuppliersController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult<List<Supplier>> Get() =>
            _supplierService.Get();

        [HttpGet("{id:length(24)}", Name = "GetSupplier")]
        public ActionResult<Supplier> Get(string id)
        {
            var supplier = _supplierService.Get(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        [HttpPost]
        public ActionResult<Supplier> Create(Supplier supplier)
        {
            _supplierService.Create(supplier);

            return CreatedAtRoute("GetSupplier", new { id = supplier.Id.ToString() }, supplier);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Supplier supplierIn)
        {
            var supplier = _supplierService.Get(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _supplierService.Update(id, supplierIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var supplier = _supplierService.Get(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _supplierService.Remove(supplier.Id);

            return NoContent();
        }
    }
}