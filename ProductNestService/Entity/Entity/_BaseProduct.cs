﻿namespace ProductNestService.Entity.Entity;

public abstract class _BaseProduct:_Base
{
    public string Title { get; set; }
    public string BodyHtml { get; set; }
    public string Vendor { get; set; }
    public string ProductType { get; set; }
    public string Tags { get; set; }
    public string Status { get; set; }
    public string AdminGraphqlApiId { get; set; }
}
