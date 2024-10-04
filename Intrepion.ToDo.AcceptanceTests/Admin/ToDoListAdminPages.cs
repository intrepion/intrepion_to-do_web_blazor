﻿using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace ApplicationNamePlaceholder.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class EntityNamePlaceholderAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        await Expect(Page).ToHaveTitleAsync("Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "PluralNamePlaceholder" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("HumanNamePlaceholder List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("HumanNamePlaceholder Creation");

        // CreatePropertyCodePlaceholder
        // await Page.GetByTestId("EntityLowercaseNamePlaceholderAdminEditName").FillAsync("a EntityLowercaseNamePlaceholder");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("HumanNamePlaceholder Modification");

        // ModifyPropertyCodePlaceholder
        // await Page.GetByTestId("EntityLowercaseNamePlaceholderAdminEditName").FillAsync("some EntityLowercaseNamePlaceholder");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("HumanNamePlaceholder Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("HumanNamePlaceholder List");
    }

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("ClientUriPlaceholder");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Log in");
        await Page.GetByTestId("loginEmail").FillAsync("Admin1@ApplicationNamePlaceholder.com");
        await Page.GetByTestId("loginPassword").FillAsync("Admin1@ApplicationNamePlaceholder.com");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
    }
}
