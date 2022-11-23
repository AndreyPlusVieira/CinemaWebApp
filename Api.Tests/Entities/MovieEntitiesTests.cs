using Entities.Entities;

namespace Api.Tests.Entities
{
    public class MovieEntitiesTests
    {
        private readonly DateTime Date = DateTime.Now;
        private readonly List<Session> list = new List<Session>();
        private readonly Movie movie = new Movie(2, "Title", "Description", "image", 120, true);

        [Fact]
        public void CheckSessionsMovie_WhithFutureSession_ReturnsTrue()
        {
            // Arrange

            var futureDate = DateTime.Now.AddDays(3);
            var movie = new Movie(2, "Title", "Description", "image", 120, true);

            var futureSession = new Session(3, futureDate, futureDate.AddHours(2), 10, "2d", "original", 2, 2);
            var futureSessionTwo = new Session(4, futureDate, futureDate.AddHours(2), 10, "2d", "original", 2, 2);

            list.Add(futureSession);
            list.Add(futureSessionTwo);

            // Act
            var result = movie.CheckSessionsMovies(list);

            // Assert

            Assert.True(result);
        }

        [Fact]
        public void CheckSessionsMovie_WhithFutureSession_ReturnsFalse()
        {
            // Arrange

            var oldSession = new Session(3, Date.AddDays(-1), Date.AddDays(-1).AddHours(2), 10, "2d", "original", 2, 2);
            var oldSessionTwo = new Session(4, Date.AddDays(-2), Date.AddDays(-2).AddHours(2), 10, "2d", "original", 2, 2);

            list.Add(oldSession);
            list.Add(oldSessionTwo);

            // Act
            var result = movie.CheckSessionsMovies(list);

            // Assert

            Assert.False(result);
        }
    }
}