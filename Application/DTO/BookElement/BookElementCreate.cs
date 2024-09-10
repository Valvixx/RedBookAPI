﻿using Application.Services.Models;

namespace Application.DTO.BookElement;

public record BookElementCreate
{
    public BookElementType Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Placement { get; set; }
    public List<string> Image { get; set; }
}