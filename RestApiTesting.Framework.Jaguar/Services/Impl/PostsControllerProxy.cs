using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using RestApiTesting.Framework.Jaguar.Models;

namespace RestApiTesting.Framework.Jaguar.Services.Impl
{
    public class PostsControllerProxy
    {
        private const string PostsPath = "posts";

        private readonly string m_baseUrl;

        private FlurlClient m_client;

        public PostsControllerProxy(string baseUrl)
        {
            m_baseUrl = baseUrl;
        }

        public async Task<HttpResponseMessage> CreatePostsAsync(PostModel postPrincipal)
        {
            return await StringExtensions.AppendPathSegments(m_baseUrl, PostsPath)
                    .AllowAnyHttpStatus()
                    .PostJsonAsync(postPrincipal);
        }

        public async Task<HttpResponseMessage> UpdatePostsAsync(string postId, PostModel postPrincipal)
        {
            return await StringExtensions.AppendPathSegments(m_baseUrl, PostsPath, postId)
                    .AllowAnyHttpStatus()
                    .PutJsonAsync(postPrincipal);
        }

        public async Task<HttpResponseMessage> GetPostsAsync(string postId)
        {
            return await StringExtensions.AppendPathSegments(m_baseUrl, PostsPath, postId)
                    .AllowAnyHttpStatus()
                    .GetAsync();
        }

        public async Task<HttpResponseMessage> DeletePostsAsync(string postId)
        {
            m_client = GetFlurlClient();

            return await StringExtensions.AppendPathSegments(m_baseUrl, PostsPath, postId)
                .WithClient(m_client)
                .DeleteAsync();
        }

        public async Task<HttpResponseMessage> PatchPostsAsync(string postId, PatchPostModel patchPostModel)
        {
            return await StringExtensions.AppendPathSegments(m_baseUrl, PostsPath, postId)
                    .AllowAnyHttpStatus()
                    .SendJsonAsync(HttpMethod.Patch, patchPostModel);
        }


        public FlurlClient GetFlurlClient() => new FlurlClient(m_baseUrl);
    }
}