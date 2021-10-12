
namespace ServerForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.client_apps = new System.Windows.Forms.ListBox();
            this.StartProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Check All Files ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // client_apps
            // 
            this.client_apps.FormattingEnabled = true;
            this.client_apps.Location = new System.Drawing.Point(507, 2);
            this.client_apps.Name = "client_apps";
            this.client_apps.Size = new System.Drawing.Size(281, 446);
            this.client_apps.TabIndex = 1;
            this.client_apps.SelectedIndexChanged += new System.EventHandler(this.client_apps_SelectedIndexChanged);
            // 
            // StartProcess
            // 
            this.StartProcess.Location = new System.Drawing.Point(516, 415);
            this.StartProcess.Name = "StartProcess";
            this.StartProcess.Size = new System.Drawing.Size(261, 23);
            this.StartProcess.TabIndex = 2;
            this.StartProcess.Text = "Start selection process";
            this.StartProcess.UseVisualStyleBackColor = true;
            this.StartProcess.Visible = false;
            this.StartProcess.Click += new System.EventHandler(this.StartProcess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartProcess);
            this.Controls.Add(this.client_apps);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox client_apps;
        private System.Windows.Forms.Button StartProcess;
    }
}

