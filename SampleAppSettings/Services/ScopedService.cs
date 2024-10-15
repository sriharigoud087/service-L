namespace SampleAppSettings.Services
{
    public class ScopedService : IScopedService
    {
        private string guid;
        public ScopedService()
        {
            guid = Guid.NewGuid().ToString();
        }
        public string GetGuid()
        {
            return guid;
        }
    }
}
