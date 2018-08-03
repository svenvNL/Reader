using System;

namespace Reader
{
    public static class HttpClient
    {
        private static System.Net.Http.HttpClient _instance;

        public static System.Net.Http.HttpClient GetInstance()
        {
            return _instance ?? (_instance = new System.Net.Http.HttpClient());
        }
    }
}