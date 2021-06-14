using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer
{
    public class AuthenticationResponseDTO
    {
        public string Token { get; set; }
        public bool IsAuthenticated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static AuthenticationResponseDTO GetAuthenticationResponse(string token = "", bool isAuthenticated = false,string firstName = "", string lastName = "")
        {
            return new AuthenticationResponseDTO
            {
                IsAuthenticated = isAuthenticated,
                Token = token,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}
