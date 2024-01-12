using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryApi.Models;
using LibraryApi.Extensions;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDTO>>> GetLoans()
        {
            var LoanDTOs = new List<LoanDTO>();
            var loans = await _context.Loans
                .Include(l => l.Member)
                .Include(l => l.Book)
                .AsNoTracking()
                .ToListAsync();

            foreach (var l in loans)
                LoanDTOs.Add(l.LoanToDTO());

            return LoanDTOs;
        }

        //Add GET for active loans only
        //Add Method to return loan

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDTO>> GetLoan(int id)
        {
            var loan = await _context.Loans
                .Include(l => l.Member)
                .Include(l => l.Book)
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);

            if (loan == null)
            {
                return NotFound();
            }

            return loan.LoanToDTO();
        }

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(CreateLoanDTO loanDTO)
        {
            var loan = loanDTO.CreateLoanFromDTO(_context);

            if (loan == null)
            {
                return BadRequest();
            }

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.Id }, loan.LoanToDTO());
        }

        //PATCH: api/Loans/return/5
        [HttpPatch("return/{id}")]
        public async Task<IActionResult> ReturnLoan(int id)
        {
            var loan = await _context.Loans
                .Include(l => l.Book)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (loan == null)
            {
                return BadRequest();
            }

            loan.EndLoan();

            _context.Entry(loan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
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

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.Id == id);
        }
    }
}
