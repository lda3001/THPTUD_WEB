using System;
using System.Collections.Generic;

namespace TH_Harmic.Models;

public partial class TbOrder
{
    public int OrderId { get; set; }

    public string? Code { get; set; }

    public string? CustomerName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? TotalAmount { get; set; }

    public int? Quanlity { get; set; }

    public int? OrderStatusId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual TbOrderStatus? OrderStatus { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();
}
