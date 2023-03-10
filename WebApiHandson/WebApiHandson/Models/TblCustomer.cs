using System;
using System.Collections.Generic;

namespace WebApiHandson.Models;

public partial class TblCustomer
{
    public int CustId { get; set; }

    public string CustName { get; set; } = null!;

    public string CustAddress { get; set; } = null!;

    public string CustPhone { get; set; } = null!;
}
