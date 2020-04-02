using System;
using System.Collections.Generic;
using System.Text;
using ENI_Xamarin_TP_Module9.Entities;

namespace ENI_Xamarin_TP_Module9.Services
{
    public interface ITwitterService
    {
        String Authenticate(User user);
        List<Tweet> TweetsList { get; }
    }
}
