using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObject.ModulePrime
{
    public class CustomerDal
    {
        public static CustomerDTO GetItem(string strUserName, string strUserPassword)
        {
            var user = FakeUsers.SingleOrDefault(x => x.UserName == strUserName && x.UserPassword == strUserPassword);
            
            return user;
        }


        private static List<CustomerDTO> FakeUsers = new List<CustomerDTO>
        {
            new CustomerDTO { Id = 0, UserName = "test", UserPassword = "test", FirstName = "Test", LastName = "User" },
            new CustomerDTO { Id = 1, UserName = "test1", UserPassword = "test1", FirstName = "Test1", LastName = "User1" },
            new CustomerDTO { Id = 2, UserName = "test2", UserPassword = "test2", FirstName = "Test2", LastName = "User2" },
            new CustomerDTO { Id = 3, UserName = "test3", UserPassword = "test3", FirstName = "Test3", LastName = "User3" },
            new CustomerDTO { Id = 4, UserName = "test4", UserPassword = "test4", FirstName = "Test4", LastName = "User4" },
            new CustomerDTO { Id = 5, UserName = "test5", UserPassword = "test5", FirstName = "Test5", LastName = "User5" },
            new CustomerDTO { Id = 6, UserName = "test6", UserPassword = "test6", FirstName = "Test6", LastName = "User6" },
            new CustomerDTO { Id = 7, UserName = "test7", UserPassword = "test7", FirstName = "Test7", LastName = "User7" },
            new CustomerDTO { Id = 8, UserName = "test8", UserPassword = "test8", FirstName = "Test8", LastName = "User8" },
            new CustomerDTO { Id = 9, UserName = "test9", UserPassword = "test9", FirstName = "Test9", LastName = "User9" }
        };

    }
}
