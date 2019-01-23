using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCP.Common;
using BCP.DataAccess.Model;

namespace BCP.DataAccess.Api
{
    public class FakeContactsApi : IContactsApi
    {
        public async Task<EmergencyContactsContent> GetEmergencyContactsContent(string location)
        {
            await Task.Delay(SharedConfig.FakeDelay);
            return new EmergencyContactsContent
            {
                EmergencyContacts =
                    new List<EmergencyContact>()
                {
                    new EmergencyContact() { Id = 1, Name = "Canossa Hospital", Address = "1 Old Peak Road, Hong Kong", Telephone = "1234 5678", Latitude = 22.277317, Longitude = 114.154344, Type = EmergencyContactType.Hospital },
                    new EmergencyContact() { Id = 2, Name = "Central District Police Station", Address = "2 Chung Kong Road, Sheung Wan, Hong Kong", Telephone = "1234 5678", Latitude = 22.288757, Longitude = 114.149426, Type = EmergencyContactType.PoliceStation },
                    new EmergencyContact() { Id = 3, Name = "Central Fire Station", Address = "15 Cotton Tree Drive, Central, Hong Kong", Telephone = "1234 5678", Latitude = 22.278145, Longitude = 114.161521, Type = EmergencyContactType.FireStation },
                    new EmergencyContact() { Id = 4, Name = "Hong Kong Adventist Hospital", Address = "40 Stubbs Road, Hong Kong", Telephone = "1234 5678", Latitude = 22.263257, Longitude = 114.184100, Type = EmergencyContactType.Hospital },
                    new EmergencyContact() { Id = 5, Name = "Hong Kong Sanatorium & Hospital Limited", Address = "2 Village Road, Happy Valley, Hong Kong", Telephone = "1234 5678", Latitude = 22.269541, Longitude = 114.182963, Type = EmergencyContactType.Hospital },
                    new EmergencyContact() { Id = 6, Name = "St. Paul's Hospital", Address = "2 Eastern Hospital Road, Causeway Bay, Hong Kong", Telephone = "1234 5678", Latitude = 22.278790, Longitude = 114.187934, Type = EmergencyContactType.Hospital },
                    new EmergencyContact() { Id = 7, Name = "Queen Mary Hospital (public hospital)", Address = "102, Pokfulam Road, Hong Kong", Telephone = "1234 5678", Latitude = 22.269828, Longitude = 114.131519, Type = EmergencyContactType.Hospital },
                    new EmergencyContact() { Id = 8, Name = "Western Division Police Station", Address = "280 Des Voeux Road West, Hong Kong", Telephone = "1234 5678", Latitude = 22.287785, Longitude = 114.140458, Type = EmergencyContactType.PoliceStation },
                    new EmergencyContact() { Id = 9, Name = "Wan Chai Division Police Station", Address = "1 Arsenal Street, Wanchai, Hong Kong", Telephone = "1234 5678", Latitude = 22.278680, Longitude = 114.168273, Type = EmergencyContactType.PoliceStation },
                },
                NationalEmergencyContacts = new List<NationalEmergencyNumber>()
                {
                    new NationalEmergencyNumber() { Number = "910", IsPolice= true,IsFire=false,IsAmbulance=false,IsHealthAndSafetyExecutive=false },
                    new NationalEmergencyNumber() { Number = "920", IsPolice= true,IsFire=false,IsAmbulance=true,IsHealthAndSafetyExecutive=false},
                    new NationalEmergencyNumber() { Number = "0207 123 4567", IsPolice= true,IsFire=false,IsAmbulance=false,IsHealthAndSafetyExecutive=true},

                    //new NationalEmergencyNumber() { Name = "Police", PhoneNumber = "910" },
                    //new NationalEmergencyNumber() { Name = "Fire ", PhoneNumber = "920" }, 
                    //new NationalEmergencyNumber() { Name = "Ambulance", PhoneNumber = "920" },
                    //new NationalEmergencyNumber() { Name = "Health and Safety Executive", PhoneNumber = "0207 123 4567" },

                    //new NationalEmergencyNumber() { Name = "Police Fire & Ambulance", PhoneNumber = "910" },
                    //new NationalEmergencyNumber() { Name = "Health and Safety Executive", PhoneNumber = "0207 123 4567" },
                }
            };
        }
    }
}

