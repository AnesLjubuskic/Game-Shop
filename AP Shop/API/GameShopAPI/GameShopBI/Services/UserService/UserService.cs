using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameShopBI.Services.BaseService;
using System.Threading.Tasks;
using GameShopDA.DTO;
using GameShopDA.SearchModels;
using GameShopDA.DBModels;
using AutoMapper;
using GameShopDA.Repository.UserRepository;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace GameShopBI.Services.UserService
{
    public class UserService:BaseService<User,UserDto,UserSearch>,IUserService
    {
        public IUserRepository _userRepository { get; set; }
        public IConfiguration _configuration { get; set; }
        public UserService(IConfiguration configuration,IMapper mapper,IUserRepository userRepository):base(mapper,userRepository) 
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public User CreatePasswordHash(UserDto user)
        {
            var allUsers=_baseRepository.GetAll();
            for (int i = 0; i < allUsers.Result.Count; i++)
            {
                if (allUsers.Result[i].Email == user.Email)
                    return null;
            }
            var userDB = _mapper.Map<User>(user);
            userDB.Role = 0;
            dynamic passwordSalt;
            dynamic passwordHash;
            using (var hmac =new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            }
            userDB.PasswordSalt = passwordSalt;
            userDB.PasswordHash = passwordHash;
            _baseRepository.Insert(userDB);
            return userDB;
        }

        public UserJWTDto CreateToken(UserLoginDto user)
        {
            var userDB = _userRepository.GetByEmail(user.Email);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,userDB.Result.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:cred
                );  
            var jwt=new JwtSecurityTokenHandler().WriteToken(token);
            var userJwt = new UserJWTDto() { Id=userDB.Result.Id,jwt = jwt, role = userDB.Result.Role.ToString() };
            return userJwt;
        }
        public async Task<bool> VerifyHash(UserLoginDto user)
        {
            var userDB = await _userRepository.GetByEmail(user.Email);
            using (var hmac=new HMACSHA512(userDB.PasswordSalt))
            {
                var compHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                return compHash.SequenceEqual(userDB.PasswordHash);
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }
    }
}
