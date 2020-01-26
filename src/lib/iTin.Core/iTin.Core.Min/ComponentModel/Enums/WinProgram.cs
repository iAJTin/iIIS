
namespace iTin.Core.Min.ComponentModel.Enums
{
    using System;

    using iTin.Core.Min.ComponentModel;

    /// <summary>
    /// Defines known widows os programs
    /// </summary>
    [Serializable]
    public enum WinProgram
    {
        /// <summary>
        /// Notepad program
        /// </summary>
        [EnumDescription("Notepad")]
        Notepad,

        /// <summary>
        /// Notepad++ program
        /// </summary>
        [EnumDescription("Notepad++")]
        NotepadPlusPlus,

        /// <summary>
        /// Paint program
        /// </summary>
        [EnumDescription("Paint")]
        Paint
    }
}
