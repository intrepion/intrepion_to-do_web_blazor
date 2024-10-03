using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace ApplicationNamePlaceholder.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class ApplicationUserAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "Application Users" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application User List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application User Creation");
        await Page.GetByTestId("applicationUserAdminEditEmail").FillAsync("a@Email.com");
        await Page.GetByTestId("applicationUserAdminEditPhoneNumber").FillAsync("(555) 555-5555");
        await Page.GetByTestId("applicationUserAdminEditUserName").FillAsync("aUserName");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application User Modification");
        await Page.GetByTestId("applicationUserAdminEditEmail").FillAsync("some@Email.com");
        await Page.GetByTestId("applicationUserAdminEditPhoneNumber").FillAsync("(555) 867-5309");
        await Page.GetByTestId("applicationUserAdminEditUserName").FillAsync("someUserName");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application User Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application User List");
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
