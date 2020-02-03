namespace Sisense.SingleSignOn
{
    public interface ISisenseJwtProvider
    {
        string CreateJwt(SisenseJwtRequest jwtRequest);
    }
}
