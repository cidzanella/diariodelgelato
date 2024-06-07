﻿
namespace DiarioDelGelato.Domain.Entities   
{
    // a team member may have an application user 
    // an User may have a team member or not: example - user Admin that is not a TeamMember
    public class User
    {
        public User() => this.Id = Guid.NewGuid();

        public Guid Id { get; set; }

        public int TeamMemberId { get; set; }

        public bool IsEnable { get; set; }

        public string? UserName { get; set; } //for logon

        public string? PasswordHash { get; set; }

        public string? PasswordSalt { get; set; }

        public bool IsAdmin { get; set; }

        // public string Role { get; set; } // for while using isAdmin as the only special role

    }
}
