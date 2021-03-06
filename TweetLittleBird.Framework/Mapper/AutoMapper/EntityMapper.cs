using System;
using System.Linq;
using AutoMapper;

namespace TweetLittleBird.Framework.Mapper.AutoMapper
{
    public class EntityMapper : IEntityMapper
    {
        private readonly IMappingEngine _mappingEngine;

        public EntityMapper(IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
        }

        public T Map<T>(params object[] sources) where T : class
        {
            if (!sources.Any())
            {
                return default(T);
            }

            var initialSource = sources[0];
            var mappingResult = Map<T>(initialSource);

            // Now map the remaining source objects
            if (sources.Count() > 1)
            {
                Map(mappingResult, sources.Skip(1).ToArray());
            }

            return mappingResult;
        }

        public void Map(object destination, params object[] sources)
        {
            if (!sources.Any())
            {
                return;
            }

            var destinationType = destination.GetType();

            foreach (var source in sources)
            {
                var sourceType = source.GetType();

                _mappingEngine.Map(source, destination, sourceType, destinationType);
            }
        }

        private T Map<T>(object source) where T : class
        {
            var destinationType = typeof (T);
            var sourceType = source.GetType();
            var mappingResult = _mappingEngine.Map(source, sourceType, destinationType);
            return mappingResult as T;
        }

        
        ~EntityMapper()
        {
            Dispose(false);
        }
        
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
            if (disposing)
            {
                if (_mappingEngine != null) _mappingEngine.Dispose();
            }
            // Handle unmanaged resource
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}