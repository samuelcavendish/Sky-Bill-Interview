using System;

namespace Sky.Services.LogManagers
{
    public interface ILogManager
    {
        void LogError(String errorMessage, Exception ex = null);
    }
}
