﻿namespace CarRental.Models
{
    public class Car:BaseEntity
    {
        
        public string Brand { get; set; }=string.Empty;
        public string Model { get; set; }=string.Empty ;
        public int CategoryId { get; set; }
        public Category Category { get; set; } // navigation property
        public int Price { get; set; }
        public bool Status { get; set; }
    }
}
