using System.Text.RegularExpressions;

namespace Domain.valueObjects;

public partial record PhoneNumber
{
    private const int DefaultLength = 9;
    private const string Pattern = @"^(?:-*\d-*){}$";
    private PhoneNumber(string value) => Value = value;
    public static PhoneNumber? Create(string value)
    {
        if (string.IsNullOrEmpty(value) || !PhoneNumberRegex().IsMatch(value) || value.Length != DefaultLength)
        {
            return null;   
        }
        return new PhoneNumber(value);
    }

    public string Value { get; set; }

    [GeneratedRegex(Pattern)]
    private static partial Regex PhoneNumberRegex();
}