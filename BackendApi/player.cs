using Microsoft.AspNetCore.SignalR;

namespace BackendApi.Models 
{
    public class Player
    {
          public int Id { get; set; }
          public string? Name { get; set; }
          public string? Description { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Os { get; set; } 
        public string? FlagNum { get; set; }
        public int Resets { get; set; }

    }

    public class Flags
    {
        public int Id { get; set; }
        public string? Box { get; set; }
        public string? Flag { get; set; }
    }
}