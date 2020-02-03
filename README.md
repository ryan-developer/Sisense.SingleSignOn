# Sisense.SingleSignOn

Assuming your Sisense instance has been configured correctly for SSO, this simple example will work to create a valid Jwt token for authenticating against Sisense.

## Configure Dependency Injection

Add the jwt provider to your services:

```
public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddSisenseSsoProviders();
    ...
  }
}
```

## Create an SSO token and redirect to Sisense
 
```
[Authorize]
[HttpGet("sisense/jwt")]
public async Task<IActionResult> GetSisenseRedirect(
    [FromServices] ISisenseJwtProvider jwtProvider,
    [FromQuery(Name ="return_to")] string returnToUrl, 
    string returnUrl)
{
    // Don't forget to valid return urls.
    string returnRoute = null;
    string jwt = jwtProvider.CreateJwt("[Existing Sisense user email]", "[Sisense Shared Key]");
    if (returnToUrl != null)
    {
        // for embedded scenarios
        returnRoute = QueryHelpers.AddQueryString(returnUrl, "return_to", returnToUrl);
    }
    returnRoute = QueryHelpers.AddQueryString(returnUrl, "jwt", token);

    return Redirect(returnRoute);
}
```
