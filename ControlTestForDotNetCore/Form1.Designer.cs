namespace ControlTestForDotNetCore
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
            nullableDateTimePicker1 = new NullableDateTimePicker.NullableDateTimePicker();
            nullableDateTimePicker2 = new NullableDateTimePicker.NullableDateTimePicker();
            nullableDateTimePicker3 = new NullableDateTimePicker.NullableDateTimePicker();
            SuspendLayout();
            // 
            // nullableDateTimePicker1
            // 
            nullableDateTimePicker1.Location = new Point(194, 36);
            nullableDateTimePicker1.Name = "nullableDateTimePicker1";
            nullableDateTimePicker1.Size = new Size(250, 27);
            nullableDateTimePicker1.TabIndex = 0;
            nullableDateTimePicker1.Value = null;
            // 
            // nullableDateTimePicker2
            // 
            nullableDateTimePicker2.Location = new Point(195, 96);
            nullableDateTimePicker2.Name = "nullableDateTimePicker2";
            nullableDateTimePicker2.Size = new Size(158, 27);
            nullableDateTimePicker2.TabIndex = 1;
            nullableDateTimePicker2.CustomFormat = "yy/MM/dd";
            nullableDateTimePicker2.Format = DateTimePickerFormat.Custom;
            nullableDateTimePicker2.Value = new DateTime(2023, 10, 7, 19, 7, 44, 917);
            // 
            // nullableDateTimePicker3
            // 
            nullableDateTimePicker3.Location = new Point(194, 188);
            nullableDateTimePicker3.Name = "nullableDateTimePicker3";
            nullableDateTimePicker3.Size = new Size(122, 27);
            nullableDateTimePicker3.TabIndex = 2;
            nullableDateTimePicker3.Value = new DateTime(2023, 10, 7, 19, 9, 12, 869);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nullableDateTimePicker3);
            Controls.Add(nullableDateTimePicker2);
            Controls.Add(nullableDateTimePicker1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private NullableDateTimePicker.NullableDateTimePicker nullableDateTimePicker1;
        private NullableDateTimePicker.NullableDateTimePicker nullableDateTimePicker2;
        private NullableDateTimePicker.NullableDateTimePicker nullableDateTimePicker3;
    }
}