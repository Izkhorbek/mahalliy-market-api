using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.UserDTOs;

namespace MahalliyMarket.Services.Interfaces;

public interface IUserService
{
    //Post
    Task<ApiResponse<ConfirmationResponse>> RegistrationAsync(UserRegistrationDTO userRegistrationDTO);

    //Get
    Task<ApiResponse<UserResponseDTO>> LoginAsync(UserLoginDTO userLoginDTO);

    //Put
    Task<ApiResponse<ConfirmationResponse>> LogoutAsync(UserLoginDTO userLoginDTO);

    //Delete
    Task<ApiResponse<ConfirmationResponse>> DeleteCurrentUserAsync(UserLoginDTO userLoginDTO);
}
