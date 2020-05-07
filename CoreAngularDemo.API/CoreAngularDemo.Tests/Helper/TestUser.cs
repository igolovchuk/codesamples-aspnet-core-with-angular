using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.Tests
{
    /// <summary>
    /// User DTO for Tests.
    /// </summary>
    public class TestUser : UserDTO
    {
        public TestUser()
        {
            UserName = "testAdmin";
            Password = "HelloWorld123@";
            FirstName = "test";
            MiddleName = "Petro";
            LastName = "testovych";
            Role = new RoleDTO
            {
                Name = "ADMIN",
                TransName = "Адмін"
            };
            Email = "shewchenkoandriy@gmail.com";
        }
    }
}
