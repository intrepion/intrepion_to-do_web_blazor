using Bogus;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace ApplicationNamePlaceholder.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class ToDoItemAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        var faker = new Faker();
        string aRandomString = faker.Random.String2(10);
        string someRandomString = faker.Random.String2(10);
        await Page.GetByRole(AriaRole.Link, new() { Name = "To Do Items" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create New" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item Add");

        await Page.GetByLabel("IsCompleted:").CheckAsync();
        await Page.GetByLabel("Ordering:").FillAsync("1");
        // CreatePropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item Add");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Cancel" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "aName" + aRandomString, Exact = true }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Edit" }).ClickAsync();

        await Page.GetByLabel("IsCompleted:").CheckAsync();
        await Page.GetByLabel("Ordering:").FillAsync("2");
        // ModifyPropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item View");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Delete" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Back to Grid" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item Home");
    }

    [SetUp]
    public async Task SetUp()
    {
        var baseUrl = Environment.GetEnvironmentVariable("BASE_URL");
        if (string.IsNullOrEmpty(baseUrl))
        {
            baseUrl = "http://localhost:5199";
        }
        await Page.GotoAsync(baseUrl);


       await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Log in");
        await Page.GetByTestId("loginEmail").FillAsync("Admin1@ApplicationNamePlaceholder.com");
        await Page.GetByTestId("loginPassword").FillAsync("Admin1@ApplicationNamePlaceholder.com");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Logout" }).ClickAsync();
    }
}
