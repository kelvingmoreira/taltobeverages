﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talto.WebApi.ViewModels
{
    public class CashbackDto
    {
        public CashbackDto() { }

        public CashbackDto(string beverage, DayOfWeek dayOfWeek, double value)
        {
            Beverage = beverage;
            DayOfWeek = dayOfWeek.ToString().ToLower();
            Value = value;
        }
        public string Beverage { get; set; }
        public string DayOfWeek { get; set; }

        public double Value { get; set; }
    }
}