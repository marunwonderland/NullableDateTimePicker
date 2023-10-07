namespace ControlTestForDotNetCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            nullableDateTimePicker1.Format = DateTimePickerFormat.Custom;
            nullableDateTimePicker1.CustomFormat = "yyyy/MM/dd";

        }
    }
}