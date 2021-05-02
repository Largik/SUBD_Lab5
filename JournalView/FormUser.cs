using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.BusinessLogic;
using JournalBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace JournalView
{
    public partial class FormUser : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        
        public int Id { set { _id = value; } }
        private int? _id;
        
        private readonly UserLogic userLogic;
        private readonly RoleLogic roleLogic;
        private readonly GroupLogic groupLogic;
        public FormUser(UserLogic userLogic, RoleLogic roleLogic,
            GroupLogic groupLogic)
        {
            InitializeComponent();
            this.userLogic = userLogic;
            this.roleLogic = roleLogic;
            this.groupLogic = groupLogic;
        }
        private void FormUser_Load(object sender, EventArgs e)
        {
            List<RoleViewModel> roleList = roleLogic.Read(null);
            if (roleList != null)
            {
                comboBoxRole.DisplayMember = "NameRole";
                comboBoxRole.ValueMember = "Id";
                comboBoxRole.DataSource = roleList;
                comboBoxRole.SelectedItem = null;
            }

            List<GroupViewModel> groupList = groupLogic.Read(null);
            if (groupList != null)
            {
                cbGroup.DisplayMember = "NameGroup";
                cbGroup.ValueMember = "Id";
                cbGroup.DataSource = groupList;
                cbGroup.SelectedItem = null;
            }

            if (_id.HasValue)
            {
                try
                {
                    var view = userLogic.Read(new UserBindingModel { Id = _id })?[0];
                    int selectedRoleIndex = Array.IndexOf(roleList.ToArray(), roleList.FirstOrDefault(rec => rec.Id == view.RoleId));
                    int selectedGroupIndex = Array.IndexOf(groupList.ToArray(), groupList.FirstOrDefault(rec => rec.Id == view.GroupId));

                    if (view != null)
                    {
                        tbName.Text = view.UserName;
                        tbLogin.Text = view.Login;
                        tbPassword.Text = view.Password;
                        comboBoxRole.SelectedItem = comboBoxRole.Items[selectedRoleIndex];
                        cbGroup.SelectedItem = cbGroup.Items[selectedGroupIndex];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(tbPassword.Text) ||
                 string.IsNullOrEmpty(comboBoxRole.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cbGroup.Text) && comboBoxRole.Text == "Студент")
            {
                MessageBox.Show("Укажите группу студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int? groupId;
                if (string.IsNullOrEmpty(cbGroup.Text) || comboBoxRole.Text == "Преподаватель")
                {
                    groupId = null;
                }
                else
                {
                    groupId = Convert.ToInt32(cbGroup.SelectedValue);
                }  
                userLogic.CreateOrUpdate(new UserBindingModel
                {
                    Id = _id,
                    UserName = tbName.Text,
                    Login = tbLogin.Text,
                    Password = tbPassword.Text,
                    RoleId = Convert.ToInt32(comboBoxRole.SelectedValue),
                    GroupId = groupId
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
