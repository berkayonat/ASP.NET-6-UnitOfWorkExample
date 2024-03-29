﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UnitOfWorkExample.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double Rating { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [JsonIgnore]
        public Country? Country { get; set; }
    }
}
