using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Data
{
    public class Card
    {
        public Card()
        {
            Id = Guid.NewGuid().ToString();
            UserCards = new HashSet<UserCard>();
        }
        public string Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Keyword { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int Attack { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Health { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}
