using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaxJar.Api.Interfaces;
using TaxJar.Api.Models;
using TaxJar.Api.Models.Requests;
using TaxJar.Api.Models.Responses;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxJar.Api.Controllers
{
    [Route("api/[controller]")]
    public class TaxController : Controller
    {
        private readonly ITaxService taxService;
        private IMapper mapper;

        public TaxController(ITaxService taxService, IMapper mapper)
        {
            this.taxService = taxService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] TaxRateRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Zip))
                {
                    return BadRequest("Zip is required");
                }

                if (string.IsNullOrEmpty(request.Country))
                {
                    return BadRequest("Country is required");
                }

                TaxRateModel taxRate = await taxService.GetTaxRates(request);

                return Ok(JsonConvert.SerializeObject(mapper.Map<TaxRateResponse>(taxRate)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaxCalculationRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid Request");
                }

                if (string.IsNullOrEmpty(request.ClientId))
                {
                    return BadRequest("ClientId is Required");
                }

                if (string.IsNullOrEmpty(request.ToCountry))
                {
                    return BadRequest("Ship to Country is Required");
                }

                if (string.IsNullOrEmpty(request.ToState))
                {
                    return BadRequest("Ship to State is Required");
                }

                if (request.Shipping == 0)
                {
                    return BadRequest("Total amount to Ship is Required");
                }

                TaxJarCalculateResponse calculation = await taxService.Calculate(request);

                return Ok(JsonConvert.SerializeObject(calculation));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
