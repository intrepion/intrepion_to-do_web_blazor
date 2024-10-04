﻿using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace ApplicationNamePlaceholder.AcceptanceTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class PublicPages : PageTest
{
    [GeneratedRegex("Counter")]
    private static partial Regex Counter();
    [GeneratedRegex("Home")]
    private static partial Regex Home();
    [GeneratedRegex("Log in")]
    private static partial Regex LogIn();
    [GeneratedRegex("Register")]
    private static partial Regex Register();
    [GeneratedRegex("Weather")]
    private static partial Regex Weather();

    [Test]
    public async Task MainNavigation()
    {
        await Expect(Page).ToHaveURLAsync("ClientUriPlaceholder/");
        await Expect(Page).ToHaveTitleAsync(Home());
        await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync(Counter());
        await Page.GetByRole(AriaRole.Link, new() { Name = "Weather" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync(Weather());
        await Page.GetByRole(AriaRole.Link, new() { Name = "Register" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync(Register());
        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync(LogIn());
    }

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("ClientUriPlaceholder");
    }
}
