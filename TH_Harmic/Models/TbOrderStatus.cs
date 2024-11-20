using System;
using System.Collections.Generic;

namespace TH_Harmic.Models;

public partial class TbOrderStatus
{
    public int OrderStatusId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
