﻿using ProductNest.Entity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.Entity.Entity;

public class Warehouse : _Base
{
    public string Zone { get; set; }
    public string Aisle { get; set; }
    public string Location { get; set; }
    public string Shelf { get; set; }
    public string Rack { get; set; }
    public string Bay { get; set; }

    [ForeignKey("Variant")]
    public Guid VariantId { get; set; }
    public Variant Variant { get; set; }
    public List<Inventory> Inventory { get; set; }
    public Warehouse()
    {
        Inventory = new List<Inventory>();
    }
}