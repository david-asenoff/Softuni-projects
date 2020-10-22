﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.Data
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserTrips = new HashSet<UserTrip>();
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
        public virtual ICollection<UserTrip> UserTrips { get; set; }
    }
}
