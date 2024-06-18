using Planifi_backend.DataEntry.Domain.Model.Aggregates;
using Planifi_backend.DataEntry.Domain.Model.Commands;

namespace Planifi_backend.DataEntry.Domain.Model.Entities;

public class Category
{
    public Category(string name)
    {
        Name = name;
    }

    public Category(CreateCategoryCommand command)
    {
        Name = command.Name;
    }

    public Category()
    {
        Name = string.Empty;
    }
    
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<Worker> Workers { get; }
}