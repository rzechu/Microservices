using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private static readonly List<ItemDto> items = new()
    {
        new(Guid.NewGuid(), "Potion", "Restores a small amount o HP", 5, DateTimeOffset.Now),
        new(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.Now),
        new(Guid.NewGuid(), "Bronze sword", "Deals a small amount o damage", 20, DateTimeOffset.Now)
    };


    [HttpGet]
    public IEnumerable<ItemDto> Get() => items;

    [HttpGet("{id}")]
    public ItemDto GetById(Guid id) => items.SingleOrDefault(w => w.Id == id);

    [HttpPost]
    public ActionResult<ItemDto> Post(ItemDto createdItemDto)
    {
        var newItem = new ItemDto(Guid.NewGuid(), createdItemDto.Name, createdItemDto.Description, createdItemDto.Price, DateTimeOffset.UtcNow);
        items.Add(newItem);
        return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
    }

    [HttpPut("{id}")]
    public ActionResult Put(Guid id, ItemDto itemDto)
    {
        var existingItem = items.SingleOrDefault(w => w.Id == id);
        var updatedItem = existingItem with { 
            Name = itemDto.Name, 
            Description = itemDto.
            Description, Price = 
            itemDto.Price 
        };
        var index = items.FindIndex(existingItem => id == existingItem.Id);
        items[index] = updatedItem;
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var index = items.FindIndex(items => items.Id == id);
        items.RemoveAt(index);

        return NoContent();
    }
}
