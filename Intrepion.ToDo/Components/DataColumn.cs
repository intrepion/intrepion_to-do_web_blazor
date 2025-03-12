using Microsoft.AspNetCore.Components;

public class DataColumn<TItem>
{
    // Title displayed in the column header
    public string Title { get; set; } = string.Empty;
    
    // Property name on the TItem to bind to (supports dot notation for nested properties)
    public string PropertyName { get; set; } = string.Empty;
    
    // Optional custom template for rendering the cell content
    public RenderFragment<TItem>? Template { get; set; }
    
    // Whether this column can be sorted
    public bool IsSortable { get; set; } = true;
}

// Enum for sort direction
public enum SortDirection
{
    Ascending,
    Descending
}
