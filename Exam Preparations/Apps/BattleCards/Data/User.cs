using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Data
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserCards = new HashSet<UserCard>();
        }
        public string Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}
