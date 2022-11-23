using Entities.Entities;

namespace Api.Tests.Entities
{
    public class SessionEntitiesTest
    {
        private readonly DateTime Date = DateTime.Now;
        private readonly Session Session = new Session(1, DateTime.Now, DateTime.Now.AddHours(2), 10, "2d", "original", 1, 1);
        private readonly Session SessionTwo = new Session(2, DateTime.Now.AddHours(2), DateTime.Now.AddHours(4), 10, "2d", "original", 1, 1);
        private readonly List<Session> list = new List<Session>();

        [Fact]
        public void CheckSessions_WhithTimeClash_ReturnsTrue()
        {
            // Arrange

            list.Add(Session);
            list.Add(SessionTwo);
            var SessionTimeClash = new Session(3, Date.AddHours(1), Date.AddHours(3), 10, "2d", "original", 1, 1);

            // Act
            var result = SessionTimeClash.CheckSessions(list, SessionTimeClash);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSessions_WhithTimeClash_ReturnsFalse()
        {
            // Arrange

            list.Add(Session);
            list.Add(SessionTwo);
            var SessionTimeClash = new Session(3, Date.AddHours(5), Date.AddHours(6), 10, "2d", "original", 1, 1);

            // Act
            var result = SessionTimeClash.CheckSessions(list, SessionTimeClash);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSessions_SessionBetweenTenDays_ReturnsTrue()
        {
            // Arrange

            var Session = new Session(1, Date.AddDays(2), Date.AddDays(2).AddHours(2), 10, "2d", "original", 1, 1);

            // Act
            var result = Session.CheckForDelete(Session);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSessions_SessionNotBetweenTenDays_ReturnsFalse()
        {
            // Arrange

            var Session = new Session(1, Date.AddDays(12), Date.AddDays(12).AddHours(2), 10, "2d", "original", 1, 1);

            // Act
            var result = Session.CheckForDelete(Session);
            // Assert
            Assert.False(result);
        }
    }
}