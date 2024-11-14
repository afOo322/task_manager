using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace task_manager
{
    public partial class Form1 : Form
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Visible = false; // ������ ����������� ���������� ������
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string taskTitle = txtTaskTitle.Text;
            DateTime reminderTime = dtpReminderTime.Value;

            if (string.IsNullOrWhiteSpace(taskTitle))
            {
                MessageBox.Show("����������, ������� �������� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TaskItem newTask = new TaskItem
            {
                Title = taskTitle,
                ReminderTime = reminderTime
            };

            tasks.Add(newTask);
            // ��������� ������ ����� � ������������ ������� ����������
            lstTasks.Items.Add($"{newTask.Title} - {newTask.ReminderTime.ToString("g")}");
            txtTaskTitle.Clear();
            dtpReminderTime.Value = DateTime.Now;

            SetReminder(newTask);
        }

        private void SetReminder(TaskItem task)
        {
            TimeSpan timeUntilReminder = task.ReminderTime - DateTime.Now;

            if (timeUntilReminder.TotalMilliseconds > 0)
            {
                // ������ ����� ������
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
                {
                    Interval = (int)timeUntilReminder.TotalMilliseconds
                };

                // ���������� ���������
                Console.WriteLine($"����������� ����������� ��� ������ \"{task.Title}\" �� {task.ReminderTime}");

                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    ShowNotification(task);
                };
                timer.Start();
            }
            else
            {
                MessageBox.Show("����� ����������� ������ ���� � �������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowNotification(TaskItem task)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "�����������";
            notifyIcon1.BalloonTipText = $"����� ��������� ������: {task.Title}";
            notifyIcon1.ShowBalloonTip(3000);
            Console.WriteLine($"�������� �����������: \"{task.Title}\""); // ���������� ���������
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal; // ��������������� �����
            }
        }

        // ����� ��� �������� ���������� � ������
        private class TaskItem
        {
            public string Title { get; set; }
            public DateTime ReminderTime { get; set; }
        }
    }
}
