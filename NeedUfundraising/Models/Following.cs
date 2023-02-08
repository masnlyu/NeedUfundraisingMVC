﻿using System;
using System.Collections.Generic;

#nullable disable

namespace NeedUfundraising.Models
{
    public partial class Following
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
