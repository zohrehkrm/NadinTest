

namespace NadinTest.Configuration.DataInitializer
{
    public interface IDataInitializer 
    {
        int order { get; set; }
        void InitializeData();
    }
}
