﻿using Bogus;
using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Data;

public static class FakeData
{
    public static async Task SeedAsync(ApplicationDbContext applicationDbContext)
    {
        Randomizer.Seed = new Random(8675309);

        var applicationRoleFakes = new Faker<ApplicationRole>()
            .RuleFor(x => x.Name, f =>
                f.Hacker.Adjective()
                    + " " + f.Hacker.Noun());
        var applicationRoles = applicationRoleFakes.Generate(8);
        applicationDbContext.Roles.AddRange(applicationRoles);

        var applicationUserFakes = new Faker<ApplicationUser>()
            .RuleFor(x => x.Email, f => f.Internet.Email(f.Name.FirstName(), f.Name.LastName()))
            .RuleFor(x => x.NormalizedEmail, (f, x) => x.Email?.ToUpperInvariant())
            .RuleFor(x => x.NormalizedUserName, (f, x) => x.NormalizedEmail)
            .RuleFor(x => x.UserName, (f, x) => x.Email);
        var applicationUsers = applicationUserFakes.Generate(8);
        applicationDbContext.Users.AddRange(applicationUsers);

        var applicationUserRoleFakes = new Faker<ApplicationUserRole>()
            .RuleFor(x => x.ApplicationRole, f => f.PickRandom(applicationRoles))
            .RuleFor(x => x.ApplicationUser, f => f.PickRandom(applicationUsers));
        var applicationUserRoles = applicationUserRoleFakes.Generate(4);
        applicationDbContext.UserRoles.AddRange(applicationUserRoles);

        // FakeEntityPlaceholder

        await applicationDbContext.SaveChangesAsync();
    }
}
