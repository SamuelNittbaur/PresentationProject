using System.Net;
using Firebase.Database;
using System.Net.Http;
using Newtonsoft.Json;

namespace ServerLogic
{
    public static class DataHandler
    {

        public static async Task<HttpStatusCode> InsertData(User user)
        {
            try
            {
                var firebase = new FirebaseClient(Root.firestoreDatabaseBucket);
                var datas = await firebase
                    .Child("Users")
                    .PostAsync(JsonConvert.SerializeObject(user));
                return HttpStatusCode.OK;
            }
            catch(Exception exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        } 
        public static async Task<Response> FetchData(string email)
        {
            try
            {
                List<User> users = new List<User>();
                User responseUser = new User();
                var firebase = new FirebaseClient(Root.firestoreDatabaseBucket);
                var datas = await firebase
                    .Child("Users")
                    .OnceAsync<object>();

                foreach (var data in datas)
                {
                    try
                    {
                        users.Add(JsonConvert.DeserializeObject<User>(data.Object.ToString())); 
                    }
                    catch(Exception iterationException)
                    {
                        //Exception handling
                    }
                }
                responseUser = users.Single(user => user.email == email);


                return new Response()
                {
                    statusCode = HttpStatusCode.OK,
                    content = responseUser
                };
            }
            catch(Exception exception)
            {
                return new Response()
                {
                    statusCode = HttpStatusCode.InternalServerError,
                    content = exception
                };
            }


        }
    }
}
