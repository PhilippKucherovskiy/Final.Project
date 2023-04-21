
using System;
using Microsoft.VisualStudio.TestPlatform;

namespace SocialNetwork3.Tests
{
    public class Tests
    {
        [TestMethod]
        public void UserService_AddFriend_ShouldAddFriend_WhenValidEmailsProvided()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var userService = new UserService(userRepository.Object);
            var user = new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                Password = "password",
                Friends = new List<User>()
            };
            var friend = new User
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janedoe@example.com",
                Password = "password",
                Friends = new List<User>()
            };
            userRepository.Setup(r => r.GetUserByEmail("janedoe@example.com")).Returns(friend);
            userRepository.Setup(r => r.GetUserById(1)).Returns(user);

            // Act
            userService.AddFriend(user.Email, friend.Email);

            // Assert
            Assert.IsTrue(user.Friends.Contains(friend));
            userRepository.Verify(r => r.Save(), Times.Once);
        }

    }
}

