using Domain.Entities;

namespace Infrastructure.Repository.Interfaces;

public interface IBookElementRepository
{
    public Task<BookElement?> GetBookElementByTitle(string title);
    public Task<BookElement?> GetAllBookElementsByType(string type);
    public Task<BookElement> AddBookElement(string type, string title, string description, string placement, string image);
    public Task<BookElement> PatchBookElement(string type, string title, string description, string placement, string image);
    public Task<BookElement> DeleteBookElement(string type, string title, string description, string placement, string image);
    
}