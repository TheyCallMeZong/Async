using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class GetPosts
    {
        private string path = @"C:\Users\Tom\source\repos\AsyncAwait\AsyncAwait\test.txt";
        private static HttpClient client;

        public GetPosts()
        {
            client = new HttpClient();
        }

        public async Task GetPostsAsync()
        {
            var result = new List<Task<Post>>();
            for (int i = 3; i <= 13; i++)
                result.Add(GetPost(i));
            await Task.WhenAll(result);

            Thread.Sleep(1000);

            foreach (var e in result)
                File.AppendAllText(path, e.Result.ToString());
        }

        public async Task<Post> GetPost(int number)
        {
            var result = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{number}");

            return JsonConvert.DeserializeObject<Post>(await result.Content.ReadAsStringAsync());
        }
    }
}
