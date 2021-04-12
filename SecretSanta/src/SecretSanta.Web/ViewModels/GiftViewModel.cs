using System;
using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Web.ViewModels
{
    public class GiftViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string URL { get; set; } = "";
        [Display(Name = "URL")]
        public int Priority { get; set; } = 1;  
        public int UserId { get; set; }
    }
}