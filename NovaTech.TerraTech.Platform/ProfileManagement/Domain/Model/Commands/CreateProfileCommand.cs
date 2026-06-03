namespace NovaTech.TerraTech.Platform.ProfileManagement.Domain.Model.Commands;

public record CreateProfileCommand(
    string UserId,
    string FundoName,
    string ContactPhone,
    double MoistureThreshold,
    double TempThreshold);