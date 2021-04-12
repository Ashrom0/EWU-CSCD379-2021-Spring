using System;
using System.Collections.Generic;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData
    {
        public static List<GiftViewModel> Gifts = new List<GiftViewModel>{
            new GiftViewModel {Id = 0, Title = "Gift Title", Description = "Gift Description", URL ="Example.com", Priority = 1, UserId = 0},
        };

        public static List<UserViewModel> Users = new List<UserViewModel>{
            new UserViewModel {Id = 0, FirstName = "Bob", LastName = "Smith"},
        };

        public static List<GroupViewModel> Groups = new List<GroupViewModel>{
            new GroupViewModel {Id = 0, GroupName = "Group1"},
            
        };
    }
}