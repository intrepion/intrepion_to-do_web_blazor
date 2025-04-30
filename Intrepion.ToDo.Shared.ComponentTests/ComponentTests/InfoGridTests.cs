using Bunit;
using Intrepion.ToDo.Shared.Grid;
using NUnit.Framework;

namespace Intrepion.ToDo.Shared.UnitTests.InfoGridTests;

public class InfoGridTests : BunitContext
{
    [Test]
    public void InfoGridComponentRendersCorrectly()
    {
        var cut = Render<InfoGrid>();

        cut.MarkupMatches("<div><p>No information found.</p></div>");
    }
}
