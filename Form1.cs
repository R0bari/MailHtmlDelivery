using Finances.ServiceLayer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailHtmlDelivery
{
    public partial class Form1 : Form
    {
        private string _filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void SendMail(object sender, EventArgs e)
        {
            if (_filePath.Length == 0)
            {
                MessageBox.Show("Выберите файл для отправки", "Сообщение не отправлено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MailDelivery delivery = new MailDelivery(_filePath, "r0bari", "Eviguf@77");

            try
            {
                delivery.Send("r0bari@yandex.ru", "r0bari@yandex.ru");
                MessageBox.Show("Сообщение успешно отправлено на адрес r0bari@yandex.ru", "Сообщение отправлено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка! Сообщение не отправлено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearFile(object sender, EventArgs e)
        {
            webBrowser.Navigate("about:blank");
            _filePath = "";
        }
        private void LoadHtmlFile(object sender, EventArgs e)
        {
            using FileDialog fileDialog = new OpenFileDialog
            {
                Filter = "html files (*.html)|*.html|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() != DialogResult.OK) return;
            _filePath = fileDialog.FileName;

            webBrowser.Navigate(_filePath);
        }
    }
}
