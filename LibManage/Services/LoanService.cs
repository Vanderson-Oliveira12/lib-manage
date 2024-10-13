using LibManage.Enums;
using LibManage.Models;
using LibManage.Repositories.Interfaces;
using LibManage.Services.Interfaces;

namespace LibManage.Services
{
    public class LoanService : ILoanService
    {

        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ApiResponse<IEnumerable<Loan>>> GetAllLoansAsync()
        {

            var loans = await _loanRepository.GetAllAsync();

            return new ApiResponse<IEnumerable<Loan>>().Success(data: loans);
        }

        public async Task<ApiResponse<Loan?>> GetLoanByIdAsync(Guid id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            
            return new ApiResponse<Loan?>().Success(data: loan);
        }

        public async Task<ApiResponse<Loan>> CreateLoanAsync(Loan loan)
        {

          var loanCreated = await _loanRepository.CreateAsync(loan);

          return new ApiResponse<Loan>().Success(data: loanCreated);
        }

        public Task IsLoanAvaliableAsync()
        {
            throw new NotImplementedException();
        }


        public Task RemoveLoanAsync()
        {
            throw new NotImplementedException();
        }

        public Task ReturnLoanAsync(Guid loanId, ELoanStatus loanStatus)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLoanAsync()
        {
            throw new NotImplementedException();
        }
    }
}
