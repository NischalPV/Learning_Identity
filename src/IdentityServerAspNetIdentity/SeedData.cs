using System.Security.Claims;
using IdentityModel;
using IdentityServerAspNetIdentity.Data;
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityServerAspNetIdentity.Data;

public class SeedData
{
    public static void SeedUsingMigrations(ModelBuilder modelBuilder)
    {
        //DefaultTenants(modelBuilder);
       
        DefaultUsers(modelBuilder);
       
    }

    private static void DefaultUsers(ModelBuilder modelBuilder)
    {
        IPasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

        List<ApplicationUser> users =
        [
            new ApplicationUser(createdDate: new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc))
            {
                FirstName = "SysAdmin",
                LastName = "@devtenant",
                DateOfBirth = new DateTime(2024, 5, 1, 0, 0, 0, DateTimeKind.Utc),
                Email = "corporate.mdm@hotmail.com",
                UserName = "+918888888888",
                PhoneNumber = "+918888888888",
                NormalizedUserName = "+918888888888".ToUpper(),
                NormalizedEmail = "corporate.mdm@hotmail.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PasswordHash = "mdm@2024", // This is actual password. DO NOT use this password directly. We need to hash it before storing it.
                SecurityStamp = "124d2334-c5f6-4163-922c-7c6cf18833e1",
                ConcurrencyStamp = "59067e57-3de6-4034-a2b6-5525d5836a63",
                Id = "c0aab6ba-cd71-4010-a9dc-e246997d6183",
                FavoriteColor="red",
                Subject = "maths"
            },
            new ApplicationUser(createdDate: new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc))
            {
                FirstName = "SysAdmin",
                LastName = "@individual",
                DateOfBirth = new DateTime(2024, 5, 1, 0, 0, 0, DateTimeKind.Utc),
                Email = "individual.mdm@hotmail.com",
                UserName = "+919999999999",
                PhoneNumber = "+919999999999",
                NormalizedUserName = "+919999999999".ToUpper(),
                NormalizedEmail = "individual.mdm@hotmail.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PasswordHash = "mdm@2024", // This is actual password. DO NOT use this password directly. We need to hash it before storing it.
                SecurityStamp = "79e61877-b796-4580-8a49-efc84405ba38",
                ConcurrencyStamp = "5c45bffe-7219-42dc-84a1-97ab184b42a9",
                Id = "c4547bd7-402e-4c4f-88c2-8604e54f1e21",
                FavoriteColor="red",
                Subject = "maths"
            },
            new ApplicationUser(createdDate: new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc))
            {
                FirstName = "User",
                LastName = "@corporate",
                DateOfBirth = new DateTime(2024, 5, 1, 0, 0, 0, DateTimeKind.Utc),
                Email = "user.mdm@hotmail.com",
                UserName = "+917777777777",
                PhoneNumber = "+917777777777",
                NormalizedUserName = "+917777777777".ToUpper(),
                NormalizedEmail = "user.mdm@hotmail.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PasswordHash = "mdm@2024", // This is actual password. DO NOT use this password directly. We need to hash it before storing it.
                SecurityStamp = "14659833-4a2c-4ef9-92fe-902a11d118e8",
                ConcurrencyStamp = "9652162b-1fc1-459e-92de-ee7d08fb18de",
                Id = "b79aa9c4-cbf5-42a3-a768-3a4c83a70160",
                FavoriteColor="red",
                Subject = "maths"
            },
        ];

        users.ForEach(user =>
        {
            // Hash user passwords for each user
            user.PasswordHash = _passwordHasher.HashPassword(user, user.PasswordHash);
            // seed user data
            modelBuilder.Entity<ApplicationUser>().HasData(user);
        });
    }

    //public static void EnsureSeedData(WebApplication app)
    //{
    //    using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
    //    {
    //        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //        context.Database.EnsureDeleted();
    //        context.Database.Migrate();

    //        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    //        var alice = userMgr.FindByNameAsync("alice").Result;
    //        if (alice == null)
    //        {
    //            alice = new ApplicationUser
    //            {
    //                UserName = "alice",
    //                Email = "AliceSmith@email.com",
    //                EmailConfirmed = true,
    //                FavoriteColor = "red",
    //                Subject = "maths"
    //            };
    //            var result = userMgr.CreateAsync(alice, "Pass123$").Result;
    //            if (!result.Succeeded)
    //            {
    //                throw new Exception(result.Errors.First().Description);
    //            }

    //            result = userMgr.AddClaimsAsync(alice, new Claim[]{
    //                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
    //                        new Claim(JwtClaimTypes.GivenName, "Alice"),
    //                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
    //                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
    //                    }).Result;
    //            if (!result.Succeeded)
    //            {
    //                throw new Exception(result.Errors.First().Description);
    //            }
    //            Log.Debug("alice created");
    //        }
    //        else
    //        {
    //            Log.Debug("alice already exists");
    //        }

    //        var bob = userMgr.FindByNameAsync("bob").Result;
    //        if (bob == null)
    //        {
    //            bob = new ApplicationUser
    //            {
    //                UserName = "bob",
    //                Email = "BobSmith@email.com",
    //                EmailConfirmed = true
    //            };
    //            var result = userMgr.CreateAsync(bob, "Pass123$").Result;
    //            if (!result.Succeeded)
    //            {
    //                throw new Exception(result.Errors.First().Description);
    //            }

    //            result = userMgr.AddClaimsAsync(bob, new Claim[]{
    //                        new Claim(JwtClaimTypes.Name, "Bob Smith"),
    //                        new Claim(JwtClaimTypes.GivenName, "Bob"),
    //                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
    //                        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
    //                        new Claim("location", "somewhere")
    //                    }).Result;
    //            if (!result.Succeeded)
    //            {
    //                throw new Exception(result.Errors.First().Description);
    //            }
    //            Log.Debug("bob created");
    //        }
    //        else
    //        {
    //            Log.Debug("bob already exists");
    //        }
    //    }
    //}
}
