using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Api.Resources
{
    public class MovementPositionResource
    {
        [Required, Range(0, 2)]
        public int x { get; set; }
        
        [Required, Range(0, 2)]
        public int y { get; set; }
    }
}