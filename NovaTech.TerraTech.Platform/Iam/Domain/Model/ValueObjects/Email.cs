using System.Text.RegularExpressions;

namespace NovaTech.TerraTech.Platform.Iam.Domain.Model.ValueObjects;

/// <summary>
///     Value object representing an Email.
///     Guarantee consistent Email credentials.
/// </summary>
public sealed partial record Email
{
    /// <summary>
    ///     Generated regular expression to validate email's format.
    /// </summary>
    [GeneratedRegex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase)]
    private static partial Regex EmailValidationRegex();

    /// <summary>
    ///     Initializes a new instance of Email
    /// </summary>
    /// <param name="value">
    ///     Raw value string represents Email.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     Triggered when "value" is not in Email Address format, is blank or null
    /// </exception>
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Email cannot be null o whitespace.",  nameof(value));
        }

        if (!EmailValidationRegex().IsMatch(value))
        {
            throw new ArgumentException("Email format is invalid.",  nameof(value));
        }
        Value = value.ToLowerInvariant().Trim();
    }
    
    /// <summary>
    ///     Get the primitive value 
    /// </summary>
    public string Value { get; init; }
    
    /// <inheritdoc/>
    public override string ToString() => Value;
}