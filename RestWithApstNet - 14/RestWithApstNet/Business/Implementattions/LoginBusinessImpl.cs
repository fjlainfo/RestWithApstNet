using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using RestWithApstNet.Model;
using RestWithApstNet.Repository;
using RestWithApstNet.Security.Configuration;

namespace RestWithApstNet.Business.Implementattions
{
    public class LoginBusinessImpl : ILoginBusiness
    {
        private IUserRepository _repository;
        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;

        public LoginBusinessImpl(IUserRepository repository, SigningConfiguration signingConfiguration, TokenConfiguration tokenConfiguration)
        {
            _repository = repository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        public object FindByLogin(User user)
        {
            bool credentialIsValid = false;
            if( user != null && !string.IsNullOrWhiteSpace(user.Login))
            {
                var baseUser = _repository.FindByLogin(user.Login);
                credentialIsValid = (baseUser != null && user.Login == baseUser.Login && user.AccessKey == baseUser.AccessKey);

            }
            if (credentialIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity
                (
                    new GenericIdentity(user.Login, "Login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Login)
                    }
                );

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);
                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObjetc(createDate, expirationDate, token);
            }
            else {

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = DateTime.Now;
                string token = null;

                return ExceptionObjetc(createDate, expirationDate, token);
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            return handler.WriteToken(securityToken);
        }

        private object ExceptionObjetc(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                autenticated = false,
                created = createDate.ToString("yyyy-mm-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-mm-dd HH:mm:ss"),
                accessToken = token,
                message = "Autenticação falhou!"
            };
        }

        private object SuccessObjetc(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-mm-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-mm-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}



