#region Header

// Developed by Onur ÖZEL

#endregion

using System;

namespace _ORANGEBEAR_.EventSystem
{
    /// <summary>
    /// This class is used to store general Game Events.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameEvents<T>
    {
        #region General Game Events

        public static Action<T> OnGameStart;
        public static Action<T> OnGameComplete;
        public static Action<T> GetLevelNumber;
        public static Action<T> NextLevel;

        #endregion

        #region UI Events

        public static Action<T> ActivatePanel;

        #endregion
    }
}