﻿namespace HR_System.DTO.Register
{
    public record RegisterUserDTO
    (
      string UserName,
      string FullName,
      string Email,
      string Password,  
      string? Group 
      );
 
}
