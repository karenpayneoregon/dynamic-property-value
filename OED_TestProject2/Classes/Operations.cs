using System;
using System.ComponentModel;

namespace OED_TestProject2.Classes
{
    public class Operations
    {
        public static string Common(object sender) => sender switch
        {
            Customer customer => $"Customer id: {customer.Id} Name: {customer.Name}",
            Order order => $"Order id: {order.Id} Product: {order.Product}",
            _ => throw new InvalidEnumArgumentException("Unknown")
        };

    }
}