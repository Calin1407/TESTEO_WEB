namespace NovaTech.TerraTech.Platform.StockManagement.Domain.Model.Commands;

public record CreateInventoryCommand(string ProductId, int StockQuantity, string? WarehouseLocation = null);