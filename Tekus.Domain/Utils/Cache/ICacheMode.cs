namespace Tekus.Domain.Utils.Cache
{
    public interface ICacheMode
    {
        /// <summary>
        /// Change storage mode to cache mode
        /// </summary>
        void TurnOnCache();

        /// <summary>
        /// Change storage mode to database mode
        /// </summary>
        void TurnOffCache();
    }
}
