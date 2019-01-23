//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ApiRequestHelper.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ApiRequestHelper.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using BCP.Common;

    /// <summary>
    /// API request helper.
    /// </summary>
    public class ApiRequestHelper
    {
        ////public static string GetFullBCPDocument()
        ////{
        ////    return $"{SharedConfig.APIEndPoint}GetBCPDocument";
        ////    //return "http://www.pdf995.com/samples/pdf.pdf";
        ////}

        /// <summary>
        /// Gets the full BCPD ocument.
        /// </summary>
        /// <returns>The full BCPD ocument.</returns>
        public static string GetFullBCPDocument()
        {
            return $"{SharedConfig.APIEndPoint}GetBCPDocument";
        }

        /// <summary>
        /// Gets the incident list.
        /// </summary>
        /// <returns>The incident list.</returns>
        /// <param name="location">the Location.</param>
        public static string GetIncidentList(string location)
        {
            return $"{SharedConfig.APIEndPoint}GetAllIncidentTypes?location={location}";
        }

        /// <summary>
        /// Gets the respond list.
        /// </summary>
        /// <returns>The respond list.</returns>
        public static string GetRespondList()
        {
            return $"{SharedConfig.APIEndPoint}GetRespond";
        }

        /// <summary>
        /// Gets the resources list.
        /// </summary>
        /// <returns>The resources list.</returns>
        public static string GetResourcesList()
        {
            return $"{SharedConfig.APIEndPoint}GetAllResources";
        }

        /// <summary>
        /// Gets the content of the respond.
        /// </summary>
        /// <returns>The respond content.</returns>
        /// <param name="role">the Role.</param>
        /// <param name="location">the Location.</param>
        public static string GetRespondContent(string role, string location)
        {
            return $"{SharedConfig.APIEndPoint}GetRespondContent?role={role}&location={location}";
        }

        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <returns>The user profile.</returns>
        /// <param name="username">the Username.</param>
        public static string GetUserProfile(string username)
        {
            return $"{SharedConfig.APIEndPoint}GetUserProfile?username={username}";
        }

        /// <summary>
        /// Gets the content of the emergency contacts.
        /// </summary>
        /// <returns>The emergency contacts content.</returns>
        /// <param name="location">the Location.</param>
        public static string GetEmergencyContactsContent(string location)
        {
            return $"{SharedConfig.APIEndPoint}GetAllEmergencyContacts?location={location}";
        }

        /// <summary>
        /// Gets the call tree.
        /// </summary>
        /// <returns>The call tree.</returns>
        /// <param name="location">the Location.</param>
        public static string GetCallTree(string location)
        {
            return $"{SharedConfig.APIEndPoint}GetCallTree?location={location}";
        }

        /// <summary>
        /// Gets the user profile pic.
        /// </summary>
        /// <returns>The user profile pic.</returns>
        /// <param name="username">the Username.</param>
        public static string GetUserProfilePic(string username)
        {
            return $"{SharedConfig.APIEndPoint}GetUserprofilepicture?username={username}";
        }

        /// <summary>
        /// Gets all user locations.
        /// </summary>
        /// <returns>The all user locations.</returns>
        public static string GetAllUserLocations()
        {
            return $"{SharedConfig.APIEndPoint}GetAllLocations";
        }

        /// <summary>
        /// Gets all user roles.
        /// </summary>
        /// <returns>The all user roles.</returns>
        public static string GetAllUserRoles()
        {
            return $"{SharedConfig.APIEndPoint}GetAllRoles";
        }
    }
}
