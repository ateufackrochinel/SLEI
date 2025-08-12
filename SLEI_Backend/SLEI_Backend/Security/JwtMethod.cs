using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace SLEI_Backend.Security
{
    public static class JwtMethod
    {

        public static void AddCustumAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
             

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            }
            ).AddJwtBearer(options =>
            {

                
                string key = configuration["JWT:key"];
              // string maclef = "toto123jjubgbgbdbgvgrteouuiibgg878485fffffbbhnjjwe344gggggpokjmjnjhnjnhnhnhbhnhnjnjnjmjmjnjnjmnjmjmjmjkkmjnhnhbgccccc";
               options.SaveToken = true; // pour enregistrer le token 
               options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()

               { // Pour definir les parametres de validation du token
                   IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)), // Ici on crypte la cle de communication entre le client et le serveur 
                   ValidateAudience = false,
                   ValidateActor = false,
                   ValidateIssuer = false,
                   ValidateLifetime = true, //Pour autoriser le temps d'expiration du Token 
                   
               };


           });

        }
    }
}
