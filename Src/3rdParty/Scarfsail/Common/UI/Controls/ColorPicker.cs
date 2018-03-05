using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Scarfsail.Common.UI.Controls
{
    //***************************************************************************************************
    // This class is inspired by one part of code at: http://www.codeproject.com/KB/combobox/CustomColorComboBox.aspx
    // Changed by: Ondrej Salplachta
    //***************************************************************************************************

    ///<summary>
    ///This class represends the control that has all the color radio buttons.
    ///this control gets embedded into the PopupWindow class.
    ///</summary>
    public class ColorPicker : UserControl
    {
        public ColorPicker()
        {           
            InitializeComponent();

            SetupButtons();
            
            this.Paint += new PaintEventHandler(DoPaintBorder);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "ColorPicker";
            this.Text = "";
            this.ResumeLayout(false);
        }

        ///<summary>whether to show 16 colors or the extended colors</summary>
        public Boolean ExtendedColors
        {
            set
            {
                extended = value;
                SetupButtons();
            }
            get
            {
                return extended;
            }
        }

        private char selectedForeColorText = 'F';
        private char selectedBackColorText = 'B';

        public char SelectedForeColorText
        {
            get
            {
                return selectedForeColorText;
            }
            set
            {
                selectedForeColorText = value;
                foreach (ColorRadioButton btn in this.buttons)
                {
                    btn.SelectedForeColorText = value;
                }
            }
        }
        public char SelectedBackColorText
        {
            get
            {
                return selectedBackColorText;
            }
            set
            {
                selectedBackColorText = value;
                foreach (ColorRadioButton btn in this.buttons)
                {
                    btn.SelectedBackColorText = value;
                }
            }
        }
        
        ///<summary>Count of columns with color buttons </summary>
        public int ColumnsCount
        {
            get
            {
                return this.columnsCount;
            }
            set
            {
                this.columnsCount = value;
                SetupButtons();
            }
        }

        /// <summary>Size of one color button</summary>
        public int ButtonSize
        {
            get
            {
                return this.buttonSize;
            }
            set
            {
                this.buttonSize = value;
                SetupButtons();
            }
        }

        ///<summary>Get or set the selected color</summary>
        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }
            set
            {
                selectedColor = value;
                Color[] colors = extended ? this.extendedColors : this.colors;
                for (int i = 0; i < colors.Length; i++)
                {
                    buttons[i].SelectedAsBackground = (selectedColor.R == colors[i].R && selectedColor.G == colors[i].G && selectedColor.B == colors[i].B);                    
                }
            }
        }

        ///<summary>Get or set the selected fore color</summary>
        public Color SelectedForeColor
        {
            get
            {
                return selectedForeColor;
            }
            set
            {
                selectedForeColor = value;
                Color[] colors = extended ? this.extendedColors : this.colors;
                for (int i = 0; i < colors.Length; i++)
                {
                    buttons[i].SelectedAsForeground = (selectedForeColor.R == colors[i].R && selectedForeColor.G == colors[i].G && selectedForeColor.B == colors[i].B);
                }
            }
        }



        /// <summary>Raised when user select another color </summary>
        public event EventHandler SelectedColorChanged;
        public event EventHandler SelectedForeColorChanged;

        //place the buttons on the window.
        private void SetupButtons()
        {
            Controls.Clear();

            int x = 3;
            int y = 3;
            int breakCount = this.columnsCount;
            Color[] colors = extended ? this.extendedColors : this.colors;
            this.buttons = new ColorRadioButton[colors.Length];

            int maxX = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                if (i > 0 && i % breakCount == 0)
                {
                    y += this.buttonSize;
                    x = 3;
                }
                buttons[i] = new ColorRadioButton(colors[i], this.BackColor, new Size(this.buttonSize, this.buttonSize), this.SelectedForeColorText, this.SelectedBackColorText);
                buttons[i].Location = new Point(x, y);
                Controls.Add(buttons[i]);
                buttons[i].Click += new EventHandler(DoColorBtnClicked);
                buttons[i].RightClick += new EventHandler(DoColorBtnRightClicked);
                
                if (selectedColor == colors[i])
                {
                    buttons[i].Checked = true;
                }
                x += this.buttonSize;
                maxX = Math.Max(x, maxX);
            }
            moreColorsBtn = new Button();
            moreColorsBtn.Text = "More Colors ...";
            moreColorsBtn.Location = new Point(3, y + this.buttonSize + 3);
            moreColorsBtn.Size = new Size(maxX - 3, moreColorsBtn.Size.Height);
            moreColorsBtn.Click += new EventHandler(DoMoreColorsClicked);
            Controls.Add(moreColorsBtn);

            this.SelectedColor = Color.Black;
            this.SelectedForeColor = Color.White;
        }

        private void DoColorBtnClicked(object sender, EventArgs e)
        {
            SelectedColor = ((ColorRadioButton)sender).ForeColor;
            this.OnSelectedColorChanged();
        }

        void DoColorBtnRightClicked(object sender, EventArgs e)
        {
            SelectedForeColor = ((ColorRadioButton)sender).ForeColor;
            this.OnSelectedForeColorChanged();
        }


        private void DoPaintBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black), this.ClientRectangle);
        }

        private void DoMoreColorsClicked(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = SelectedColor;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                SelectedColor = dlg.Color;
                this.OnSelectedColorChanged();
            }
        }

        private void OnSelectedColorChanged()
        {
            if (this.SelectedColorChanged != null)
                this.SelectedColorChanged(this, null);
        }

        private void OnSelectedForeColorChanged()
        {
            if (this.SelectedForeColorChanged != null)
                this.SelectedForeColorChanged(this, null);
        }

        /// <summary>A button style radio button that shows a color</summary>
        private class ColorRadioButton : RadioButton
        {
            public ColorRadioButton(Color color, Color backColor, Size size, char SelectedForeColorText, char SelectedBackColorText)
            {
                this.ClientSize = size;
                this.Appearance = Appearance.Button;
                this.Name = "button1";
                this.Visible = true;
                this.ForeColor = color;
                this.FlatAppearance.BorderColor = backColor;
                this.FlatAppearance.BorderSize = 0;
                this.FlatStyle = FlatStyle.Flat;
                this.SelectedForeColorText = SelectedForeColorText;
                this.SelectedBackColorText = SelectedBackColorText;

                this.Paint += new PaintEventHandler(OnPaintButton);
                this.MouseDown += ColorRadioButton_MouseDown;
                this.MouseUp += ColorRadioButton_MouseUp;
                this.MouseLeave += ColorRadioButton_MouseLeave;
            }

            private bool selectedAsBackground;
            private bool selectedAsForeground;
            private bool isMouseDown = false;

            public event EventHandler RightClick;

            public char SelectedForeColorText;
            public char SelectedBackColorText;

            public bool SelectedAsBackground 
            {
                set
                {
                    this.selectedAsBackground = value;
                    this.Checked = value;
                    this.Invalidate();
                }
                get
                {
                    return this.selectedAsBackground;
                }
            }

            public bool SelectedAsForeground 
            {
                set
                {
                    this.selectedAsForeground = value;
                    this.Invalidate();
                }
                get
                {
                    return this.selectedAsForeground;
                }
            }

            public bool Selected
            {
                get
                {
                    return this.SelectedAsBackground || this.SelectedAsForeground;
                }
            }

            void ColorRadioButton_MouseLeave(object sender, EventArgs e)
            {
                this.isMouseDown = false;
            }

            void ColorRadioButton_MouseUp(object sender, MouseEventArgs e)
            {
                if (this.isMouseDown && e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.isMouseDown = false;
                    this.OnRightClick();
                }
            }

            void ColorRadioButton_MouseDown(object sender, MouseEventArgs e)
            {
                this.isMouseDown = true;
            }
            
            private void OnPaintButton(object sender, PaintEventArgs e)
            {
                //paint a square on the face of the button using the controls foreground color
                Rectangle colorRect = new Rectangle(ClientRectangle.Left + 4, ClientRectangle.Top + 4, ClientRectangle.Width - 9, ClientRectangle.Height - 9);
                e.Graphics.FillRectangle(new SolidBrush(this.ForeColor), colorRect);
                e.Graphics.DrawRectangle(new Pen(Color.Black), colorRect);
                
                if (this.Selected)
                {
                    Brush brush = this.ForeColor.GetBrightness() > 0.4 ? Brushes.Black : Brushes.White;
                    e.Graphics.DrawString(Convert.ToString(this.SelectedAsBackground ? this.SelectedBackColorText : this.SelectedForeColorText), new Font(FontFamily.GenericSerif, 8, GraphicsUnit.Pixel), brush, new PointF(6, 5));
                }
            }

            private void OnRightClick()
            {
                if (this.RightClick != null)
                    this.RightClick(this, null);
            }
        }


        private Color[] colors = { Color.Black, Color.Gray, Color.Maroon, Color.Olive, Color.Green, Color.Teal, Color.Navy, Color.Purple, Color.White, Color.Silver, Color.Red, Color.Yellow, Color.Lime, Color.Aqua, Color.Blue, Color.Fuchsia };
        private Color[] extendedColors = { Color.FromArgb(255, 128, 128), 
                                           Color.FromArgb(255,255,128), 
                                           Color.FromArgb(128, 255, 128),
                                           Color.FromArgb(0, 255, 128),
                                           Color.FromArgb(128, 255, 255),
                                           Color.FromArgb(0, 128, 255),
                                           Color.FromArgb(255, 128, 192),
                                           Color.FromArgb(255, 128, 255),
                                           
                                           Color.FromArgb(255, 0, 0),
                                           Color.FromArgb(255, 255, 0),
                                           Color.FromArgb(128, 255, 0),
                                           Color.FromArgb(0, 255, 64),
                                           Color.FromArgb(0, 255, 255),
                                           Color.FromArgb(0, 128, 192),
                                           Color.FromArgb(128, 128, 192),
                                           Color.FromArgb(255, 0, 255),

                                           Color.FromArgb(128, 64, 64),
                                           Color.FromArgb(255, 128, 64),
                                           Color.FromArgb(0, 255, 0),
                                           Color.FromArgb(0, 128, 128),
                                           Color.FromArgb(0, 64, 128),
                                           Color.FromArgb(128, 128, 255),
                                           Color.FromArgb(128, 0, 64),
                                           Color.FromArgb(255, 0, 128),

                                           Color.FromArgb(128, 0, 0),
                                           Color.FromArgb(255, 128, 0),
                                           Color.FromArgb(0, 128, 0),
                                           Color.FromArgb(0, 128, 64),
                                           Color.FromArgb(0, 0, 255),
                                           Color.FromArgb(0, 0, 160),
                                           Color.FromArgb(128, 0, 128),
                                           Color.FromArgb(128, 0, 255),
                                           
                                           Color.FromArgb(64, 0, 0),
                                           Color.FromArgb(128, 64, 0),
                                           Color.FromArgb(0, 64, 0),
                                           Color.FromArgb(0, 64, 64),
                                           Color.FromArgb(0, 0, 128),
                                           Color.FromArgb(0, 0, 64),
                                           Color.FromArgb(64, 0, 64),
                                           Color.FromArgb(64, 0, 128),
                                           
                                           Color.FromArgb(0, 0, 0),
                                           Color.FromArgb(128, 128, 0),
                                           Color.FromArgb(128, 128, 64),
                                           Color.FromArgb(128, 128, 128),
                                           Color.FromArgb(64, 128, 128),
                                           Color.FromArgb(192, 192, 192),
                                           Color.FromArgb(64, 0, 64),
                                           Color.FromArgb(255, 255, 255)                                           
                                         };

        private ColorRadioButton[] buttons;
        private Button moreColorsBtn;
        private Color selectedColor = Color.Black;
        private Color selectedForeColor = Color.White;
        private Boolean extended = false;
        private int columnsCount = 4;
        private int buttonSize = 30;
    }
}
