using System;

namespace TweetLittleBird.Framework.Mapper
{
    public interface IEntityMapper : IDisposable
    {
        T Map<T>(params object[] sources) where T : class;
        void Map(object destination, params object[] sources);
    }
}