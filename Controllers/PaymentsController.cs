using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crowdfunding_API;
using Crowdfunding_API.Entities;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Crowdfunding_API.DTOs;

namespace Crowdfunding_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<ProjectsController> logger;
        private readonly IMapper mapper;

        public PaymentsController(ApplicationDbContext context, ILogger<ProjectsController> logger,
            IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<List<PaymentDTO>>> GetPayment()
        {

            var payments = await context.Payment.AsNoTracking().ToListAsync();
            var paymentsDTOs = mapper.Map<List<PaymentDTO>>(payments);
            return paymentsDTOs;

           
        }

        // GET: api/Payments/5
        [HttpGet("{id}", Name = "GetPayment")]
        public async Task<ActionResult<PaymentDTO>> GetPayment(int id)
        {
            var payment = await context.Payment.FirstOrDefaultAsync(x => x.Id == id);

            if (payment == null)
            {
                logger.LogWarning($" Payment with id {id} not found");
                return NotFound();
                //throw new ApplicationException();
            }

            return mapper.Map<PaymentDTO>(payment);
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            context.Entry(payment).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult> PostPayment([FromBody] PaymentCreationDTO paymentCreation)
        {
            var payment = mapper.Map<Payment>(paymentCreation);
            context.Add(payment);
            await context.SaveChangesAsync();
            var paymentDTO = mapper.Map<PaymentDTO>(payment);

            return new CreatedAtRouteResult("GetPayment", new { id = paymentDTO.Id }, paymentDTO);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Payment>> DeletePayment(int id)
        {
            var payment = await context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            context.Payment.Remove(payment);
            await context.SaveChangesAsync();

            return payment;
        }

        private bool PaymentExists(int id)
        {
            return context.Payment.Any(e => e.Id == id);
        }
    }
}
