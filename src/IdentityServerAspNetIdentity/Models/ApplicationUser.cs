// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServerAspNetIdentity.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedDate { get; private set; }

    // Constructor
    public ApplicationUser() => CreatedDate = DateTime.UtcNow;

    // Constructor with CreatedDate
    public ApplicationUser(DateTime createdDate) => CreatedDate = createdDate;

    public string FavoriteColor { get; set; }

    public string Subject { get; set; }
}
