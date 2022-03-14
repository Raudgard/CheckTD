
namespace CheckTD
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dropLabel = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.pictureResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dropLabel
            // 
            this.dropLabel.AllowDrop = true;
            this.dropLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dropLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dropLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dropLabel.Location = new System.Drawing.Point(118, 12);
            this.dropLabel.MinimumSize = new System.Drawing.Size(100, 100);
            this.dropLabel.Name = "dropLabel";
            this.dropLabel.Size = new System.Drawing.Size(670, 100);
            this.dropLabel.TabIndex = 0;
            this.dropLabel.Text = "Перенесите xml-файл сюда для проверки";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AllowDrop = true;
            this.ResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ResultLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResultLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ResultLabel.Location = new System.Drawing.Point(12, 130);
            this.ResultLabel.MinimumSize = new System.Drawing.Size(100, 100);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(776, 277);
            this.ResultLabel.TabIndex = 1;
            // 
            // pictureResult
            // 
            this.pictureResult.Location = new System.Drawing.Point(12, 12);
            this.pictureResult.Name = "pictureResult";
            this.pictureResult.Size = new System.Drawing.Size(100, 100);
            this.pictureResult.TabIndex = 2;
            this.pictureResult.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 416);
            this.Controls.Add(this.pictureResult);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.dropLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CheckTD";
            ((System.ComponentModel.ISupportInitialize)(this.pictureResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label dropLabel;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.PictureBox pictureResult;
    }
}

