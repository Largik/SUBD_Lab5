using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.Interfaces;
using JournalBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JournalBusinessLogic.BusinessLogic
{
    public class GroupLogic
    {
        private readonly IGroupStorage groupStorage;
        public GroupLogic(IGroupStorage groupStorage)
        {
            this.groupStorage = groupStorage;
        }
        public List<GroupViewModel> Read(GroupBindingModel model)
        {
            if (model == null)
            {
                return groupStorage.GetFullList();
            }
            return new List<GroupViewModel> { groupStorage.GetElement(model) };
        }
        public void CreateOrUpdate(GroupBindingModel model)
        {
            var element = groupStorage.GetElement(new GroupBindingModel
            {
                NameGroup = model.NameGroup
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже присутствует такая группа");
            }
            if (model.Id.HasValue)
            {
                groupStorage.Update(model);
            }
            else
            {
                groupStorage.Insert(model);
            }
        }
        public void Delete(GroupBindingModel model)
        {
            var element = groupStorage.GetElement(new GroupBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Группа не найден");
            }
            groupStorage.Delete(model);
        }
    }
}
