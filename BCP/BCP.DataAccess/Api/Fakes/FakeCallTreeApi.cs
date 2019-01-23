using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCP.Common;
using BCP.Common.Models;
using BCP.DataAccess.Model;

namespace BCP.DataAccess.Api
{
    public class FakeCallTreeApi : ICallTreeApi
    {
        public async Task<IEnumerable<Contact>> GetCallTree(string location)
        {
            await Task.Delay(SharedConfig.FakeDelay);
            return new List<Contact>()
                {
                    new Contact() { FirstName = "Rebecca", LastName = "Jones", JobTitle = "Director of Retail", Phone1 = "02012345678", Phone2 = "07980123456", Email = "rebecca.jones@grosvenor.com", Avatar="https://hubmysite.grosvenor.com:443/User%20Photos/Profile%20Pictures/AHinterhaeuser_LThumb.jpg?t=63547898440" },
                    new Contact() { FirstName = "Stewart", LastName = "Cope", JobTitle = "Software Developer", Phone1 = "02012345678", Phone2 = "", Email = "stewart.cope@grosvenor.com", Avatar="person.jpg" },
                    new Contact() { FirstName = "Agris", LastName = "Belte", JobTitle = "Software Developer", Phone1 = "", Phone2 = "07980123456", Email = "agris.belte@grosvenor.com", Avatar="person.jpg" },
                    new Contact() { FirstName = "Mohammed", LastName = "Sadiq", JobTitle = "Software Developer", Phone1 = "02012345678", Phone2 = "07980123456", Email = "mohammed.sadiq@grosvenor.com", Avatar="person.jpg" },
                    new Contact() { FirstName = "Arif", LastName = "Imran", JobTitle = "Software Developer", Phone1 = "02012345678", Phone2 = "07980123456", Email = "arif.imran@grosvenor.com" , Avatar="person.jpg"},
                    new Contact() { FirstName = "Sadaqat", LastName = "Jeelani", JobTitle = "Software Developer", Phone1 = "02012345678", Phone2 = "07980123456", Email = "sadaqat.jeelani@grosvenor.com", Avatar="person.jpg" }
            };
        }
    }
}
