using LibManage.Enums;
using LibManage.Models;

namespace LibManage.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsync(Guid id);
        Task<Loan> CreateAsync(Loan loan);
        Task UpdateAsync();
        Task DeleteAsync();
        Task IsBookAvaliable();
        Task ReturnLoan(Guid loanId, ELoanStatus loanStatus);

    }
}
