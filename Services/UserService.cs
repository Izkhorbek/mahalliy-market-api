using MahalliyMarket.CommonUtils;
using MahalliyMarket.Data;
using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.UserDTOs;
using MahalliyMarket.Models;
using MahalliyMarket.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MahalliyMarket.Services;

public class UserService : IUserService
{
    private readonly MahalliyDBContext _context;

    public UserService(MahalliyDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<ConfirmationResponse>> RegistrationAsync(UserRegistrationDTO userRegistrationDTO)
    {
        // if The User Role is different then retun
        if (userRegistrationDTO.user_role == ERole.Customer || userRegistrationDTO.user_role == ERole.Seller)
        {
            // Check if user exists?
            var existingUser = await _context.users.FirstOrDefaultAsync(u => u.email == userRegistrationDTO.email);

            if (existingUser != null)
            {
                return new ApiResponse<ConfirmationResponse>(HttpStatusCode.BadRequest, "User already exists.");
            }

            // Convert original password
            string strPassword = CommonUtils.Decoder.DecodeBase64(userRegistrationDTO.password);

            PasswordHasher.CreatePasswordHash(strPassword, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                first_name = userRegistrationDTO.first_name,
                last_name = userRegistrationDTO.last_name,
                middle_name = userRegistrationDTO.middle_name,
                email = userRegistrationDTO.email,
                user_role = userRegistrationDTO.user_role,
                password_hash = passwordHash,
                password_salt = passwordSalt,
                phone_number = userRegistrationDTO.phone_number,
                date_birth = userRegistrationDTO.date_birth,
                province = userRegistrationDTO.province,
                city_district = userRegistrationDTO.city_district,
                mahalla = userRegistrationDTO.mahalla,
                street = userRegistrationDTO.street,
                postal_code = userRegistrationDTO.postal_code,
                latitude = userRegistrationDTO.latitude,
                longitude = userRegistrationDTO.longitude,
                created_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow,
                login_status = true
            };

            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new ApiResponse<ConfirmationResponse>(HttpStatusCode.OK, new ConfirmationResponse("Successfully created"));
        }

        return new ApiResponse<ConfirmationResponse>(HttpStatusCode.BadRequest, "User must be a Seller or a Customer.");
    }

    public async Task<ApiResponse<UserResponseDTO>> LoginAsync(UserLoginDTO userLoginDTO)
    {
        var existingUser = await _context.users.FirstOrDefaultAsync(user => user.email == userLoginDTO.email);

        string orgPassword = CommonUtils.Decoder.DecodeBase64(userLoginDTO.password);

        if (existingUser != null && PasswordHasher.VerifyPasswordHash(orgPassword, existingUser.password_hash, existingUser.password_salt))
        {
            // Check a user that isn't logged in 
            // Now by one device is available to log in at same time
            if (existingUser.login_status == true)
            {
                return new ApiResponse<UserResponseDTO>(HttpStatusCode.Forbidden, "User logged in already.");
            }

            var userResponse = new UserResponseDTO
            {
                first_name = existingUser.first_name,
                last_name = existingUser.last_name,
                middle_name = existingUser.middle_name,
                email = existingUser.email,
                password = userLoginDTO.password,
                phone_number = existingUser.phone_number,

                date_birth = existingUser.date_birth,
                province = existingUser.province,
                city_district = existingUser.city_district,
                mahalla = existingUser.mahalla,
                street = existingUser.street,
                postal_code = existingUser.postal_code,
                latitude = existingUser.latitude,
                longitude = existingUser.longitude
            };


            //Changed the user as logged in
            existingUser.login_status = true;

            await _context.SaveChangesAsync();

            return new ApiResponse<UserResponseDTO>(HttpStatusCode.OK, userResponse);
        }

        return new ApiResponse<UserResponseDTO>(HttpStatusCode.NotFound, "Username or Password is incorrect.Please, check again!");
    }

    public async Task<ApiResponse<ConfirmationResponse>> LogoutAsync(UserLoginDTO userLoginDTO)
    {
        var existingUser = await _context.users.FirstOrDefaultAsync(user => user.email == userLoginDTO.email);

        if (existingUser != null)
        {
            // Change the user as logged out
            existingUser.login_status = false;

            await _context.SaveChangesAsync();

            return new ApiResponse<ConfirmationResponse>(HttpStatusCode.OK, "User logged out.");
        }

        return new ApiResponse<ConfirmationResponse>(HttpStatusCode.NotFound, "User doesn't exist.");
    }

    public async Task<ApiResponse<ConfirmationResponse>> DeleteCurrentUserAsync(UserLoginDTO userLoginDTO)
    {
        var existingUser = await _context.users.FirstOrDefaultAsync(user => user.email == userLoginDTO.email);

        string strPassword = Decoder.DecodeBase64(userLoginDTO.password);

        if (existingUser != null && PasswordHasher.VerifyPasswordHash(strPassword, existingUser.password_hash, existingUser.password_salt))
        {
            _context.users.Remove(existingUser);

            await _context.SaveChangesAsync();

            return new ApiResponse<ConfirmationResponse>(HttpStatusCode.OK, "User is deleted successfully.");
        }

        return new ApiResponse<ConfirmationResponse>(HttpStatusCode.NotFound, "Somethi is wrong.");
    }
}
