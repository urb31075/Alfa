// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkerBootstrapper.cs" company="URBLab">
//   All Right Reserved  
// </copyright>
// <summary>
//   The worker bootstrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Alfa
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