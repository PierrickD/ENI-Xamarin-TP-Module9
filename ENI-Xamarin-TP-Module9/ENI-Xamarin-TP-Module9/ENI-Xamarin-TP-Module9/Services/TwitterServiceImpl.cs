using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using ENI_Xamarin_TP_Module9.Entities;

namespace ENI_Xamarin_TP_Module9.Services
{
    public class TwitterServiceImpl : ITwitterService
    {
        public List<Tweet> TweetsList
        {
            get
            {
                User user = new User() { Login = "test", Password = "password"};
                return new List<Tweet>()
                {
                    new Tweet(){User = user, Data ="Un tweet tres interessent ", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="Un autre tweet tres interessent", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="Un tweet pas tres interessent", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="Celui la l'est encore moins", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="Bonjour!", CreatedAt = DateTime.Now}
                };
            }
        }

        public string Authenticate(User user)
        {
            bool haveError = false;
            StringBuilder stringBuilder = new StringBuilder();

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                if (String.IsNullOrEmpty(user.Login) || user.Login.Length < 3)
                {
                    haveError = true;
                    stringBuilder.Append("L'identifiant ne peut pas être null et doit posséder au moins 3 caractères.");
                }

                if (String.IsNullOrEmpty(user.Password) || user.Password.Length < 6)
                {
                    if (haveError)
                    {
                        stringBuilder.Append("\n");
                    }
                    haveError = true;
                    stringBuilder.Append("Le mot de passe ne peut pas être null et doit posséder au moins 6 caractères.");
                }

                if (!TweetsList.Select(x => x.User).Any(x => x.Login == user.Login && x.Password == user.Password))
                {
                    if (haveError)
                    {
                        stringBuilder.Append("\n");
                    }
                    haveError = true;
                    stringBuilder.Append("Identifiant invalide");
                }
            }
            else
            {
                stringBuilder.Append("Pas de connexion internet.");
            }

            return stringBuilder.ToString();
        }
    }
}
