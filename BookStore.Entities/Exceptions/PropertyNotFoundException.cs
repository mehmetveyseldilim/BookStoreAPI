using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities.Exceptions
{
public class PropertyNotFoundException : BadRequestException
{
    public PropertyNotFoundException(string propertyName) : base($"Property with name '{propertyName}' was not found")
    {
        
    }
}
}