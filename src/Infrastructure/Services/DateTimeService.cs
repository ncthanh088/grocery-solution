using System;
using Grocery.Application.Common.Interfaces;

namespace Grocery.Infrastructure.Service
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}