using DianaOsipovaKT_42_21.Models;

namespace DianaOsipovaKT_42_21.Tests
{
    public class ProfessorTests
    {
        [Fact]
        public void IsValidAge_True()
        {
            var testProfessor = new Professor
            {
                Age = 44
            };


            var result = testProfessor.IsValidAge();
            Assert.True(result);
        }
    }
}


