using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace BCP.DataAccess.Model
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }



        private string avatar;
        public string Avatar
        {
            get { return this.avatar; }
            set { this.avatar = value.Split(',')[0]; }
        }
        public string FullName { get { return FirstName + " " + LastName; } }
        // This probably shouldn't be here, maybe a separate class in ViewModels?
        public string NameSort
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FirstName) || FirstName.Length == 0)
                {
                    return "?";
                }

                return FirstName[0].ToString().ToUpper();
            }
        }
    }
}
