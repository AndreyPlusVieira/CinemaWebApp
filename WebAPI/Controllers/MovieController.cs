using AutoMapper;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IServiceMovie _IServiceMovie;
        private readonly IWebHostEnvironment _host;


        public MovieController(IMapper IMapper, IServiceMovie IServiceMovie, IWebHostEnvironment host)
        {
            _IMapper = IMapper;
            _IServiceMovie = IServiceMovie;
            _host = host;
        }

        [Authorize]
        [HttpPost("/api/add-movie")]
        public async Task<IResult> AddMovie(MovieViewModel movie)
        {
            var movieMap = _IMapper.Map<Movie>(movie);
            var success = await _IServiceMovie.AddMovie(movieMap);

            if (success == null)
                return Results.BadRequest("Titulo Duplicado.");

            return Results.Ok(movieMap);
        }

        [Authorize]
        [HttpPut("/api/update-movie/{id:int}")]
        public async Task<IResult> UpdateMovie(MovieViewModel movie, int id)
        {
            var movieMap = _IMapper.Map<Movie>(movie);

            var result = await _IServiceMovie.UpdateMovie(movieMap, id);

            if (result == null)
                return Results.BadRequest("Titulo ja existe");

            return Results.Ok(movieMap);
        }

        [Authorize]
        [HttpDelete("/api/delete-movie/{id:int}")]
        public async Task<IResult> DeleteMovie(int id)
        {
            var success = await _IServiceMovie.DeleteMovie(id);

            if (success == null)
                return Results.BadRequest("Sessões futuras agendadas.");

            return Results.Ok(success);
        }

        [Authorize]
        [HttpGet("/api/get-movie/{id:int}")]
        public async Task<IResult> GetMovieById(int id)
        {
            var movie = await _IServiceMovie.GetMovie(id);
            var movieMap = _IMapper.Map<MovieViewModel>(movie);

            if (movie == null)
                return Results.BadRequest("Filme não encontrado.");

            return Results.Ok(movieMap);
        }

        [Authorize]
        [HttpGet("/api/get-movie-all")]
        public async Task<IResult> GetAllMovie()
        {
            var movieList = await _IServiceMovie.GetAllMovie();
            var movieMap = _IMapper.Map<List<MovieViewModel>>(movieList);

            return Results.Ok(movieMap);
        }

        [HttpPost("/api/upload-image/{id:int}")]

        public async Task<IResult> UploadImage(int id)
        {

            var movie = await _IServiceMovie.GetMovie(id);
            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {
                DeleteImage(movie.Image);
                movie.Image = await SaveImage(file);

            }

            await _IServiceMovie.UpdateMovie(movie, id);


            return Results.Ok(movie);

        }

        [NonAction]
        public void DeleteImage(string imageName)
        {

        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');

            imageName = $"{imageName}{DateTime.UtcNow.ToString("yyyymmddfff")}{Path.GetExtension(imageFile.FileName)}";

            var imagePath = Path.Combine(_host.ContentRootPath, @"Resources/images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

    }
}