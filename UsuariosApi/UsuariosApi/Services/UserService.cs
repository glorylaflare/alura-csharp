using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }
    
    public async Task CreateUserAsync(CreateUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        var result = await _userManager.CreateAsync(user, dto.Password);
        
        if (!result.Succeeded) throw new ApplicationException("Failed to create user");
    }

    public async Task<string> LoginAsync(LoginUserDto dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
        
        if (!result.Succeeded) throw new ApplicationException("Failed to login");

        var user = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(u => u.NormalizedUserName == dto.Username.ToUpper());
        
        var token = _tokenService.GenerateToken(user);

        return token;
    }
}