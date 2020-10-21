﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Data
{
    public class UserTrip
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
