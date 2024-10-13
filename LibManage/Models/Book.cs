namespace LibManage.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public int Quantity { get; set; } = 0;
        public IEnumerable<Loan> Loans { get; set; } = new List<Loan>();
    }
}
