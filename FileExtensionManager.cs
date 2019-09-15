using System;
using System.Windows.Forms;

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
        // key (file extension) value (default program) pair
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
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //TO DO add code to delete current entry
            //using extenstion in textExtension text box
            //should show appropriate error messages if cannot delete
            //should update datafile by calling UpdateDataFile if delete is successful
            //should clear all textBoxes 
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete all entries ?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //TO DO – add code to clear all entries in collection  
                //remember to also call UpdateDataFile         
            }
            //TO DO add code to clear all text boxes
        }

            private void BtnListAll_Click(object sender, EventArgs e)
        {
            //TO DO should clear textDisplay and then
            //should iterate through collection object
            //and append text to textDisplay text box 
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            //TO DO add code to find entry
            // should update textDisplay appropriately if found 
        }

        /// <summary> 
        /// helper method for writing data to data file 
        /// </summary> 
        private void UpdateDataFile() {
            //TO DO
            //should write collection to file datafile.dat
            //easiest way is to use System.Runtime.Serialization libraries
        } 

        /// <summary>
        /// helper method for reading data from data file
        /// </summary>
        private void ReadDataFile() {
            //TO DO
            //should read in collection from file datafile.dat if it exists
            //easiest way is to use System.Runtime.Serialization libraries
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
        }
    }
}
