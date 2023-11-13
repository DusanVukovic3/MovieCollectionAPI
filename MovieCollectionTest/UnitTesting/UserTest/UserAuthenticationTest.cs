using Moq;
using Movie_Collection.Authentication.Model;
using Movie_Collection.Authentication.Repository;
using Movie_Collection.Authentication.Service;
using Movie_Collection.Movies.Exceptions;

namespace MovieCollectionTest.UnitTesting.UserTest
{
    public class UserAuthenticationTest
    {
        [Fact]
        public void IsEmailUnique_ReturnsFalseWhenEmailIsNotUnique()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<string>())).Returns(new User());

            var userService = new UserService(userRepositoryMock.Object);

            var result = userService.IsEmailUnique("existing@example.com");

            Assert.False(result);
        }

        [Fact]
        public void IsUsernameUnique_ReturnsTrueWhenUsernameIsUnique()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetByUsername(It.IsAny<string>())).Throws(new NotFoundException());

            var userService = new UserService(userRepositoryMock.Object);

            var result = userService.IsUsernameUnique("testuser");

            Assert.True(result);
        }

        [Fact]
        public void CreatePasswordHash_ReturnsValidHashAndSalt()
        {
            var userService = new UserService();

            userService.CreatePasswordHash("password123", out var passwordHash, out var passwordSalt);

            Assert.NotNull(passwordHash);
            Assert.NotNull(passwordSalt);
            Assert.NotEmpty(passwordHash);
            Assert.NotEmpty(passwordSalt);
        }

    }
}
