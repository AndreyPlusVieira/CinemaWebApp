using Domain.Interfaces;
using Domain.Services;
using Entities.Entities;
using NSubstitute.ReturnsExtensions;

namespace Api.Tests.Services;

public class ServiceMovieTest
{
    private readonly IMovie _Imovie;
    private readonly ServiceMovie _serviceMovie;
    private Movie _movie;

    public ServiceMovieTest()
    {
        _Imovie = Substitute.For<IMovie>();
        _serviceMovie = new ServiceMovie(_Imovie);
        _movie = new Movie(2, "title", "Description", "image", 120, true);
    }

    [Fact]
    public async Task AddMovie_WhithValidMovie_ReturnsMovie()
    {
        // Arrange
        var movie = new Movie(2, "Title Two", "Description", "image", 120, true);

        _Imovie.CheckIfMovieTitleExists(movie).Returns(false);
        _Imovie.Add(movie).Returns(Task.FromResult(movie));

        // Act
        var result = await _serviceMovie.AddMovie(movie);

        // Assert
        Assert.Equal(movie, result);
    }

    [Fact]
    public async Task AddMovie_WhithInValidMovie_Returnsnull()
    {
        // Arrange
        var movie = new Movie(2, "Title", "Description", "image", 120, true);

        _Imovie.CheckIfMovieTitleExists(movie).Returns(true);
        _Imovie.Add(movie).Returns(Task.FromResult(movie));

        // Act
        var result = await _serviceMovie.AddMovie(movie);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task AddMovie_WhithRepeatedTitleUpperCase_Returnsnull()
    {
        // Arrange
        var movie = new Movie(2, "Title", "Description", "image", 120, true);
        var movieTwo = new Movie(2, "title", "Description", "image", 120, true);

        _Imovie.CheckIfMovieTitleExists(movie).Returns(true);
        _Imovie.Add(movie).Returns(Task.FromResult(movie));

        // Act
        var result = await _serviceMovie.AddMovie(movie);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task AddMovie_WhithRepeatedTitleSpaceBetweenWords_Returnsnull()
    {
        // Arrange
        var movie = new Movie(2, "Title One", "Description", "image", 120, true);
        var movieTwo = new Movie(2, "title one", "Description", "image", 120, true);

        _Imovie.CheckIfMovieTitleExists(movie).Returns(true);
        _Imovie.Add(movie).Returns(Task.FromResult(movie));

        // Act
        var result = await _serviceMovie.AddMovie(movie);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task RemoveMovie_WhithValidId_ReturnsMovie()
    {
        // Arrange
        var id = 3;
        var movie = new Movie(2, "Title", "Description", "image", 120, true);
        var sessionListForRemove = new List<Session>();

        _Imovie.GetEntityById(id).Returns(movie);
        _Imovie.ListSessionsByMovie(movie).Returns(sessionListForRemove);

        _Imovie.Delete(movie).Returns(Task.FromResult(movie));

        // Act
        var result = await _serviceMovie.DeleteMovie(id);

        // Assert
        Assert.Equal(result, movie);
    }

    [Fact]
    public async Task UpdateMovie_WhithValidMovie_ReturnsMovie()
    {
        // Arrange
        var movie = new Movie(2, "Title", "Description", "image", 120, true);
        var id = 3;

        _Imovie.GetEntityById(id).Returns(movie);
        _Imovie.CheckIfMovieTitleExists(movie).Returns(false);

        _Imovie.Update(movie).Returns(Task.FromResult(movie));

        // Act
        var result = await _serviceMovie.UpdateMovie(movie, id);

        // Assert
        Assert.Equal(result, movie);
    }

    [Fact]
    public async Task UpdateMovie_WhithInValidMovie_ReturnsNull()
    {
        // Arrange
        var movie = new Movie(2, "Title Two", "Description", "image", 120, true);

        var id = 3;

        _Imovie.GetEntityById(id).Returns(_movie);
        _Imovie.CheckIfMovieTitleExists(movie).Returns(true);

        _Imovie.Update(movie).Returns(Task.FromResult(movie));



        // Act
        var result = await _serviceMovie.UpdateMovie(movie, id);

        // Assert
        Assert.Null(result);
    }

  



    [Fact]
    public async Task GetMovie_WhithValidId_ReturnsMovie()
    {
        // Arrange
        var movie = new Movie(2, "Title Two", "Description", "image", 120, true);

        var id = 3;

        _Imovie.GetEntityById(id).Returns(movie);

        // Act
        var result = await _serviceMovie.GetMovie(id);

        // Assert
        Assert.Equal(result, movie);
    }

    [Fact]
    public async Task GetMovie_WhithInValidId_ReturnsNull()
    {
        // Arrange
        var movie = new Movie(2, "Title Two", "Description", "image", 120, true);

        var id = 3;

        _Imovie.GetEntityById(Arg.Any<int>()).ReturnsNull();

        // Act
        var result = await _serviceMovie.GetMovie(id);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetAllMovie_ReturnsListMovies()
    {
        // Arrange
        var movieList = new List<Movie>();

        _Imovie.List().Returns(movieList);

        // Act
        var result = await _serviceMovie.GetAllMovie();

        // Assert
        Assert.Equal(result, movieList);
    }

    [Fact]
    public async Task GetAllMovie_WhenDontFind_ReturnsNull()
    {
        // Arrange

        _Imovie.List().ReturnsNull();

        // Act
        var result = await _serviceMovie.GetAllMovie();

        // Assert
        Assert.Null(result);
    }
}