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
    public partial class FormDiscipline : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { _id = value; } }
        private int? _id;

        private readonly UserLogic userLogic;
        private readonly DisciplineLogic disciplineLogic;
        public FormDiscipline(UserLogic userLogic, DisciplineLogic disciplineLogic)
        {
            InitializeComponent();
            this.userLogic = userLogic;
            this.disciplineLogic = disciplineLogic;
        }
        private void FormUser_Load(object sender, EventArgs e)
        {
            List<UserViewModel> userList = userLogic.Read(null);
            if (userList != null)
            {
                comboBoxTeacher.DisplayMember = "UserName";
                comboBoxTeacher.ValueMember = "Id";
                comboBoxTeacher.DataSource = userList.Where(rec => rec.NameRole == "Преподаватель").ToList();
                comboBoxTeacher.SelectedItem = null;
            }

            if (_id.HasValue)
            {
                try
                {
                    var view = disciplineLogic.Read(new DisciplineBindingModel { Id = _id })?[0];
                    int selectedUserIndex = Array.IndexOf(userList.ToArray(), userList
                        .FirstOrDefault(rec => rec.Id == view.UserId));

                    if (view != null)
                    {
                        textBoxName.Text = view.NameDiscipline;
                        comboBoxTeacher.SelectedItem = comboBoxTeacher.Items[selectedUserIndex];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(comboBoxTeacher.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                disciplineLogic.CreateOrUpdate(new DisciplineBindingModel
                {
                    Id = _id,
                    NameDiscipline = textBoxName.Text,
                    UserId = Convert.ToInt32(comboBoxTeacher.SelectedValue),
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
