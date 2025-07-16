using System;
using System.Net;
using MahalliyMarket.Data;
using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.UserDTOs;
using MahalliyMarket.Models;
using MahalliyMarket.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MahalliyMarket.Services;

public class UserService : IUserService
{
      private readonly MahalliyDBContext _context;

      public UserService(MahalliyDBContext context)
      {
            _context = context;
      }


      public async Task<ApiResponse<UserResponseDTO>> Registration(UserRegistrationDTO userRegistrationDTO)
      {
            var existingUser = await _context.users.FirstOrDefaultAsync(u => u.email == userRegistrationDTO.email);
           
            if (existingUser != null)
            {
                  return new ApiResponse<UserResponseDTO>(HttpStatusCode.BadRequest, "User already exists.");
            }

            var user = new User
            {
                  first_name = userRegistrationDTO.first_name,
                  last_name = userRegistrationDTO.last_name,
                  middle_name = userRegistrationDTO.middle_name ?? "",
                  email = userRegistrationDTO.email,


        //Create password hash and salt

            PasswordHasher.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);


                  password_hash = userRegistrationDTO.password_hash ?? userRegistrationDTO.password] = userRegistrationDTO.password

               
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var responseDto = new UserResponseDTO
            {
                  Id = user.Id,
                  Name = user.Name,
                  Email = user.Email
            };

            return new ApiResponse<UserResponseDTO>
            {
                  Success = true,
                  Message = "Registration successful.",
                  Data = responseDto
            };
      }

      public Task<ApiResponse<UserResponseDTO>> Login(UserLoginDTO userLoginDTO)
      {
            throw new NotImplementedException();
      }

      public Task<ApiResponse<ConfirmationResponse>> Logout(UserLoginDTO userLoginDTO)
      {
            throw new NotImplementedException();
      }

      public Task<ApiResponse<ConfirmationResponse>> DeleteCurrentUser(UserLoginDTO userLoginDTO)
      {
      }
}
