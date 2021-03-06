using System;
using System.Runtime.Serialization;

namespace TicTacToe.Core.Exceptions
{
    public class InvalidMovementException : System.Exception
    {
        public InvalidMovementException() { }
        public InvalidMovementException(string message) : base(message) { }
        public InvalidMovementException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidMovementException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}