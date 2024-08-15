namespace LamodaB2BSDK.Core;

public class LamodaB2BException : Exception
{
    public LamodaB2BException(string message) : base(message) {}
    public LamodaB2BException(string message, Exception initialException) : base(message, initialException) {}
    
}