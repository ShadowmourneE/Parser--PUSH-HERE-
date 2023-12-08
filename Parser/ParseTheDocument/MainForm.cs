namespace ParseTheDocument
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;


    public partial class MainForm : Form
    {
        MultipleLevelsParser _parser;
        public MainForm()
        {
            InitializeComponent();
            _parser = new MultipleLevelsParser();
        }
        private void Form1_Load(object sender, EventArgs e) {}

        private void shwReportBtn_Click(object sender, EventArgs e) {}
       
        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private async void openBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _parser.StartParse(openFileDialog.FileName);
                var fileName = $@"{Path.GetDirectoryName(openFileDialog.FileName)}\{Path.GetFileNameWithoutExtension(openFileDialog.FileName)}.xlsx";
                await _parser.ExportToExcelAsync(fileName);

                MessageBox.Show($@"Successfully written to ""{fileName}""");

                Application.Exit();
            }
        }
        // from the followi two.
        //and box without mix

        private void unitsNumeration_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void errortextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
