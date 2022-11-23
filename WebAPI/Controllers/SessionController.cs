using AutoMapper;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IServiceSession _IServiceSession;

        public SessionController(IMapper IMapper, IServiceSession IServiceSession)
        {
            _IMapper = IMapper;
            _IServiceSession = IServiceSession;
        }

        [Authorize]
        [HttpPost("/api/add-session")]
        public async Task<IResult> Addsession(SessionViewModel session)
        {
            var sesssionMap = _IMapper.Map<Session>(session);
            var verify = _IServiceSession.VerifyMovie(sesssionMap).Result;

            if (verify == null)
                return Results.BadRequest("Filme não encontrado");

            var success = await _IServiceSession.AddSession(sesssionMap);

            if (success == null)
                return Results.BadRequest("Não cadastrado. Horário reservado.");

            return Results.Ok(sesssionMap);
        }

        [Authorize]
        [HttpPut("/api/update-session/{id:int}")]
        public async Task<IResult> Updatesession(SessionViewModel session, int id)
        {
            var sessionMap = _IMapper.Map<Session>(session);

            await _IServiceSession.UpdateSession(sessionMap, id);

            if (sessionMap == null)
                return Results.BadRequest("Não foi possível atualizar.");

            return Results.Ok(sessionMap);
        }

        [Authorize]
        [HttpDelete("/api/delete-session/{id:int}")]
        public async Task<IResult> Deletesession(int id)
        {
            var success = await _IServiceSession.RemoveSession(id);

            if (success == null)
                return Results.BadRequest("Agendado para os próximos 10 dias.");

            return Results.Ok(success);
        }

        [Authorize]
        [HttpGet("/api/get-session/{id:int}")]
        public async Task<IResult> GetsessionById(int id)
        {
            var session = await _IServiceSession.GetSession(id);
            var sessionMap = _IMapper.Map<SessionViewModel>(session);

            if (session == null)
                return Results.BadRequest("Sessão não encontrada.");

            return Results.Ok(sessionMap);
        }

        [Authorize]
        [HttpGet("/api/get-session-all")]
        public async Task<IResult> GetAllsession()
        {
            var sessionList = await _IServiceSession.GetAllSession();
            var sessionMap = _IMapper.Map<List<SessionViewModel>>(sessionList);

            return Results.Ok(sessionMap);
        }

        [Authorize]
        [HttpGet("/api/get-sessions-movie/{id:int}")]
        public async Task<IResult> GetAllsessionByMovieID(int id)
        {
            var sessionList = await _IServiceSession.GetSessionsByMovieId(id);
            var sessionMap = _IMapper.Map<List<SessionViewModel>>(sessionList);

            return Results.Ok(sessionMap);
        }
    }
}