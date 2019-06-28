using RestApiTesting.Framework.Jaguar.Models;

namespace RestApiTesting.Framework.Jaguar.Helpers
{
    public class ModelGeneratorHelper
    {
        public static PostModel GeneratePost()
        {
            return new PostModel
            {
                userId = 1,
                id = 101,
                title = "title1",
                body = "body1"
            };
        }

        public static PostModel UpdatePost()
        {
            return new PostModel
            {
                userId = 1,
                id = 1,
                title = "updated title",
                body = "updated body"
            };
        }

        public static PostModel GetPost()
        {
            return new PostModel
            {
                userId = 1,
                id = 1,
                title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            };
        }

        public static PostModel GetEmptyPost()
        {
            return new PostModel
            {
                userId = 0,
                id = 0,
                title = null,
                body = null
            };
        }

        public static PatchPostModel PatchPost()
        {
            return new PatchPostModel
            {
                title = "patched title"
            };
        }

        public static PostModel PatchedPost()
        {
            return new PostModel
            {
                userId = 1,
                id = 1,
                title = "patched title",
                body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            };
        }

        public static PostModel PatchedNonExistentPost()
        {
            return new PostModel
            {
                userId = 0,
                id = 0,
                title = "patched title",
                body = null
            };
        }

    }
}
