
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
            this.SuspendLayout();
            // 
            // SeeClients
            // 
            this.SeeClientsBtn.Location = new System.Drawing.Point(12, 12);
            this.SeeClientsBtn.Name = "SeeClients";
            this.SeeClientsBtn.Size = new System.Drawing.Size(148, 23);
            this.SeeClientsBtn.TabIndex = 0;
            this.SeeClientsBtn.Text = "Show all clients";
            this.SeeClientsBtn.UseVisualStyleBackColor = true;
            this.SeeClientsBtn.Click += new System.EventHandler(this.seeClients_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(13, 12);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(147, 23);
            this.BackBtn.TabIndex = 3;
            this.BackBtn.Text = "Back<";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.SeeClientsBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SeeClientsBtn;
        private System.Windows.Forms.Button BackBtn;
    }
}

