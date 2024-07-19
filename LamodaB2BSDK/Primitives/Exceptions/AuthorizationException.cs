namespace LamodaB2BSDK.Primitives.Exceptions;

public sealed class AuthorizationException(string message, Exception innerException) : Exception(message, innerException);