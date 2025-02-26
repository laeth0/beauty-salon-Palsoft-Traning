﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAccommodationBookingPlatform.Domain.Constants;
using TravelAccommodationBookingPlatform.Domain.ValueObjects;

namespace TravelAccommodationBookingPlatform.Persistence.Configurations.PropertyBuilderExtensions;
public static class ComplexPropertyBuilderExtensions
{
    public static ComplexPropertyBuilder<T> ApplyCoordinatesConfiguration<T>(this ComplexPropertyBuilder<T> builder)
       where T : Coordinates
    {
        builder.Property(c => c.Latitude)
            .IsRequired()
            .HasPrecision(DomainRules.Locations.PrecisionDigits, DomainRules.Locations.ScaleDigits)
            .HasAnnotation("Min", DomainRules.Locations.LatitudeMin)
            .HasAnnotation("Max", DomainRules.Locations.LatitudeMax);

        builder.Property(c => c.Longitude)
            .IsRequired()
            .HasPrecision(DomainRules.Locations.PrecisionDigits, DomainRules.Locations.ScaleDigits)
            .HasAnnotation("Min", DomainRules.Locations.LongitudeMin)
            .HasAnnotation("Max", DomainRules.Locations.LongitudeMax);

        return builder;
    }

    public static ComplexPropertyBuilder<T> ApplyPriceConfiguration<T>(this ComplexPropertyBuilder<T> builder)
    where T : Price
    {
        builder.Property(p => p.Value)
            .IsRequired();

        return builder;
    }

    public static ComplexPropertyBuilder<T> ApplyNumberOfGuestsConfiguration<T>(this ComplexPropertyBuilder<T> builder)
        where T : NumberOfGuests
    {
        builder.Property(g => g.Adults)
            .IsRequired()
            .HasAnnotation("Min", DomainRules.NumberOfGuests.AdultsMin)
            .HasAnnotation("Max", DomainRules.NumberOfGuests.AdultsMax);

        builder.Property(g => g.Children)
            .IsRequired()
            .HasAnnotation("Min", DomainRules.NumberOfGuests.ChildrenMin)
            .HasAnnotation("Max", DomainRules.NumberOfGuests.ChildrenMax);

        return builder;
    }

    public static ComplexPropertyBuilder<T> ApplyCheckingConfiguration<T>(this ComplexPropertyBuilder<T> builder)
    where T : Checking
    {
        builder.Property(c => c.CheckInDate)
            .IsRequired();

        builder.Property(c => c.CheckOutDate)
            .IsRequired();

        return builder;
    }


}
