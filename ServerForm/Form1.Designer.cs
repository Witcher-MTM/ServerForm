
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
            this.SeeClientsBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DesktopFiles = new System.Windows.Forms.Button();
            this.JsonInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SeeClientsBtn
            // 
            this.SeeClientsBtn.Location = new System.Drawing.Point(12, 12);
            this.SeeClientsBtn.Name = "SeeClientsBtn";
            this.SeeClientsBtn.Size = new System.Drawing.Size(148, 23);
            this.SeeClientsBtn.TabIndex = 0;
            this.SeeClientsBtn.Text = "Show all clients";
            this.SeeClientsBtn.UseVisualStyleBackColor = true;
            this.SeeClientsBtn.Click += new System.EventHandler(this.seeClients_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(13, 13);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(147, 23);
            this.BackBtn.TabIndex = 3;
            this.BackBtn.Text = "Back<";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 396);
            this.textBox1.TabIndex = 4;
            this.textBox1.Visible = false;
            // 
            // DesktopFiles
            // 
            this.DesktopFiles.Location = new System.Drawing.Point(166, 13);
            this.DesktopFiles.Name = "DesktopFiles";
            this.DesktopFiles.Size = new System.Drawing.Size(119, 23);
            this.DesktopFiles.TabIndex = 5;
            this.DesktopFiles.Text = "DesktopFiles";
            this.DesktopFiles.UseVisualStyleBackColor = true;
            this.DesktopFiles.Visible = false;
            this.DesktopFiles.Click += new System.EventHandler(this.DesktopFiles_Click);
            // 
            // JsonInfo
            // 
            this.JsonInfo.Location = new System.Drawing.Point(291, 13);
            this.JsonInfo.Name = "JsonInfo";
            this.JsonInfo.Size = new System.Drawing.Size(119, 23);
            this.JsonInfo.TabIndex = 6;
            this.JsonInfo.Text = "JsonInfo";
            this.JsonInfo.UseVisualStyleBackColor = true;
            this.JsonInfo.Visible = false;
            this.JsonInfo.Click += new System.EventHandler(this.JsonInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.JsonInfo);
            this.Controls.Add(this.DesktopFiles);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.SeeClientsBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SeeClientsBtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button DesktopFiles;
        private System.Windows.Forms.Button JsonInfo;
    }
}

