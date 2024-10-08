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
        await Expect(Page).ToHaveTitleAsync("Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "To Do Items" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item Creation");

        await Page.GetByTestId("toDoItemAdminEditOrdering").FillAsync("1");
        await Page.GetByTestId("toDoItemAdminEditTitle").FillAsync("a toDoItem");
        // CreatePropertyCodePlaceholder
        // await Page.GetByTestId("toDoItemAdminEditName").FillAsync("a toDoItem");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item Modification");

        await Page.GetByTestId("toDoItemAdminEditOrdering").FillAsync("2");
        await Page.GetByTestId("toDoItemAdminEditTitle").FillAsync("some toDoItem");
        // ModifyPropertyCodePlaceholder
        // await Page.GetByTestId("toDoItemAdminEditName").FillAsync("some toDoItem");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("To Do Item List");
    }

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("http://localhost:5174");
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
