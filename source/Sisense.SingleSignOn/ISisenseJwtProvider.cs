namespace Sisense.SingleSignOn
{
    public interface ISisenseJwtProvider
    {
        string CreateJwt(string emailAddress, string sharedSecret);
    }
}
