﻿namespace SignalR.Models
{
    public class LoginCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
