using JournalBusinessLogic.BusinessLogic;
using JournalBusinessLogic.Interfaces;
using JournalDB.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace JournalView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IDisciplineStorage, DisciplineStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IUserStorage, UserStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRoleStorage, RoleStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGroupStorage, GroupStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMarksStorage, MarksStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<DisciplineLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<UserLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<RoleLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<GroupLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MarksLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
