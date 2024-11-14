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
            notifyIcon1.Visible = false; // Иконка уведомления изначально скрыта
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string taskTitle = txtTaskTitle.Text;
            DateTime reminderTime = dtpReminderTime.Value;

            if (string.IsNullOrWhiteSpace(taskTitle))
            {
                MessageBox.Show("Пожалуйста, введите название задачи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TaskItem newTask = new TaskItem
            {
                Title = taskTitle,
                ReminderTime = reminderTime
            };

            tasks.Add(newTask);
            // Обновляем список задач с отображением времени выполнения
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
                // Создаём новый таймер
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
                {
                    Interval = (int)timeUntilReminder.TotalMilliseconds
                };

                // Отладочное сообщение
                Console.WriteLine($"Установлено напоминание для задачи \"{task.Title}\" на {task.ReminderTime}");

                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    ShowNotification(task);
                };
                timer.Start();
            }
            else
            {
                MessageBox.Show("Время напоминания должно быть в будущем.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowNotification(TaskItem task)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Напоминание";
            notifyIcon1.BalloonTipText = $"Время выполнить задачу: {task.Title}";
            notifyIcon1.ShowBalloonTip(3000);
            Console.WriteLine($"Показано уведомление: \"{task.Title}\""); // Отладочное сообщение
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal; // Восстанавливаем форму
            }
        }

        // Класс для хранения информации о задаче
        private class TaskItem
        {
            public string Title { get; set; }
            public DateTime ReminderTime { get; set; }
        }
    }
}
