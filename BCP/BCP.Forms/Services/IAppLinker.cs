//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IAppLinker.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IAppLinker.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Services
{
    /// <summary>
    /// App linker.
    /// </summary>
    public interface IAppLinker
    {
        /// <summary>
        /// Opens the link.
        /// </summary>
        /// <param name="URL">the URL.</param>
        /// <param name="FallBackURL">Fall back URL.</param>
        void OpenLink(string URL,string FallBackURL);
    }
}
