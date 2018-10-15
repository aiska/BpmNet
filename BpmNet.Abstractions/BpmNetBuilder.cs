using System;
using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides a shared entry point allowing to configure the BpmNet services.
    /// </summary>
    public class BpmNetBuilder
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BpmNetBuilder"/>.
        /// </summary>
        /// <param name="services">The services collection.</param>
        public BpmNetBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Gets the services collection.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IServiceCollection Services { get; }
    }
}
