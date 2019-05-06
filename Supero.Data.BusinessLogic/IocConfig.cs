
namespace Supero.Data.BusinessLogic
{

    using Supero.DataBase.Persister.Implementor;
    using Supero.DataBase.Persister.Interface;
    
    using SimpleInjector;

    /// <summary>
    /// The busines logic IoC registration class.
    /// </summary>
    public class ServiceConfiguration
    {
        /// <summary>
        /// Register dependencies from persister layer.
        /// </summary>
        /// <param name="container">The IoC container object.</param>
        public static void Register(Container container)
        {
    
            // Readers
            container.Register<ITaskListRepository, TaskListRepository>();

        }
    }
}
