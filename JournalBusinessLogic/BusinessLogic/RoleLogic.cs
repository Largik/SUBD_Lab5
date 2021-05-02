using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.Interfaces;
using JournalBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace JournalBusinessLogic.BusinessLogic
{
    public class RoleLogic
    {
        private readonly IRoleStorage roleStorage;
        public RoleLogic(IRoleStorage roleStorage)
        {
            this.roleStorage = roleStorage;
        }
        public List<RoleViewModel> Read(RoleBindingModel model)
        {
            if (model == null)
            {
                return roleStorage.GetFullList();
            }
            return new List<RoleViewModel> { roleStorage.GetElement(model) };
        }
        public void CreateOrUpdate(RoleBindingModel model)
        {
            var element = roleStorage.GetElement(new RoleBindingModel
            {
                NameRole = model.NameRole
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже присутствует такая должность");
            }
            if (model.Id.HasValue)
            {
                roleStorage.Update(model);
            }
            else
            {
                roleStorage.Insert(model);
            }
        }
        public void Delete(RoleBindingModel model)
        {
            var element = roleStorage.GetElement(new RoleBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Должность не найден");
            }
            roleStorage.Delete(model);
        }
    }
}
