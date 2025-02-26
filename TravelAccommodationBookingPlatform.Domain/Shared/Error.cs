﻿using Microsoft.AspNetCore.Identity;
using TravelAccommodationBookingPlatform.Domain.Enums;

namespace TravelAccommodationBookingPlatform.Domain.Shared;

public class Error : IEquatable<Error>
{
    public static readonly Error None = new(ErrorType.None, string.Empty, string.Empty);

    public static readonly Error NullValue = new(ErrorType.BadRequest, "Error.NullValue", "The specified result value is null.");

    public Error(ErrorType type, string code, string message) => (Type, Code, Message) = (type, code, message);

    public ErrorType Type { get; }
    public string Code { get; }
    public string Message { get; }
    public DateTime Timestamp { get; } = DateTime.Now;

    public Error WithMessage(string message) => new(Type, Code, message);


    public static implicit operator string(Error error) => $"{error.Code} , {error.Message}";

    public static bool operator ==(Error? a, Error? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(Error? a, Error? b) => !(a == b);

    public virtual bool Equals(Error? other)
    {
        if (other is null)
            return false;

        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj) => obj is Error error && Equals(error);

    public override int GetHashCode() => HashCode.Combine(Code, Message);

    public override string ToString() => Code;

    public static implicit operator Error(IdentityError error) => new(ErrorType.BadRequest, error.Code, error.Description);
}

