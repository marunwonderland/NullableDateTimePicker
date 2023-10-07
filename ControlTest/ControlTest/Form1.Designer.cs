namespace ControlTest
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.nullableDateTimePicker1 = new NullableDateTimePicker.NullableDateTimePicker();
            this.nullableDateTimePicker2 = new NullableDateTimePicker.NullableDateTimePicker();
            this.nullableDateTimePicker3 = new NullableDateTimePicker.NullableDateTimePicker();
            this.SuspendLayout();
            // 
            // nullableDateTimePicker1
            // 
            this.nullableDateTimePicker1.Location = new System.Drawing.Point(167, 34);
            this.nullableDateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePicker1.Name = "nullableDateTimePicker1";
            this.nullableDateTimePicker1.Size = new System.Drawing.Size(195, 27);
            this.nullableDateTimePicker1.TabIndex = 0;
            this.nullableDateTimePicker1.Value = new System.DateTime(2023, 10, 7, 18, 12, 11, 451);
            // 
            // nullableDateTimePicker2
            // 
            this.nullableDateTimePicker2.CustomFormat = "yyyy/MM/dd";
            this.nullableDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nullableDateTimePicker2.Location = new System.Drawing.Point(167, 130);
            this.nullableDateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePicker2.Name = "nullableDateTimePicker2";
            this.nullableDateTimePicker2.Size = new System.Drawing.Size(167, 27);
            this.nullableDateTimePicker2.TabIndex = 1;
            this.nullableDateTimePicker2.Value = new System.DateTime(2023, 10, 7, 18, 13, 13, 1);
            // 
            // nullableDateTimePicker3
            // 
            this.nullableDateTimePicker3.CustomFormat = "yy/MM/dd";
            this.nullableDateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nullableDateTimePicker3.Location = new System.Drawing.Point(167, 211);
            this.nullableDateTimePicker3.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePicker3.Name = "nullableDateTimePicker3";
            this.nullableDateTimePicker3.Size = new System.Drawing.Size(135, 27);
            this.nullableDateTimePicker3.TabIndex = 2;
            this.nullableDateTimePicker3.Value = new System.DateTime(2023, 10, 7, 18, 13, 13, 1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 422);
            this.Controls.Add(this.nullableDateTimePicker3);
            this.Controls.Add(this.nullableDateTimePicker2);
            this.Controls.Add(this.nullableDateTimePicker1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private NullableDateTimePicker.NullableDateTimePicker nullableDateTimePicker1;
        private NullableDateTimePicker.NullableDateTimePicker nullableDateTimePicker2;
        private NullableDateTimePicker.NullableDateTimePicker nullableDateTimePicker3;
    }
}

