using LibManage.Enums;
using LibManage.Models;

namespace LibManage.Services.Interfaces
{
    public interface ILoanService
    {
        Task<ApiResponse<IEnumerable<Loan>>> GetAllLoansAsync();
        Task<ApiResponse<Loan?>> GetLoanByIdAsync(Guid id);
        Task<ApiResponse<Loan>> CreateLoanAsync(Loan loan);
        Task ReturnLoanAsync(Guid loanId, ELoanStatus loanStatus);
        Task UpdateLoanAsync();
        Task RemoveLoanAsync();
        Task IsLoanAvaliableAsync();
    }
}
