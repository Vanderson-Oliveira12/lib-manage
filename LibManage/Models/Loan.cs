
using LibManage.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibManage.Models
{
    public class Loan
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime LoanDate { get; set; } = DateTime.Now; //Data em que o empréstimo foi realizado. 
        public DateTime ReturnDate {  get; set; } // Data prevista para a devolução do livro.
        public DateTime ActualReturnDate { get; set; } // Data efetiva de devolução do livro(se já devolvido).

        public ELoanStatus Status { get; set; } = ELoanStatus.ACTIVE;

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public Guid BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

    }
}
