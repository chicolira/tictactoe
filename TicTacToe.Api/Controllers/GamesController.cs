using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TicTacToe.Core.Models;
using TicTacToe.Core.Services;
using AutoMapper;
using TicTacToe.Api.Resources;
using TicTacToe.Core.Exceptions;

namespace TicTacToe.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GamesController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<GameResource>>> GetAllGames()
        {
            var games = await _gameService.GetAll();
            var gamesResources = _mapper.Map<IEnumerable<Game>, IEnumerable<GameResource>>(games);

            return Ok(gamesResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<GameResource>> createNewGame()
        {
            var createdGame = await _gameService.CreateNewGame();
            return Ok(_mapper.Map<Game, GameResource>(createdGame));
        }

        [HttpPost("{gameId}")]
        public async Task<ActionResult<MovementResponse>> createGameMovement(Guid gameId, [FromBody] CreateGameMovementResource gameMovementResource)
        {
            var movement = _mapper.Map<CreateGameMovementResource, GameMovement>(gameMovementResource);

            // return Ok();
            try
            {
                var createdMovement = await _gameService.MakeGameMovement(gameId, movement);
                return Ok(createMovementResponse(createdMovement));
            }
            catch (InvalidMovementException e)
            {
                var response = new MovementResponse();
                response.msg = e.Message;
                return Ok(response);
            }


            // return _mapper.Map<GameMovement, GameMovementResource>(createdMovement);
        }

        private MovementResponse createMovementResponse(GameMovement createdMovement)
        {
            MovementResponse response = new MovementResponse();
            var returnMsg = "";
            string winner = null;

            if (createdMovement.Game.GameStatus == GameStatus.ONGOING)
            {
                returnMsg = "Movimento realizado com sucesso";
            }
            else
            {
                returnMsg = "Partida Finalizada";
                if (createdMovement.Game.GameStatus == GameStatus.FINISHED)
                {
                    winner = createdMovement.Player.ToString();
                }
                else
                {
                    winner = "Draw";
                }
            }

            response.winner = winner;
            response.msg = returnMsg;

            return response;
        }

        public class MovementResponse
        {
            public string msg { get; set; }
            public string winner { get; set; }
        }
    }


}