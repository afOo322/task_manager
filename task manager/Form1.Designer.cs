namespace task_manager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.dtpReminderTime = new System.Windows.Forms.DateTimePicker();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.Location = new System.Drawing.Point(12, 12);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(260, 20);
            this.txtTaskTitle.TabIndex = 0;
            this.txtTaskTitle.PlaceholderText = "Введите название задачи";
            // 
            // dtpReminderTime
            // 
            this.dtpReminderTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpReminderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReminderTime.Location = new System.Drawing.Point(12, 38);
            this.dtpReminderTime.Name = "dtpReminderTime";
            this.dtpReminderTime.Size = new System.Drawing.Size(260, 20);
            this.dtpReminderTime.TabIndex = 1;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(12, 64);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(260, 23);
            this.btnAddTask.TabIndex = 2;
            this.btnAddTask.Text = "Добавить задачу";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(12, 93);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(260, 147);
            this.lstTasks.TabIndex = 3;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.dtpReminderTime);
            this.Controls.Add(this.txtTaskTitle);
            this.Name = "Form1";
            this.Text = "Менеджер задач";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtTaskTitle;
        private System.Windows.Forms.DateTimePicker dtpReminderTime;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}
