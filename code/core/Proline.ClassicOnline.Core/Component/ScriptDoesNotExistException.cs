using System;

namespace Proline.ClassicOnline.Engine.Component
{
    [Serializable]
    internal class ScriptDoesNotExistException : Exception
    {
        public ScriptDoesNotExistException()
        {
        }

        public ScriptDoesNotExistException(string message) : base(message)
        {
        }

        public ScriptDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}