using System.Runtime.Serialization;

namespace Doctorly.EventManager.Infrastructure.Exceptions;

public class DataException : Exception
{
    public DataException(string message) : base(message)
    {
        
    }

    public DataException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        
    }
}
