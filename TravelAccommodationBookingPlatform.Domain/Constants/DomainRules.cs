﻿namespace TravelAccommodationBookingPlatform.Domain.Constants;

public static class DomainRules
{
    public static class Users
    {
        public const int UsernameMaxLength = 50;
        public const int EmailMaxLength = 256;
        public const int PasswordMaxLength = 100;

    }

    public static class Booking
    {
        public const int SpecialRequestMaxLength = 500;
    }

    public static class NumberOfGuests
    {
        public const int AdultsMin = 1;
        public const int AdultsMax = 99;
        public const int ChildrenMin = 0;
        public const int ChildrenMax = 99;
    }

    public static class Cities
    {
        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 1000;
    }

    public static class Countries
    {
        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 1000;
    }

    public static class Discount
    {
        public const double PercentageMin = 0.0;
        public const double PercentageMax = 100.0;
        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 1000;
    }

    public static class Hotels
    {
        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 1000;
    }
    public static class Locations
    {
        public const int PrecisionDigits = 18;
        public const int ScaleDigits = 15;
        public const double LatitudeMin = -90.0;
        public const double LatitudeMax = 90.0;
        public const double LongitudeMin = -180.0;
        public const double LongitudeMax = 180.0;
    }

    public static class Payments
    {
        public const int ConfirmationNumberMaxLength = 50;
    }

    public static class Reviews
    {
        public const int ContentMaxLength = 2000;
    }

    public static class Rooms
    {
        public const int RoomNumberMin = 1;
        public const int RoomNumberMax = 99999;
    }




}
