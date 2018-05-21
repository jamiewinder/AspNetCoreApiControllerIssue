using Microsoft.AspNetCore.Mvc.ModelBinding;
using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApiControllerExample
{
    public class OffsetDateTimeBinder : IModelBinder
    {
        // Methods (IModelBinder)
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(OffsetDateTime) &&
                bindingContext.ModelType != typeof(OffsetDateTime?))
            {
                return Task.CompletedTask;
            }
            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
            {
                return Task.CompletedTask;
            }
            var rawValue = val.FirstValue;
            if (rawValue == null && bindingContext.ModelType == typeof(OffsetDateTime?))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
            }
            else
            {
                var result = OffsetDateTimePattern.GeneralIso.Parse(rawValue);
                if (result.Success)
                {
                    bindingContext.Result = ModelBindingResult.Success(result.Value);
                }
                else
                {
                    bindingContext.ModelState.TryAddModelError(
                        bindingContext.ModelName,
                        "OffsetDateTime must be specified in strict ISO-8601 format");
                }
            }
            return Task.CompletedTask;
        }
    }
}
