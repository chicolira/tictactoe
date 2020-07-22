using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Api.Resources
{
    public class CreateGameMovementResource
    {
        [Required]
        public Guid Id { get; set; }

        public int movId { get; set; }

        [Required]
        public char Player { get; set; }
        public MovementPositionResource position;
    }
}