using System;
using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.UserDTOs;

namespace MahalliyMarket.Services.Interfaces;

public interface IUserService
{
      //Post
      Task<ApiResponse<UserResponseDTO>> Registration(UserRegistrationDTO userRegistrationDTO);

      //Get
      Task<ApiResponse<UserResponseDTO>> Login(UserLoginDTO userLoginDTO);

      //Put
      Task<ApiResponse<ConfirmationResponse>> Logout(UserLoginDTO userLoginDTO);

      //Delete
      Task<ApiResponse<ConfirmationResponse>> DeleteCurrentUser(UserLoginDTO userLoginDTO);
}
