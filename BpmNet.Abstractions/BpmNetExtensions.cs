using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Exposes extensions allowing to register the BpmNet services.
    /// </summary>
    public static class BpmNetExtensions
    {
        /// <summary>
        /// Provides a common entry point for registering the BpmNet services.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <remarks>This extension can be safely called multiple times.</remarks>
        /// <returns>The <see cref="BpmNetBuilder"/>.</returns>
        public static BpmNetBuilder AddBpmNet(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return new BpmNetBuilder(services);
        }
    }
}
