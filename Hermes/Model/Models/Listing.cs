﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Model.Models
{
    public class Listing
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public bool Active { get; }
        public int Region { get; }
        public int Views { get; }
        public int Category { get; }
        public bool Premium { get; }

        public Listing(int id, string name, string description, bool active, int region, int views, int category, bool premium)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;
            Region = region;
            Views = views;
            Category = category;
            Premium = premium;
        }

    }
}