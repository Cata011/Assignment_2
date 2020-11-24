using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;


namespace Assignment1.Data.Impl
{
    public class CloudAdultService : IAdultService
    {
        public  async Task AddAdultAsync(Adult adultToAdd)
        {
            HttpClient httpClient = new HttpClient();
            string adultSerialized = JsonSerializer.Serialize(adultToAdd);
            
            StringContent content = new StringContent(
                adultSerialized,
                Encoding.UTF8,
                "application/json"
                );

            HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:5001/adults", content); 
            Console.WriteLine(responseMessage.StatusCode.ToString());
            Console.WriteLine(responseMessage);
        }
        

        public async Task<IList<Adult>> ReadAllAdultsAsync(int? id, string? firstName, string? sex)
        {
            HttpClient httpClient = new HttpClient();
            string uri = "https://localhost:5001/adults";
            int sw = 0;
            if (!(id is null))
            {
                uri += $"?Id={id}";
                sw++;
            }
            
            if (!(firstName is null))
            {
                if (sw > 0)
                {
                    uri += $"&FirstName={firstName}";
                }
                else
                {
                    uri += $"?FirstName={firstName}";
                    sw++;
                }
                
            }
            
            if (!(sex is "Any"))
            {
                if (sw > 0)
                {
                    uri += $"&Sex={sex}";
                }
                else
                {
                    uri += $"?Sex={sex}";
                    sw++;
                }
            }

            Console.WriteLine(uri);
            string message = await httpClient.GetStringAsync(uri);
            IList<Adult> result = JsonSerializer.Deserialize<IList<Adult>>(message);
            sw = 0;
            return result;
        }

        public async Task<IList<Adult>> ReadAllAdultsAsync()
        {
            HttpClient httpClient = new HttpClient();
            string uri = "https://localhost:5001/adults";
            Console.WriteLine(uri);
            string message = await httpClient.GetStringAsync(uri);
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task UpdateAdultAsync(Adult adultToUpdate)       
        {
            HttpClient client = new HttpClient();
            
            string adultSerialized = JsonSerializer.Serialize(adultToUpdate);
            
            StringContent content = new StringContent(
                adultSerialized,
                Encoding.UTF8,
                "application/json"
            );
            
            HttpResponseMessage responseMessage = await client.PatchAsync("https://localhost:5001/adults/" + adultToUpdate.Id , content);     
            Console.WriteLine(adultToUpdate.Id);
            Console.WriteLine(responseMessage);
            Console.WriteLine(responseMessage.StatusCode.ToString());
        }

        public async Task DeleteAdultAsync(int adultToDeleteId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:5001/adults/" + adultToDeleteId); 
            Console.WriteLine(responseMessage.StatusCode.ToString());
        }
    }
}