using Application.DTO;
using Domain.Entities;
using Infrastructure.Models;

namespace Infrastructure.Repository.Interfaces;

public interface IImageRepository
{
    Task<Image> CreateAsync(ImageDbCreate data);
    Task<Image> UpdateAsync(int id, ImageDbCreate data);
    Task<Image> DeleteAsync(int id);
    Task<Image> GetAllByElement(int elementId);
    Task<Image> GetById(int id);
    List<string> GetReferenceByElementId(int elementId);
}