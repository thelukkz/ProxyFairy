namespace ProxyFairy.Core.Enums
{
    public enum ResponseType
    {
        Ok = 200,

        BadRequest = 400,
        Forbidden = 403,
        NotFound = 404,
        Gone = 410,
        PreconditionFailed = 412,
        InternalServerError = 500
    }
}
