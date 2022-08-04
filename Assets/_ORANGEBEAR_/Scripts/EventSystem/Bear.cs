#region Header

// Developed by Onur ÖZEL

#endregion

using System;
using UnityEngine;

namespace _ORANGEBEAR_.EventSystem
{
    public abstract class Bear : MonoBehaviour
    {
        #region Protected Methods

        protected void Roar(Action<object[]> eventName, params object[] args)
        {
            eventName?.Invoke(args);
        }

        #endregion
    }
}