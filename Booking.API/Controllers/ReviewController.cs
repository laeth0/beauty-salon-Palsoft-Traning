﻿

using AutoMapper;
using MediatR;

namespace Booking.API.Controllers;

public class ReviewController : BaseController
{

    public ReviewController(IMapper mapper, ILogger<BaseController> logger, IMediator mediator)
        : base(mapper, logger, mediator)
    {
    }


    /*


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorResponse))] // if there is no token(no role)
     //[ResponseCache(CacheProfileName = "Default60Sec")] //[ResponseCache(Duration =60,Location =ResponseCacheLocation.Client)]
    public async Task<ActionResult> Index([FromHeader] string Authorization,
        [FromQuery] int PageSize = 0,
        [FromQuery] int PageNumber = 0,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new List<string> { "You should send a token" }
                });

            var userId = _serviceManager.TokenService.GetValueFromToken(Authorization, "Id");
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return BadRequest(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new List<string> { "Invalid token" }
                });


            var Review = await _unitOfWork.ReviewRepository.GetAllAsync(PageSize, PageNumber, filterCondition: x => x.UserId == userId);

            return Ok(new SuccessResponse
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Review are retrieved successfully",
                Result = _mapper.Map<IReadOnlyList<ReviewResponseDTO>>(Review)
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Errors = new List<string> { "Internal Server Error", ex.Message }
            });
        }
    }





    [HttpGet("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<ActionResult> Details(Guid id,
        [FromHeader] string Authorization,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new List<string> { "You should send a token" }
                });

            var userId = _serviceManager.TokenService.GetValueFromToken(Authorization, "Id");
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return BadRequest(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new List<string> { "Invalid token" }
                });

            var Review = await _unitOfWork.ReviewRepository.GetByIdAsync(id);

            if (Review is null)
                return NotFound(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Errors = new List<string> { "Review not found" }
                });

            if (Review.UserId != userId)
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new List<string> { "You are not authorized to see this Review" }
                });

            return Ok(new SuccessResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Review is retrieved successfully",
                Result = _mapper.Map<ReviewResponseDTO>(Review)
            });

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Errors = new List<string> { "Internal Server Error", ex.Message }
            });
        }
    }






    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<ActionResult> GetReviewForSpecificBooking([FromQuery] string bookingId,
        [FromHeader] string Authorization,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (!Guid.TryParse(bookingId, out Guid BookingId))
                return BadRequest(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<string> { "Invalid booking Id" }
                });

            if (string.IsNullOrEmpty(Authorization))
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new List<string> { "You should send a token" }
                });

            var userId = _serviceManager.TokenService.GetValueFromToken(Authorization, "Id");
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return BadRequest(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new List<string> { "Invalid token" }
                });

            var booking = await _unitOfWork.RoomBookingRepository.GetByIdAsync(BookingId);
            if (booking is null)
                return NotFound(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Errors = new List<string> { "Booking not found" }
                });

            var Reviews = (await _unitOfWork.ReviewRepository.GetAllAsync(filterCondition: x => x.RoomBookingId == BookingId && x.UserId == userId));
            var review = Reviews?[0];
            if (review is null)
                return NotFound(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Errors = new List<string> { "Review not found" }
                });


            return Ok(new SuccessResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Review is retrieved successfully",
                Result = _mapper.Map<ReviewResponseDTO>(review)
            });

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Errors = new List<string> { "Internal Server Error", ex.Message }
            });
        }
    }





    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SuccessResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]// if the user role is not Admin or Manager
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorResponse))] // if there is no token(no role)
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<ActionResult> Ctrate([FromForm] ReviewCreateRequestDTO model,
        [FromHeader] string Authorization,
        CancellationToken cancellationToken = default)
    {
        // show this vedio https://www.youtube.com/watch?v=pDtDEVbEDdQ&list=PL3ewn8T-zRWgO-GAdXjVRh-6thRog6ddg&index=16
        try
        {
            if (string.IsNullOrEmpty(Authorization))
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new List<string> { "You should send a token" }
                });


            if (!ModelState.IsValid)
                return BadRequest(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = ModelState.Values
                                .SelectMany(x => x.Errors)
                                .Select(x => x.ErrorMessage)
                                .ToList()
                });

            var userRoles = _serviceManager.TokenService.GetValueFromToken(Authorization).Split(',');
            if (!userRoles.Any(x => x == nameof(UserRoles.Manager) || x == nameof(UserRoles.Admin)))
                return Unauthorized(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Errors = new List<string> { "You are not authorized to create a city" }
                });


            var Review = _mapper.Map<Review>(model);
            Review.UserId = _serviceManager.TokenService.GetValueFromToken(Authorization, "Id");
            Review.CreatedAtUtc = DateTime.Now;
            Review.ModifiedAtUtc = DateTime.Now;


            var createdReview = await _unitOfWork.ReviewRepository.AddAsync(Review);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Details), new { id = createdReview.Id }, new SuccessResponse
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Review is created successfully",
                Result = _mapper.Map<ReviewResponseDTO>(createdReview)
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Errors = new List<string> { "Internal Server Error", ex.Message }
            });

        }
    }





    [HttpPut("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<ActionResult> Update([FromForm] ReviewUpdateRequestDTO model,
        [FromHeader] string Authorization,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new List<string> { "You should send a valid token" }
                });

            if (!ModelState.IsValid)
                return BadRequest(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = ModelState.Values
                                .SelectMany(x => x.Errors)
                                .Select(x => x.ErrorMessage)
                                .ToList()
                });

            var userRoles = _serviceManager.TokenService.GetValueFromToken(Authorization).Split(',');
            if (!userRoles.Any(x => x == nameof(UserRoles.Manager) || x == nameof(UserRoles.Admin)))
                return Unauthorized(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Errors = new List<string> { "You are not authorized to update a city" }
                });

            var Review = await _unitOfWork.ReviewRepository.GetByIdAsync(model.Id);

            if (Review is null)
                return NotFound(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Errors = new List<string> { "Review not found" }
                });

            Review = _mapper.Map(model, Review);

            Review.ModifiedAtUtc = DateTime.Now;
            _unitOfWork.ReviewRepository.Update(Review);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Review is updated successfully",
                Result = _mapper.Map<ReviewResponseDTO>(Review)
            });

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Errors = new List<string> { "Internal Server Error", ex.Message }
            });
        }
    }






    [HttpDelete("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<ActionResult> Delete([FromQuery] string id,
        [FromHeader] string Authorization,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(Authorization))
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new List<string> { "You should send a valid token" }
                });

            if (!Guid.TryParse(id, out Guid GuidId))
                return BadRequest(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new List<string> { "Invalid Review Id" }
                });

            var userRoles = _serviceManager.TokenService.GetValueFromToken(Authorization).Split(',');
            if (!userRoles.Any(x => x == nameof(UserRoles.Manager) || x == nameof(UserRoles.Admin)))
                return Unauthorized(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Errors = new List<string> { "You are not authorized to change user role" }
                });


            var Review = await _unitOfWork.ReviewRepository.GetByIdAsync(GuidId);
            if (Review is null)
                return NotFound(new ErrorResponse
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Errors = new List<string> { "Review not found" }
                });


            _unitOfWork.ReviewRepository.Delete(Review);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Review is deleted successfully",
                Result = _mapper.Map<ReviewResponseDTO>(Review)
            });

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Errors = new List<string> { "Internal Server Error", ex.Message }
            });
        }
    }




    */
}
