﻿using MediatR;
using TravelAccommodationBookingPlatform.Domain.Shared.ResultPattern;

namespace TravelAccommodationBookingPlatform.Application.Interfaces.Messaging;
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
