using Microsoft.Extensions.DependencyInjection;

namespace Benchmark.Services
{
    /// <summary>
    /// Scoped resource. Analogous to Autofac.Owned.
    /// </summary>
    /// <remarks>
    /// Sealed only to suppress annoying Dispose compilation warnings, and we do
    /// not anticipate sub-classing this type. If sub-typing is required then
    /// unseal and manage any warnings etc.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public sealed class Scoped<T> : IDisposable
    {
        private IServiceScope _scope = null;

        /// <summary>
        /// A scoped resource of <typeparamref name="T"/>.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Default constructor when <typeparamref name="T"/> is unambiguous.
        /// </summary>
        /// <param name="scope"></param>
        public Scoped(IServiceScope scope)
            : this(scope, scope.ServiceProvider.GetRequiredService<T>())
        {
        }

        /// <summary>
        /// Constructor when <paramref name="value"/> is sub-class of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="value"></param>
        public Scoped(IServiceScope scope, T value)
        {
            _scope = scope;
            Value = value;
        }

        /// <summary>
        /// Disposes of scoped container and scoped resources.
        /// </summary>
        public void Dispose()
        {
            if (_scope != null)
            {
                Value = default(T);

                _scope.Dispose();
                _scope = null;
            }
        }
    }

}