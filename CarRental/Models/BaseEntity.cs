﻿namespace CarRental.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.UtcNow;
    }
}