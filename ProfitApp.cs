namespace hash_table
{
    public static class ProfitApp
    {
        // add up total profit of all animals and return string usable by textbox.
        public static string ProfitTotal(Dictionary<int, Animal> myFarm)
        {
            double totalProfit = 0;

            foreach (KeyValuePair<int, Animal> i in myFarm)
            {
                totalProfit += i.Value.CalculateProfitPerDay();
            }
            return $"${totalProfit:0.00}";
        }

        public static void ReadFile(Dictionary<int, Animal> myFarm)
        {
            try
            {
                string filePath = "../../../data.txt";
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    MessageBox.Show("File is empty");
                    return;
                }

                // loop through every line in lines.
                foreach (string line in lines)
                {
                    // split line by ",".  
                    string[] animal = line.Split(",");
                    int ID = int.Parse(animal[0]);
                    double litresOfMilk = double.Parse(animal[1]);
                    string typeOfAnimal = animal[2].ToLower().Trim();

                    // create new instance of class based on animal type animal[2].
                    switch (typeOfAnimal)
                    {
                        case "cow":
                            myFarm.Add(ID, new Cow(ID, litresOfMilk));
                            break;
                        case "goat":
                            myFarm.Add(ID, new Goat(ID, litresOfMilk));
                            break;
                        case "jersey_cow":
                            myFarm.Add(ID, new Jersey_Cow(ID, litresOfMilk));
                            break;
                    }
                }
            }
            // catches missing file/incorrect file path.
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
                myFarm.Clear();
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"File data is not in valid state:\r\n{ex.Message}");
                myFarm.Clear();
            }
            // unique key violation
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}");
                myFarm.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Exception occured:\r\n{ex.Message}");
                myFarm.Clear();
            }
            return;
        }
    }
}
