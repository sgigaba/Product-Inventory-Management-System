﻿namespace Product_Inventory_Management_System.Validators
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    using System.Linq;

    public static class ModelStateExtensions
    {
        public static string ToFullErrorString(this ModelStateDictionary modelState)
        {
            var messages = modelState.Values.SelectMany(_ => _.Errors.Select(error => error.ErrorMessage));
            return string.Join(" \n", messages.Distinct());
        }
    }
}
