using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

// Copyright (c) 2005 Claudio Grazioli, http://www.grazioli.ch
//
// This implementation of a nullable DateTimePicker is a new implementation
// from scratch, but it is based on ideas I took from this nullable 
// DateTimePickers:
// - http://www.omnitalented.com/Blog/PermaLink,guid,9ee757fe-a3e8-46f7-ad04-ef7070934dc8.aspx 
//   from Alexander Shirshov
// - http://www.codeproject.com/cs/miscctrl/Nullable_DateTimePicker.asp 
//   from Pham Minh Tri
//
// This code is free software; you can redistribute it and/or modify it.
// However, this header must remain intact and unchanged.  Additional
// information may be appended after this header.  Publications based on
// this code must also include an appropriate reference.
// 
// This code is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE.
//
// Copyright (c) 2023 MarunWonderland.
//Add code and modify by MarunWonderland.

namespace NullableDateTimePicker
{
    /// <summary>
    /// Represents a Windows date time picker control. It enhances the .NET standard <b>DateTimePicker</b>
    /// control with a ReadOnly mode as well as with the possibility to show empty values (null values).
    /// </summary>
    [ComVisible(false)]
    [ToolboxItem(true)]
    public class NullableDateTimePicker : System.Windows.Forms.DateTimePicker
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public int Code;
        }

        #region Member variables
        private const int WM_KEYUP = 0x0101;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_REFLECT = 0x2000;
        private const int WM_NOTIFY = 0x004e;

        private bool selectionComplete = false;
        private bool numberKeyPressed = false;

        // true, when no date shall be displayed (empty DateTimePicker)
        private bool _isNull;

        // If _isNull = true, this value is shown in the DTP
        private string _nullValue;

        // The format of the DateTimePicker control
        private DateTimePickerFormat _format = DateTimePickerFormat.Long;

        // The custom format of the DateTimePicker control
        private string _customFormat;

        // The format of the DateTimePicker control as string
        private string _formatAsString;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public NullableDateTimePicker() : base()
        {
            base.Format = DateTimePickerFormat.Custom;
            NullValue = " ";
            Format = DateTimePickerFormat.Long;
        }
        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the date/time value assigned to the control.
        /// </summary>
        /// <value>The DateTime value assigned to the control
        /// </value>
        /// <remarks>
        /// <p>If the <b>Value</b> property has not been changed in code or by the user, it is set
        /// to the current date and time (<see cref="DateTime.Now"/>).</p>
        /// <p>If <b>Value</b> is <b>null</b>, the DateTimePicker shows 
        /// <see cref="NullValue"/>.</p>
        /// </remarks>
        public new Object Value
        {
            get
            {
                if (_isNull)
                    return null;
                else
                    return base.Value;
            }
            set
            {
                if (value == null || (value == DBNull.Value && DgvMode==false))
                {
                    //if (DgvMode)
                    //{
                    //    SetFormat();
                    //    base.Value = DateTime.Today;
                    //}
                    //else
                    SetToNullValue();
                    Checked = false;
                }
                else
                {
                    SetToDateTimeValue();
                    base.Value = (DateTime)value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the format of the date and time displayed in the control.
        /// </summary>
        /// <value>One of the <see cref="DateTimePickerFormat"/> values. The default is 
        /// <see cref="DateTimePickerFormat.Long"/>.</value>
        [Browsable(true)]
        [DefaultValue(DateTimePickerFormat.Long), TypeConverter(typeof(Enum))]
        public new DateTimePickerFormat Format
        {
            get { return _format; }
            set
            {
                _format = value;
                SetFormat();
                OnFormatChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the custom date/time format string.
        /// <value>A string that represents the custom date/time format. The default is a null
        /// reference (<b>Nothing</b> in Visual Basic).</value>
        /// </summary>
        public new String CustomFormat
        {
            get { return _customFormat; }
            set
            {
                _customFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the string value that is assigned to the control as null value. 
        /// </summary>
        /// <value>The string value assigned to the control as null value.</value>
        /// <remarks>
        /// If the <see cref="Value"/> is <b>null</b>, <b>NullValue</b> is
        /// shown in the <b>DateTimePicker</b> control.
        /// </remarks>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("The string used to display null values in the control")]
        [DefaultValue(" ")]
        public String NullValue
        {
            get { return _nullValue; }
            set { _nullValue = value; }
        }

        public bool DgvMode;

        #endregion

        #region Private methods/properties
        /// <summary>
        /// Stores the current format of the DateTimePicker as string. 
        /// </summary>
        private string FormatAsString
        {
            get { return _formatAsString; }
            set
            {
                _formatAsString = value;
                base.CustomFormat = value;
            }
        }

        /// <summary>
        /// Sets the format according to the current DateTimePickerFormat.
        /// </summary>
        private void SetFormat()
        {
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            DateTimeFormatInfo dtf = ci.DateTimeFormat;
            switch (_format)
            {
                case DateTimePickerFormat.Long:
                    FormatAsString = dtf.LongDatePattern;
                    break;
                case DateTimePickerFormat.Short:
                    FormatAsString = dtf.ShortDatePattern;
                    break;
                case DateTimePickerFormat.Time:
                    FormatAsString = dtf.ShortTimePattern;
                    break;
                case DateTimePickerFormat.Custom:
                    FormatAsString = this.CustomFormat;
                    break;
            }
        }

        /// <summary>
        /// Sets the <b>DateTimePicker</b> to the value of the <see cref="NullValue"/> property.
        /// </summary>
        private void SetToNullValue()
        {
            _isNull = true;
            base.CustomFormat = (_nullValue == null || _nullValue == String.Empty) ? " " : "'" + _nullValue + "'";
        }

        /// <summary>
        /// Sets the <b>DateTimePicker</b> back to a non null value.
        /// </summary>
        private void SetToDateTimeValue()
        {
            if (_isNull || DgvMode)
            {
                SetFormat();
                _isNull = false;
                base.OnValueChanged(new EventArgs());
            }
        }
        #endregion

        #region OnXXXX()

        /// <summary>
        /// This member overrides <see cref="DateTimePicker.OnCloseUp"/>.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCloseUp(EventArgs e)
        {
            Opened = false;
            if (Control.MouseButtons == MouseButtons.None)
            {
                if (_isNull)
                {
                    SetToDateTimeValue();
                    _isNull = false;
                }
            }
            base.OnCloseUp(e);
            Checked = Value != null;
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnKeyDown"/>.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.Value = null;
                OnValueChanged(EventArgs.Empty);
            }
            base.OnKeyUp(e);
            if ((e.KeyCode == Keys.Enter && Opened == false) ||
               (numberKeyPressed && selectionComplete &&
               (e.Modifiers == Keys.None && ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode != Keys.Back && e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)))))
            {
                Message m = new Message();
                m.HWnd = this.Handle;
                m.LParam = IntPtr.Zero;
                m.WParam = new IntPtr((int)Keys.Right); //right arrow key
                m.Msg = WM_KEYDOWN;
                base.WndProc(ref m);
                m.Msg = WM_KEYUP;
                base.WndProc(ref m);
                numberKeyPressed = false;
                selectionComplete = false;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            numberKeyPressed = (e.Modifiers == Keys.None && ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode != Keys.Back && e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)));
            selectionComplete = false;
            base.OnKeyDown(e);
        }
        protected override void WndProc(ref Message m)
        {   
            if (m.Msg == WM_REFLECT + WM_NOTIFY)
            {
                var hdr = (NMHDR)m.GetLParam(typeof(NMHDR));
                if (hdr.Code == -759) //date chosen (by keyboard)
                    selectionComplete = true;
            }
            base.WndProc(ref m);
        }

        bool Opened;
        protected override void OnDropDown(EventArgs eventargs)
        {
            Opened = true;
            base.OnDropDown(eventargs);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Value == null && Opened == false && DgvMode==false)
            {
                SendKeys.Send("%{DOWN}");
            }
            base.OnMouseUp(e);
        }


        #endregion
    }
}
