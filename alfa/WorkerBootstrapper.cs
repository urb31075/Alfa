// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkerBootstrapper.cs" company="URBLab">
//   All Right Reserved  
// </copyright>
// <summary>
//   The worker bootstrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DupelOperation
{
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;

    /// <inheritdoc />
    /// <summary>
    /// The worker bootstrapper.
    /// </summary>
    public class WorkerBootstrapper : DefaultNancyBootstrapper
    {
        /// <inheritdoc />
        /// <summary>
        /// The application startup.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="pipelines">
        /// The pipelines.
        /// </param>
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            container.Register<IAbstractOperation, OperationFacke>();
        }
    }
}