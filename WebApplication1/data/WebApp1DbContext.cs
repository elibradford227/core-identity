using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplication1.models;

public class WebApp1DbContext : IdentityDbContext<User>
{
    public WebApp1DbContext(DbContextOptions<WebApp1DbContext> options) : base(options)
    {

    }
}