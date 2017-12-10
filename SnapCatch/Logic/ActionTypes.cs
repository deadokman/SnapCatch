namespace SnapCatch.Logic
{
    /// <summary>
    /// Avaliable screen keybinds type, enum field name should compare to settings name for auto-binding keys
    /// Доступные типы кейбиндингов
    /// </summary>
    public enum ActionTypes
    {
        /// <summary>
        /// Capture square screen area
        /// </summary>
        SquareAreaScreenKey = 0,

        /// <summary>
        /// Capture active monitor screen
        /// </summary>
        ActiveScreenScreenKey = 1,

        /// <summary>
        /// Capture active window screen
        /// </summary>
        ActiveWindowScreenKey = 2
    }
}
