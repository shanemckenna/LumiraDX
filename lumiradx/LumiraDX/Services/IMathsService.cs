using System;
using System.Collections.Generic;
using System.Linq;
using LumiraDX.Models;

namespace LumiraDX.Services
{
    public interface IMathsService
    {        
        OperationResult PerformOperation(Operation operation);        
    }
}
