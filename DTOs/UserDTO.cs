﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.DTOs
{
    public class UserDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string Email { get; set; }

        public string Avatar_img { get; set; }
    }
}
