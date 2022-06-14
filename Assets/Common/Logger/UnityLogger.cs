using System;
using UnityEngine;

namespace Assets.Common.Logger
{
    public class UnityLogger : ILogger
    {
        public UnityLogger(string name = "")
        {
            if (string.IsNullOrEmpty(name))
                Name = GetType().Name;
        }

        public string Name { get; }

        public void Log(string message)
        {
            Debug.Log($"[ {DateTime.Now.ToShortTimeString()} ]: {message}");
        }

        public void LogError(string message)
        {
            Debug.LogError($"[ {DateTime.Now.ToFileTime()} ]: {message}");
        }
    }
}
