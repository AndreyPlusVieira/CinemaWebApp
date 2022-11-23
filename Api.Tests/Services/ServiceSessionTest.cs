using Domain.Interfaces;
using Domain.Services;
using Entities.Entities;
using NSubstitute.ReturnsExtensions;

namespace Api.Tests.Services;

public class ServiceSessionTest
{
    private readonly IMovie _IMovie;
    private readonly ISessions _ISession;

    private readonly ServiceSession _ServiceSession;

    public ServiceSessionTest()
    {
        _IMovie = Substitute.For<IMovie>();
        _ISession = Substitute.For<ISessions>();

        _ServiceSession = new ServiceSession(_ISession, _IMovie);
    }

    [Fact]
    public async Task GetSession_WhithValidId_ReturnsSession()
    {
        // Arrange
        var movie = new Movie(2, "Title Two", "Description", "image", 120, true);
        var session = new Session(1, DateTime.Now, DateTime.Now.AddHours(2), 10, "2d", "original", 2, 2);

        var id = 3;

        _IMovie.GetEntityById(id).Returns(movie);
        _ISession.GetEntityById(id).Returns(session);

        // Act
        var results = await _ServiceSession.GetSession(id);

        // Assert
        Assert.Equal(results, session);
    }

    [Fact]
    public async Task GetSession_WhithInValidId_ReturnsNull()
    {
        // Arrange
        var movie = new Movie(2, "Title Two", "Description", "image", 120, true);
        var session = new Session(1, DateTime.Now, DateTime.Now.AddHours(2), 10, "2d", "original", 2, 2);
        var id = 3;

        _ISession.GetEntityById(id).ReturnsNull();

        // Act
        var results = await _ServiceSession.GetSession(id);

        // Assert
        Assert.Null(results);
    }

    [Fact]
    public async Task GetAllSession_WhithValidRequest_ReturnsSessionList()
    {
        // Arrange
        var session = new Session(1, DateTime.Now, DateTime.Now.AddHours(2), 10, "2d", "original", 2, 2);
        var sessionList = new List<Session>();
        sessionList.Add(session);

        _ISession.List().Returns(sessionList);

        // Act
        var results = await _ServiceSession.GetAllSession();

        // Assert
        Assert.Equal(results, sessionList);
    }

    [Fact]
    public async Task GetAllSession_WhithInValid_Returnsnull()
    {
        // Arrange

        _ISession.List().ReturnsNull();

        // Act
        var results = await _ServiceSession.GetAllSession();

        // Assert
        Assert.Null(results);
    }

    [Fact]
    public async Task AddSession_WhithValidRequest_ReturnsSession()
    {
        // Arrange
        var movie = new Movie(2, "Title Two", "Description", "image", 120, true);
        var session = new Session(1, DateTime.Now, DateTime.Now.AddHours(2), 10, "2d", "original", 2, 2);
        var sessionTwo = new Session(3, DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(2), 10, "2d", "original", 2, 2);

        var sessionList = new List<Session>();
        sessionList.Add(sessionTwo);

        _IMovie.GetEntityById(movie.Id).Returns(movie);
        _ISession.ListByMovieAndRoom(session).Returns(sessionList);

        // Act

        var results = await _ServiceSession.AddSession(session);

        // Assert

        Assert.Equal(results, session);
    }
    
    [Fact]
    public async Task AddSession_WhithNullRequest_ReturnsNull()
    {
        // Arrange
        var movie = new Movie(2, "Title Two", "Description", "image", 120, true);
        var session = new Session(1, DateTime.Now, DateTime.Now.AddHours(2), 10, "2d", "original", 2, 2);
        var sessionList = new List<Session>();
        sessionList.Add(session);

        _IMovie.GetEntityById(movie.Id).Returns(movie);
        _ISession.ListByMovieAndRoom(session).ReturnsNull();

        // Act

        var results = await _ServiceSession.AddSession(session);

        // Assert

        Assert.Null(results);
    }

    [Fact]
    public async Task RemoveSession_WhithValidRequest_ReturnsSession()
    {
        // Arrange
        var session = new Session(1, DateTime.Now, DateTime.Now.AddHours(2), 10, "2d", "original", 2, 2);
        var id = 2;

        _ISession.GetEntityById(id).Returns(session);

        // Act

        var results = await _ServiceSession.RemoveSession(id);

        // Assert

        Assert.Equal(results, session);
    }

    [Fact]
    public async Task RemoveSession_WhithSessionLessThanTen_ReturnsNull()
    {
        // Arrange
        var session = new Session(1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(2), 10, "2d", "original", 2, 2);

        var id = 2;

        _ISession.GetEntityById(id).Returns(session);

        // Act

        var results = await _ServiceSession.RemoveSession(id);

        // Assert

        Assert.Null(results);
    }

    [Fact]
    public async Task UpdateSession_WhithSessionRequest_ReturnsSession()
    {
        // Arrange
        var id = 2;
        var session = new Session(1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(2), 10, "2d", "original", 2, 2);
        var sessionTwo = new Session(3, DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(2), 10, "2d", "original", 2, 2);

        var movie = new Movie(2, "Title Two", "Description", "image", 2, true);



        var sessionList = new List<Session>();
        sessionList.Add(sessionTwo);

        _IMovie.GetEntityById(id).Returns(movie);
        _ISession.ListByMovieAndRoom(session).Returns(sessionList);

        // Act

        var results = await _ServiceSession.UpdateSession(session, id);

        // Assert

        Assert.Equal(results, session);
    }

    [Fact]
    public async Task UpdateSession_WhithNullRequest_ReturnsNull()
    {
        // Arrange
        var id = 2;
        var session = new Session(1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(2), 10, "2d", "original", 2, 2);
        var movie = new Movie(2, "Title Two", "Description", "image", 120, true);
        var sessionList = new List<Session>();
        sessionList.Add(session);

        _IMovie.GetEntityById(id).Returns(movie);
        _ISession.ListByMovieAndRoom(session).ReturnsNull();

        // Act

        var results = await _ServiceSession.UpdateSession(session, id);

        // Assert

        Assert.Null(results);
    }
}