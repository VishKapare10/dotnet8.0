using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiFilterDemo
{
    class Program
    {
        // Define User and Activity models
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Activity
        {
            public int UserId { get; set; }
            public string ActivityDescription { get; set; }
        }

        static async Task Main(string[] args)
        {
            // Fetch data from API 1 (Users)
            var users = await GetUsersFromApi();

            // Fetch data from API 2 (Activities)
            var activities = await GetActivitiesFromApi();

            // Extract user IDs from activities
            var activeUserIds = activities.Select(a => a.UserId).ToHashSet();

            // Filter users who have activities
            var filteredUsers = users.Where(u => activeUserIds.Contains(u.Id)).ToList();

            // Display filtered users
            Console.WriteLine("Filtered Users (who have activities):");
            foreach (var user in filteredUsers)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}");
            }
        }

        // Method to get users from API 1
        static async Task<List<User>> GetUsersFromApi()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
                return JsonConvert.DeserializeObject<List<User>>(response);
            }
        }

        // Method to get activities from API 2
        static async Task<List<Activity>> GetActivitiesFromApi()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
                // Simulating activities using a post's userId field as user activity for this example.
                return JsonConvert.DeserializeObject<List<Activity>>(response)
                    .Select(a => new Activity { UserId = a.UserId, ActivityDescription = "Some activity" })
                    .ToList();
            }
        }
    }
}
