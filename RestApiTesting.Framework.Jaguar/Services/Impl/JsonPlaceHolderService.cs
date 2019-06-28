using RestApiTesting.Framework.Jaguar.Helpers;

namespace RestApiTesting.Framework.Jaguar.Services.Impl
{
    public class JsonPlaceHolderService: IJsonPlaceHolderService
    {
        public PostsControllerProxy PostsControllerProxy { get; set; }

        public JsonPlaceHolderService()
        {
            PostsControllerProxy = new PostsControllerProxy(ConfigurationHelper.TestApiUrl);
        }
    }
}
