namespace Infrastructure.Persistence.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : IdentityDbContext(options);