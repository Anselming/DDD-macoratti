using System.Text.RegularExpressions;

public class DomainException : Exception
{
    public DomainException(string? message) : base(message)
    {
    }

    public DomainException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public static void ThrowIfNotEquals(object object1, object object2, string message)
    {
        if (!object1.Equals(object2))
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfDatetimeIsLessThen(DateTime value, DateTime lessThen, string message)
    {
        if (value < lessThen)
        {
            throw new DomainException(message);
        }
    }    

    public static void ThrowIfNotFalse(bool boolValue, string message)
    {
        if (boolValue)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfExceedMaxLength(string stringValue, int maximum, string message)
    {
        int length = stringValue.Trim().Length;
        if (length > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfHasSpecialCharacters(string stringValue, string message)
    {
        if(stringValue.Any(ch => ! char.IsLetterOrDigit(ch)))
        {
            throw new DomainException(message);
        }

    }    

    public static void ThrowIfExceedLenghts(string stringValue, int minimum, int maximum, string message)
    {
        int length = stringValue.Trim().Length;
        if (length < minimum || length > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfNotMatch(string pattern, string stringValue, string message)
    {
        Regex regex = new Regex(pattern);

        if (!regex.IsMatch(stringValue))
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfIsNullOrEmpty(string stringValue, string message)
    {
        if (stringValue == null || stringValue.Trim().Length == 0)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfEquals(object object1, object object2, string message)
    {
        if (object1.Equals(object2))
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfNull(object object1, string message)
    {
        if (object1 == null)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfExceedLenghts(double value, double minimum, double maximum, string message)
    {
        if (value < minimum || value > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfExceedLenghts(float value, float minimum, float maximum, string message)
    {
        if (value < minimum || value > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfExceedLenghts(int value, int minimum, int maximum, string message)
    {
        if (value < minimum || value > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfExceedLenghts(long value, long minimum, long maximum, string message)
    {
        if (value < minimum || value > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfNotTrue(bool boolValue, string message)
    {
        if (!boolValue)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfIsTrue(bool boolValue, string message)
    {
        if (boolValue)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfIsFalse(bool boolValue, string message)
    {
        if (!boolValue)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfLessThenZero(int value, string message)
    {
        if (value < 0)
        {
            throw new DomainException(message);
        }
    }

    public static void ThrowIfLessThenZero(double value, string message)
    {
        if (value < 0)
        {
            throw new DomainException(message);
        }
    }    

    public static void ThrowIfLessThenZero(float value, string message)
    {
        if (value < 0)
        {
            throw new DomainException(message);
        }
    }    

    public static void ThrowIfLessThenZero(decimal value, string message)
    {
        if (value < 0)
        {
            throw new DomainException(message);
        }
    }    

}