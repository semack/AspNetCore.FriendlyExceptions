# ASP.NET Core Friendly Exceptions Filter and Middleware  [![Build Status](https://travis-ci.org/semack/AspNetCore.FriendlyExceptions.svg?branch=master)](https://travis-ci.org/semack/AspNetCore.FriendlyExceptions)

A filter and middleware that can translate exceptions into nice http resonses. This allows you to throw meaningfull exceptions from your framework, business code or other middlewares and translate the exceptions to nice and friendly http responses.

## Authors
This code based on [Owin Friendly Exceptions Middleware](https://github.com/abergs/OwinFriendlyExceptions) created by [Anders Åberg](https://github.com/abergs) and has been adapted for APS.NET Core usage by [Andriy S'omak](https://github.com/semack).

## Installation

`Install-package OwinFriendlyExceptions`

## Examples of usage
There are a two ways of usage of the library: using ExceptionFilter or registering Midlleware. You can choise any of them.

### Configuration
Add transformation rules to the Startup.cs file.
```cs
        public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddFriendlyExceptionsTransforms(options =>
            {
                options.Transforms = TransformsCollectionBuilder.Begin()
    
                    .Map<ExampleException>()
                    .To(HttpStatusCode.BadRequest, "This is the reasonphrase",
                        ex => "And this is the response content: " + ex.Message)
    
                    .Map<SomeCustomException>()
                    .To(HttpStatusCode.NoContent, "Bucket is emtpy", ex => string.Format("Inner details: {0}", ex.Message))
    
                    .Map<EntityUnknownException>()
                    .To(HttpStatusCode.NotFound, "Entity does not exist", ex => ex.Message)
    
                    .Map<InvalidAuthenticationException>()
                    .To(HttpStatusCode.Unauthorized, "Invalid authentication", ex => ex.Message)
    
                    .Map<AuthorizationException>()
                    .To(HttpStatusCode.Forbidden, "Forbidden", ex => ex.Message)
                    
                    // Map all other exceptions if needed. 
                    // Also it would be useful if you want to map exception to a known model.
                    .MapAllOthers()
                    .To(HttpStatusCode.InternalServerError, "Internal Server Error", ex => ex.Message)
            });
            ...
        }
```

By default, OwinFriendlyExceptions sets the response Content-Type to `text/plain`. To use a different type:
```cs    
    .Map<SomeJsonException>()
    .To(HttpStatusCode.BadRequest, "This exception is json",
        ex => JsonConvert.SerializeObject(ex.Message), "application/json")
```

### Using filter
Register ExceptionFilter.
```cs
        public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddMvc()
                .AddMvcOptions(s => s.Filters.Add(typeof(FriendlyExceptionAttribute)))
            ...
        }                
```
Add filter attribute to a Controller.
```cs
    [Produces("application/json")]
    [TypeFilter(typeof(FriendlyExceptionAttribute))]
    public class AccountController : Controller
    {
        ...
```
### Using Middleware
In case you use middleware, the registration method mush be at the top of list of all registrations.
```cs
        public void Configure(IApplicationBuilder app)
        {
            app.UseFriendlyExceptions();
            ...
        }

```

## Contribute
Contributions are welcome. Just open an Issue or submit a PR. 

## Contact
You can reach me via my [email](mailto://semack@gmail.com)
