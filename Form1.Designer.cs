using System.Drawing;
using System.Windows.Forms;

namespace MailHtmlDelivery
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private WebBrowser webBrowser = new WebBrowser();
        private Button clearButton = new Button(), sendButton = new Button(), chooseFileButton = new Button();
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Text = "MailDelivery";
            webBrowser.Size = new System.Drawing.Size(this.ClientSize.Width - 2 * 50, this.ClientSize.Height - 120 - 50);
            webBrowser.Location = new Point(50, 50);

            InitButton(chooseFileButton,
                       "Выбрать файл",
                       new Point(50, webBrowser.Height + 50 * 2),
                       System.Drawing.Color.Black,
                       System.Drawing.Color.White);
            InitButton(sendButton,
                       "Отправить",
                       new Point(50 + 100 + clearButton.Width, webBrowser.Height + 50 * 2),
                       System.Drawing.Color.Black,
                       System.Drawing.Color.PaleGreen);
            InitButton(clearButton,
                       "Очистить",
                       new Point(50 + 100 * 2 + clearButton.Width + sendButton.Width, webBrowser.Height + 50 * 2),
                       System.Drawing.Color.Black,
                       System.Drawing.Color.GhostWhite);

            Controls.AddRange(new Control[]{ webBrowser, clearButton, sendButton, chooseFileButton });

            chooseFileButton.Click += LoadHtmlFile;
            clearButton.Click += ClearFile;
            sendButton.Click += SendMail;
        }

        private void InitButton(Button btn, string text, Point location, System.Drawing.Color foreColor, System.Drawing.Color backColor)
        {
            btn.Text = text;
            btn.Location = location;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.FlatStyle = FlatStyle.Flat;
        }
        #endregion
    }
}

