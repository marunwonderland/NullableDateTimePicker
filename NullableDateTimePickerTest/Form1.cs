using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NullableDateTimePickerTest
{
    public partial class Form1 : Form
    {
        NullableDateTimePicker.NullableDateTimePicker nullableDateTimePicker1;
        public Form1()
        {
            InitializeComponent();
            nullableDateTimePicker1 = new NullableDateTimePicker.NullableDateTimePicker();
            this.Controls.Add(nullableDateTimePicker1);
        }
    }
}
