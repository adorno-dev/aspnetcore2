// Todo.cs ~ Todo entity
//
// Authors:
//      Adorno <adorno@protonmail.com>
//

using System.ComponentModel.DataAnnotations;

namespace AspnetCore2.Mvc.Localization.Models
{
    /// <summary>
    /// Todo entity
    /// </summary>
    public class Todo
    {
        /// <summary>
        /// Properties with localization applied on render
        /// </summary>
        /// <returns></returns>
        [Display(Name = "Text")]
        [Required(ErrorMessage = "TextRequired")]
        public string Text { get; set; }

        /// <summary>
        /// Properties with localization applied on render
        /// </summary>
        /// <returns></returns>
        [Display(Name = "Duration")]
        [Required(ErrorMessage = "DurationRequired")]
        public float Duration { get; set; }
    }
}