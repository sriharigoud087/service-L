using System;

namespace SampleAppSettings.Services
{
    public class SingletonService : ISingletonService
    {
        private string guid;

        public SingletonService()
        {
            guid = Guid.NewGuid().ToString();
        }
        public string GetGuid()
        {
            return guid;
        }
    }
}
