﻿namespace LanguageFeatures.Models
{
    public static class MyExtentionMethods
    {
        public static decimal TotalPrices (this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach (Product prod in cartParam.Products)
            {
                total += prod.Price;
            }
            return total;
        }
    }
}