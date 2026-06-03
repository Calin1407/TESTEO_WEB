namespace NovaTech.TerraTech.Platform.Iam.Domain.Model.ValueObjects;

/// <summary>
///     Value object representing user's validated password.
///     Guarantee that no password will be able to join the domain if it is not greater than 'MinLength'.
/// </summary>
public sealed record Password
{
    private const int MinLength = 6;
    
    /// <summary>
    ///     Initialize a new instance of Password.
    /// </summary>
    /// <param name="value">
    ///     Raw value string represents Password.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     Triggered when "value" is not greater than 'MinLength', is blank or null.
    /// </exception>
    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Password cannot be null or whitespace.", nameof(value));
        }

        if (value.Length < MinLength)
        {
            throw new ArgumentException($"Password must be at least {MinLength} characters long.");
        }

        Value = value;
    }
    /// <summary>
    ///     Get the primitive value 
    /// </summary>
    public string Value { get; init; }
    
    /// <inheritdoc/>
    public override string ToString() => Value;
}