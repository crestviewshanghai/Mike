using System;

namespace BusinessObject.ModulePrime
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string Token { get; set; }
    }
}
