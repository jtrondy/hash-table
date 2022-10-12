namespace hash_table
{
    // Contains methods which rely on UI.

    public partial class MainForm : Form
    {
        private static Dictionary<int, Animal> myFarm = new();

        public MainForm()
        {
            InitializeComponent();
        }

        // closes app if data file read with ProfitApp.ReadFile() does not return a valid Dictionary.
        private void MainForm_Load(object sender, EventArgs e)
        {
            ProfitApp.ReadFile(myFarm);

            if (myFarm == null || myFarm.Count == 0)
            {
                Close();
            }
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            if (!SetMilkVaccinePrice())
            {
                TbOutput.ResetText();
                return;
            }

            TbOutput.Text = ProfitApp.ProfitTotal(myFarm);
        }

        // returns bool to indicate if prices are successfully set.
        private bool SetMilkVaccinePrice()
        {
            bool cowMilkValid = double.TryParse(TbCowMilk.Text, out Prices.cowMilkPrice),
                goatMilkValid = double.TryParse(TbGoatMilk.Text, out Prices.goatMilkPrice),
                cowVaccineValid = double.TryParse(TbCowVaccine.Text, out Prices.cowVaccineCost),
                goatVaccineValid = double.TryParse(TbGoatVaccine.Text, out Prices.goatVaccineCost),
                jerseyVaccineValid = double.TryParse(TbJerseyVaccine.Text, out Prices.jerseyVaccineCost);

            // ensure each textbox value can parse as double, if any fail, display error.
            if (!cowMilkValid || !goatMilkValid || !cowVaccineValid || !goatVaccineValid || !jerseyVaccineValid)
            {
                MessageBox.Show("Invalid input: Floating point numbers only");
                // indicate failure.
                return false;
            }
            // indicate success.
            return true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jared Stevenson\r\nCOMP609 - 2022");
        }
    }
}
