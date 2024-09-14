﻿using Domain.Entities;
using Infrastructure.Models;

namespace Infrastructure.Repository.Interfaces;

public interface IBookElementRepository
{
    public Task<BookElement?> GetByIdAsync(string title);
    public Task<BookElement?> GetAllByTypeAsync(string type);
    public Task<BookElement> CreateAsync(BookElementDbCreate data);
    public Task<BookElement> UpdateAsync(int id, BookElementDbUpdate data);
    public Task<BookElement> DeleteAsync(int id);
    
}