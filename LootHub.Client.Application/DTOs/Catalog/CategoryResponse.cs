namespace LootHub.Client.Application.DTOs.Catalog;

public sealed record CategoryResponse(
    Guid Id,
    string Name,
    string Slug
    );
