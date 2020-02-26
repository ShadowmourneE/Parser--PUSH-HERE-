namespace ParseTheDocument
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
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
                //TEST functionality
                //var test = ParserExtension.PrepareEnteredTextAsTemplateToParse(openFileDialog.FileName);
                _parser.StartParse(openFileDialog.FileName);
                await _parser.ExportToExcelAsync();

                MessageBox.Show("Successfully written in .xlsx - see C: SomeDir Folder:");

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
