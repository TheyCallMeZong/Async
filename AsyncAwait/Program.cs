using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main()
        {
            GetPosts posts = new GetPosts();
            
            await posts.GetPostsAsync();
        }
    }
}
