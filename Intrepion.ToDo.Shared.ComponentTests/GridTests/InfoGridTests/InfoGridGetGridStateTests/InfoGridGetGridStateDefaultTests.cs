using Intrepion.ToDo.Shared.Grid;

namespace Intrepion.ToDo.Shared.UnitTests.GridTests.InfoGridTests.InfoGridGetGridStateTests;

public class InfoGridGetGridStateDefaultTests : InfoGridTestsBaseClass
{
    [Test]
    public void DefaultState_WhenNothing()
    {
        var columnNames = new List<string>
        {
            "Completed Date and Time",
            "Is Completed",
            "Ordering",
            "Title",
            "To Do List",
        };

        var columnTypes = new List<ColumnType>
        {
            ColumnType.DateTime,
            ColumnType.Boolean,
            ColumnType.Integer,
            ColumnType.Normalized,
            ColumnType.Normalized,
        };

        var filters = new List<string?>
        {
            null,
            null,
            null,
            null,
            null,
        };

        var page = 1;
        var rowsPerPage = 10;
        var sorts = new List<(int, bool)>();
        var totalPages = 3;
        var totalRows = 28;

        _infoGrid.ColumnNames = columnNames;
        _infoGrid.ColumnTypes = columnTypes;
        _infoGrid.Filters = filters;
        _infoGrid.Page = page;
        _infoGrid.RowsPerPage = rowsPerPage;
        _infoGrid.Sorts = sorts;
        _infoGrid.TotalPages = totalPages;
        _infoGrid.TotalRows = totalRows;
        var actual = _infoGrid;

        Assert.Multiple(() =>
        {
            Assert.That(actual.ColumnNames, Is.EqualTo(columnNames));
            Assert.That(actual.ColumnTypes, Is.EqualTo(columnTypes));
            Assert.That(actual.Filters, Is.EqualTo(filters));
            Assert.That(actual.Page, Is.EqualTo(page));
            Assert.That(actual.RowsPerPage, Is.EqualTo(rowsPerPage));
            Assert.That(actual.Sorts, Is.EqualTo(sorts));
            Assert.That(actual.TotalPages, Is.EqualTo(totalPages));
            Assert.That(actual.TotalRows, Is.EqualTo(totalRows));
        });
    }

    [Test]
    public async Task NextPage_TriggersCallback_WhenPageIsValid()
    {
        // Arrange
        _infoGrid.Page = 1;
        _infoGrid.TotalPages = 3;

        // Act
        await _infoGrid.NextPage();

        // Assert
        Assert.That(_lastPageChangedValue, Is.EqualTo(2), "NextPage should trigger callback with page 2");
    }

    [Test]
    public async Task NextPage_DoesNotTriggerCallback_WhenPageIsInvalid()
    {
        // Arrange
        _infoGrid.Page = 3;
        _infoGrid.TotalPages = 3;
        _lastPageChangedValue = 0;

        // Act
        await _infoGrid.NextPage();

        // Assert
        Assert.That(_lastPageChangedValue, Is.EqualTo(0), "NextPage should not trigger callback when already on last page");
    }

    [Test]
    public async Task PreviousPage_TriggersCallback_WhenPageIsValid()
    {
        // Arrange
        _infoGrid.Page = 2;

        // Act
        await _infoGrid.PreviousPage();

        // Assert
        Assert.That(_lastPageChangedValue, Is.EqualTo(1), "PreviousPage should trigger callback with page 1");
    }

    [Test]
    public async Task PreviousPage_DoesNotTriggerCallback_WhenPageIsInvalid()
    {
        // Arrange
        _infoGrid.Page = 1;
        _lastPageChangedValue = 0;

        // Act
        await _infoGrid.PreviousPage();

        // Assert
        Assert.That(_lastPageChangedValue, Is.EqualTo(0), "PreviousPage should not trigger callback when already on first page");
    }
}
