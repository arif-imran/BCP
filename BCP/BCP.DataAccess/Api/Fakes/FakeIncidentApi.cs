using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCP.Common;
using BCP.Common.Models;
using BCP.DataAccess.Api;
using BCP.DataAccess.Model;

namespace BCP.DataAccess.Api
{
    public class FakeIncidentApi : IIncidentApi
    {
        public async Task<IEnumerable<IncidentType>> GetIncidentTypeList(string location)
        {
            await Task.Delay(SharedConfig.FakeDelay);
            var result = new List<IncidentType>()
                {
                new IncidentType { Category = "Accident Involving People", Description = "Non-fatal injury / accident to staff or 3rd party", Severity = IncidentSeverity.Bronze,HowToRespond ="dfhdsafdsdfg", ContactDetails = new Contact{ Phone1= "01020152487",Phone2= "01236487962", FirstName="Mohammed", LastName="Sadiq", Email="Mohammed.sadiq@Grosvenor.com", JobTitle="Developer" } },
                    new IncidentType { Category = "Accident Involving People", Description = "Missing staff (eg loan worker)", Severity = IncidentSeverity.Silver },
                new IncidentType { Category = "Accident Involving People", Description = "Single fatality to staff or 3rd party", Severity = IncidentSeverity.Silver,HowToRespond ="dfhdsafdsdfg", ContactDetails = new Contact{ Phone1= "0123456789",Phone2= "0712345678", FirstName="Stewart", LastName="Cope", Email="Stewart.Cope@Grosvenor.com", JobTitle="App Developer" }, BackupContact= new Contact{ Phone1 = "0987654321", Phone2 = "0198765432", FirstName = "James", LastName = "Bond", Email = "James.Bond@Grosvenor.com", JobTitle = "Spy" }},
                    new IncidentType { Category = "Accident Involving People", Description = "Multiple fatalities on a Grosvenor property", Severity = IncidentSeverity.Gold },
                    new IncidentType { Category = "Buildings and Property", Description = "Asbestos", Severity = IncidentSeverity.Bronze },
                    new IncidentType { Category = "Buildings and Property", Description = "Fire / flood / collapse / business interruption in non-Grosvenor managed property", Severity = IncidentSeverity.Bronze },
                    new IncidentType { Category = "Buildings and Property", Description = "Significant business interruption that affects more than one Grosvenor managed property", Severity = IncidentSeverity.Silver },
                    new IncidentType { Category = "Buildings and Property", Description = "Major fire / flood / business interruption in a Grosvenor managed property", Severity = IncidentSeverity.Silver },
                    new IncidentType { Category = "Buildings and Property", Description = "24hr+ interruption to a Grosvenor place of business", Severity = IncidentSeverity.Gold },
                    new IncidentType { Category = "Buildings and Property", Description = "24hr+ interruption to a Grosvenor place of business", Severity = IncidentSeverity.Gold },
                    new IncidentType { Category = "Data Loss", Description = "Suspected penetration of systems where data loss or disruption to business is deemed unlikely ", Severity = IncidentSeverity.Bronze },
                    new IncidentType { Category = "Data Loss", Description = "Confirmed penetration of systems where data loss or disruption to a particular business area is deemed likely", Severity = IncidentSeverity.Silver },
                    new IncidentType { Category = "Data Loss", Description = "Significant ransom demands that indicate a data breach", Severity = IncidentSeverity.Gold },
                    new IncidentType { Category = "Enforcement and Terrorism", Description = "Enforcement threat", Severity = IncidentSeverity.Bronze },
                    new IncidentType { Category = "Enforcement and Terrorism", Description = "Terrorism (warning or event) threatening Grosvenor assets", Severity = IncidentSeverity.Gold },
                    new IncidentType { Category = "Media Interest", Description = "Of minor 'media' interest", Severity = IncidentSeverity.Bronze },
                    new IncidentType { Category = "Media Interest", Description = "Of significant media interest (fraud / reputation)", Severity = IncidentSeverity.Silver },
                    new IncidentType { Category = "Media Interest", Description = "Of major media interest. This includes loss of data through error or criminal act", Severity = IncidentSeverity.Gold },
                    new IncidentType { Category = "Near Misses", Description = "Near Miss", Severity = IncidentSeverity.Bronze },
                    new IncidentType { Category = "Near Misses", Description = "Significant near miss", Severity = IncidentSeverity.Silver }
            };
            foreach (var incType in result)
            {
                incType.HowToRespond = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " + incType.Description;
            }
            return result;
        }
    }
}

