//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="Main.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   Main.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.IOS
{
    using UIKit;

    /// <summary>
    /// Application Class.
    /// </summary>
    public class Application
    {
        // This is the main entry point of the application.

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        private static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, AppConnectBinding.Constants.kACUIApplicationClassName, "AppDelegate");
        }
    }
}
