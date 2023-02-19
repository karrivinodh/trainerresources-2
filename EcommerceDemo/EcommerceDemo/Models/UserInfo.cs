using System;
using System.Collections.Generic;

namespace EcommerceDemo.Models;

public partial class UserInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? State { get; set; }

    public decimal Pincode { get; set; }

    public decimal PhoneNumber { get; set; }

    public string Country { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
