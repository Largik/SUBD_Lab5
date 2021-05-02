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
    public partial class FormMark : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { _id = value; } }
        private int? _id;

        private readonly UserLogic userLogic;
        private readonly DisciplineLogic disciplineLogic;
        private readonly MarksLogic markLogic;
        public FormMark(UserLogic userLogic, DisciplineLogic disciplineLogic, MarksLogic markLogic)
        {
            InitializeComponent();
            this.userLogic = userLogic;
            this.disciplineLogic = disciplineLogic;
            this.markLogic = markLogic;
        }
        private void FormUser_Load(object sender, EventArgs e)
        {
            List<DisciplineViewModel> disciplineList = disciplineLogic.Read(null);
            if (disciplineList != null)
            {
                comboBoxDiscipline.DisplayMember = "NameDiscipline";
                comboBoxDiscipline.ValueMember = "Id";
                comboBoxDiscipline.DataSource = disciplineList;
                comboBoxDiscipline.SelectedItem = null;
            }

            List<UserViewModel> userList = userLogic.Read(null);
            if (userList != null)
            {
                cbTeacher.DisplayMember = "UserName";
                cbTeacher.ValueMember = "Id";
                cbTeacher.DataSource = userList.Where(rec => rec.NameRole == "Студент").ToList(); ;
                cbTeacher.SelectedItem = null;
            }

            if (_id.HasValue)
            {
                try
                {
                    var view = markLogic.Read(new MarksBindingModel { Id = _id })?[0];
                    int selectedDisciplineIndex = Array.IndexOf(disciplineList.ToArray(), disciplineList.FirstOrDefault(rec => rec.Id == view.DisciplineId));
                    int selectedUserIndex = Array.IndexOf(userList.ToArray(), userList.FirstOrDefault(rec => rec.Id == view.UserId));

                    if (view != null)
                    {
                        maskedTextBoxMark.Text = Convert.ToString(view.Mark);
                        comboBoxDiscipline.SelectedItem = comboBoxDiscipline.Items[selectedDisciplineIndex];
                        cbTeacher.SelectedItem = cbTeacher.Items[selectedUserIndex];
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
            if (string.IsNullOrEmpty(maskedTextBoxMark.Text) || string.IsNullOrEmpty(comboBoxDiscipline.Text) || string.IsNullOrEmpty(cbTeacher.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                markLogic.CreateOrUpdate(new AddMarkBindingModel
                { 
                    Mark = Convert.ToDecimal(maskedTextBoxMark.Text),
                    DisciplineId = Convert.ToInt32(comboBoxDiscipline.SelectedValue),
                    UserId = Convert.ToInt32(cbTeacher.SelectedValue),
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
