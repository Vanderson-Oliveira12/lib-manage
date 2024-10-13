using LibManage.Models;
using LibManage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibManage.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoanController : ControllerBase
    {

        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var a = new DateTime();

            Console.WriteLine(DateTime.Now);

            var response = await _loanService.GetAllLoansAsync();

            if ( response.IsSucceeded ) { 
                return Ok(response);
            }
            return NotFound();
        }

    }

}
