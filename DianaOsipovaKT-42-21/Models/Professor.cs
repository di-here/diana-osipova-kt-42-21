namespace DianaOsipovaKT_42_21.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public int Age { get; set; }

        public bool IsValidAge()
        {
            if (Age >= 16 && Age <= 65)
            {
                return true;
            }
            return false;
        }
    }
}
