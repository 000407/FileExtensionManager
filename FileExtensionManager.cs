using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace FileExtApp
{
    /// <summary> 
    /// Form stores and displays file extensions and default program
    /// using a key/value generic collection class
    /// </summary>
    public partial class FileExtensionManager : Form
    {
        //TO DO 
        // Declare an appropriate instance variable here to store the entries as a
        // key (file extension) value (default program) pair (DICTIONARY)

        private Dictionary<string, string> fileTypeStore;
        private string filePath = "datafile.dat";

        public FileExtensionManager()
        {
            InitializeComponent();
        }

        private void BtnAddExt_Click(object sender, EventArgs e)
        {
            //TO DO add code to create new entry
            //should show appropriate error if unable to create entry
            //set textDisplay to new entry
            //clear other text boxes
            //should update data file by calling UpdateDataFile if successful
            string type = txtExtension.Text;
            string appName = txtProgramName.Text;

            if (fileTypeStore.ContainsKey(type))
            {
                fileTypeStore[type] = appName;
            }
            else {
                fileTypeStore.Add(type, appName);
            }

            txtExtension.Clear();
            txtProgramName.Clear();

            PopulateListBox();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //TO DO add code to delete current entry
            //using extenstion in textExtension text box
            //should show appropriate error messages if cannot delete
            //should update datafile by calling UpdateDataFile if delete is successful
            //should clear all textBoxes

            string selectedItem = lbDisplay.GetItemText(lbDisplay.SelectedItem);
            string[] selectedData = selectedItem.Split(':');
            string selectedKey = selectedData[0];

            if (!fileTypeStore.ContainsKey(selectedKey)) {
                return;
            }

            fileTypeStore.Remove(selectedKey);

            btnDelete.Enabled = false;
            PopulateListBox();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete all entries?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //TO DO – add code to clear all entries in collection  
                //remember to also call UpdateDataFile  
                fileTypeStore.Clear();
                PopulateListBox();
            }
            //TO DO add code to clear all text boxes
        }

        private void BtnListAll_Click(object sender, EventArgs e)
        {
            //TO DO should clear textDisplay and then
            //should iterate through collection object
            //and append text to textDisplay text box
            PopulateListBox();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            //TO DO add code to find entry
            // should update textDisplay appropriately if found 
            string key = txtFind.Text;
            txtFind.Clear();

            string program = "No default program found!";

            if (fileTypeStore.ContainsKey(key)) {
                program = fileTypeStore[key];
            }

            var result = new Dictionary<string, string>();
            result.Add(key, program);

            PopulateListBox(result);
        } 

        /// <summary> 
        /// Event handler method called when for load
        /// should read entries from data file (if it exists) 
        /// or create a new collection object (the instance variable) 
        /// </summary> 
        private void FileExtensionManager_Load(object sender, EventArgs e)
        {
            //TO DO
            // create new Collection object to store entries
            // and if data file exist, read in the data
            // by calling ReadDataFile method 
            fileTypeStore = new Dictionary<string, string>();

            ReadDataFile();
            PopulateListBox();
        }

        private void LbDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO Use this to control the Enabled/Disabled status of the delete button
            bool btnDeleteEnabled = true;

            if (lbDisplay.SelectedIndex == -1) {
                btnDeleteEnabled = false;
            }

            btnDelete.Enabled = btnDeleteEnabled;
        }

        private void FileExtensionManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO Write the changes to the permanent storage of the data (datafile.dat)
            UpdateDataFile();
        }

        /// <summary> 
        /// helper method for writing data to data file 
        /// </summary> 
        private void UpdateDataFile()
        {
            //TO DO
            //should write collection to file datafile.dat
            //easiest way is to use System.Runtime.Serialization libraries
            using (StreamWriter writer = File.AppendText(filePath))
            {
                foreach (KeyValuePair<string, string> entry in fileTypeStore)
                {
                    writer.WriteLine("{0};{1}", entry.Key, entry.Value);
                }
            }
        }

        /// <summary>
        /// helper method for reading data from data file
        /// </summary>
        private void ReadDataFile()
        {
            //TO DO
            //should read in collection from file datafile.dat if it exists
            //easiest way is to use System.Runtime.Serialization libraries
            if (!File.Exists(filePath))
            {
                //We don't need to read something non-existent
                return;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.Peek() != -1)
                {
                    string line = reader.ReadLine();
                    string[] tokens = line.Split(';');

                    fileTypeStore.Add(tokens[0], tokens[1]);
                }
            }
        }

        private void PopulateListBox()
        {
            PopulateListBox(fileTypeStore);
        }

        private void PopulateListBox(Dictionary<string, string> data)
        {
            lbDisplay.Items.Clear();

            foreach (KeyValuePair<string, string> entry in data)
            {
                lbDisplay.Items.Add(entry.Key + ":" + entry.Value);
            }
        }
    }
}
