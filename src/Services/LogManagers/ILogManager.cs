using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sky.Services.LogManagers
{
    public interface ILogManager
    {
        void LogError(String errorMessage, Exception ex = null);
    }
}
