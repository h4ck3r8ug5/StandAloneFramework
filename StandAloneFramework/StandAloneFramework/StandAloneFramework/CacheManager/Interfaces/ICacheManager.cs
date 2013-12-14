namespace StandAloneFramework
{
    public interface ICacheManager<T>
    {
        void AddObjectToCache(T instance);

        T GetObjectFromCache(int hashCode);

        void FlushCache();
    }
}
