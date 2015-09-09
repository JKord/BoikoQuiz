using Ninject.Modules;
using BoikoQuiz.Core.Repository;

namespace BoikoQuiz.Core
{
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<RUser>().To<RUser>();
            Bind<RQuestion>().To<RQuestion>();
        }
    }
}