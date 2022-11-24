using Entities.Entities;

namespace Api.Tests.Entities
{
    public class SessionEntitiesTest
    {
        private readonly DateTime date = DateTime.Now;
        private readonly Session session = new Session(1, DateTime.Now, DateTime.Now.AddHours(2), 10, "2d", "original", 1, 1);
        private readonly Session sessionTwo = new Session(2, DateTime.Now.AddHours(2), DateTime.Now.AddHours(4), 10, "2d", "original", 1, 1);
        private readonly List<Session> list = new List<Session>();

        [Fact]
        public void CheckSessions_WhithTimeClash_ReturnsTrue()
        {
            // Arrange

            list.Add(session);
            list.Add(sessionTwo);
            var SessionTimeClash = new Session(3, date.AddHours(1), date.AddHours(3), 10, "2d", "original", 1, 1);

            // Act
            var result = SessionTimeClash.CheckSessions(list, SessionTimeClash);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSessions_WhithTimeClash_ReturnsFalse()
        {
            // Arrange

            list.Add(session);
            list.Add(sessionTwo);
            var SessionTimeClash = new Session(3, date.AddHours(5), date.AddHours(6), 10, "2d", "original", 1, 1);

            // Act
            var result = SessionTimeClash.CheckSessions(list, SessionTimeClash);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSessions_SessionBetweenTenDays_ReturnsTrue()
        {
            // Arrange

            var Session = new Session(1, date.AddDays(2), date.AddDays(2).AddHours(2), 10, "2d", "original", 1, 1);

            // Act
            var result = Session.CheckForDelete(Session);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSessions_SessionNotBetweenTenDays_ReturnsFalse()
        {
            // Arrange

            var Session = new Session(1, date.AddDays(12), date.AddDays(12).AddHours(2), 10, "2d", "original", 1, 1);

            // Act
            var result = Session.CheckForDelete(Session);
            // Assert
            Assert.False(result);
        }
    }
}