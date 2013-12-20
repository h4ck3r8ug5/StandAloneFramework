namespace StandAloneFramework.Interfaces
{
    public interface ICacheManager<T>
    {
        T AddObjectToCache(T instance);

        T GetObjectFromCache(int hashCode);

        void FlushCache();
    }
}
