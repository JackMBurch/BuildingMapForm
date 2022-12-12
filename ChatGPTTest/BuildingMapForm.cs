namespace BuildingMap
{
    public partial class BuildingMapForm : Form
    {
        // The images for the clean and dirty floors and empty and full trash cans.
        private Image floorCleanImage = Image.FromFile("C:\\Users\\jackb\\Pictures\\chatGPT\\floor_clean.png");
        private Image floorDirtyImage = Image.FromFile("C:\\Users\\jackb\\Pictures\\chatGPT\\floor_dirty.png");
        private Image trashcanEmptyImage = Image.FromFile("C:\\Users\\jackb\\Pictures\\chatGPT\\trashcan_empty.png");
        private Image trashcanFullImage = Image.FromFile("C:\\Users\\jackb\\Pictures\\chatGPT\\trashcan_full.png");

        // The array of floor picture boxes and the array of trash can picture boxes.
        private PictureBox[,] floorPictureBoxes;
        private PictureBox[,] trashcanPictureBoxes;

        // The button to empty the trash cans and clean the floors.
        private Button cleanButton;
        // The button to fill the trash cans and dirty the floors.
        private Button dirtyButton;

        private Random floorRandom;
        private Random trashcanRandom;

        public BuildingMapForm()
        {

            // Set the form's title and size.
            this.Text = "Building Map";
            this.Size = new Size(1022, 1255);

            // Create the arrays of floor picture boxes and trash can picture boxes.
            floorPictureBoxes = new PictureBox[10, 10];
            trashcanPictureBoxes = new PictureBox[10, 10];

            // Create random number generators for the floors and trash cans.
            floorRandom = new Random();
            trashcanRandom = new Random();

            // Create the picture boxes for the floors and trash cans and add them to the form.
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    // Create a picture box for the floor and set its image and location.
                    floorPictureBoxes[row, col] = new PictureBox();
                    floorPictureBoxes[row, col].Size = new Size(100, 100);
                    // Use the random number generator to decide if the floor image should be dirty.
                    // If the generated number is less than or equal to 0.5, use the dirty floor image.
                    // Otherwise, use the clean floor image.
                    if (floorRandom.NextDouble() <= 0.5)
                    {
                        floorPictureBoxes[row, col].Image = floorDirtyImage;
                    }
                    else
                    {
                        floorPictureBoxes[row, col].Image = floorCleanImage;
                    }
                    floorPictureBoxes[row, col].Location = new Point(100 * col, 100 * row);
                    // Set the BackColor property of the picture box to transparent.
                    floorPictureBoxes[row, col].BackColor = Color.Transparent;
                    // Set the SizeMode property of the picture box to stretch the image.
                    floorPictureBoxes[row, col].SizeMode = PictureBoxSizeMode.StretchImage;
                    // Add the floor picture box to the form.
                    this.Controls.Add(floorPictureBoxes[row, col]);

                    if (trashcanRandom.NextDouble() <= 0.15)
                    {
                        // Create a picture box for the trash can and set its image and location.
                        trashcanPictureBoxes[row, col] = new PictureBox();
                        trashcanPictureBoxes[row, col].Size = new Size(100, 100);
                        // Use the random number generator to decide if the trash can image should be full.
                        // If the generated number is less than or equal to 0.5, use the full trash can image.
                        // Otherwise, use the empty trash can image.
                        if (trashcanRandom.NextDouble() <= 0.25)
                        {
                            trashcanPictureBoxes[row, col].Image = trashcanFullImage;
                        }
                        else
                        {
                            trashcanPictureBoxes[row, col].Image = trashcanEmptyImage;
                        }
                        // Set the BackColor property of the picture box to transparent.
                        trashcanPictureBoxes[row, col].BackColor = Color.Transparent;
                        // Set the SizeMode property of the picture box to stretch the image.
                        trashcanPictureBoxes[row, col].SizeMode = PictureBoxSizeMode.StretchImage;
                        // Add the trash can picture box as a child of the floor picture box.
                        floorPictureBoxes[row, col].Controls.Add(trashcanPictureBoxes[row, col]);
                        // Bring the floor picture box to the front.
                        trashcanPictureBoxes[row, col].BringToFront();
                    }
                }
            }


            // Create the clean button and set its properties.
            cleanButton = new Button();
            cleanButton.Text = "Clean";
            cleanButton.Size = new Size(100, 30);
            cleanButton.Location = new Point(450, 1050);
            cleanButton.BringToFront();

            // Create the dirty button and set its properties.
            dirtyButton = new Button();
            dirtyButton.Text = "Dirty";
            dirtyButton.Size = new Size(100, 30);
            dirtyButton.Location = new Point(450, 1100);
            dirtyButton.BringToFront();

            // Add the event handler for the buttons.
            cleanButton.Click += CleanButton_Click;
            dirtyButton.Click += DirtyButton_Click;

            // Add the buttons to the form.
            this.Controls.Add(cleanButton);
            this.Controls.Add(dirtyButton);
        }

        // The event handler for the clean button.
        private void CleanButton_Click(object sender, EventArgs e)
        {
            // Loop through the arrays of floor and trash can picture boxes.
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    // Clean the floor and empty the trash can.
                    if (floorPictureBoxes[row, col] != null)
                    {
                        floorPictureBoxes[row, col].Image = floorCleanImage;
                    }

                    if (trashcanPictureBoxes[row, col] != null)
                    {
                        trashcanPictureBoxes[row, col].Image = trashcanEmptyImage;
                    }
                }
            }
        }

        // The event handler for the dirty button.
        private void DirtyButton_Click(object sender, EventArgs e)
        {
            // Loop through the arrays of floor and trash can picture boxes.
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    // Dirty 10% of the floors and fill 5% of the trash cans.
                    if (floorPictureBoxes[row, col] != null && floorRandom.NextDouble() < 0.1)
                    {
                        floorPictureBoxes[row, col].Image = floorDirtyImage;
                    }

                    if (trashcanPictureBoxes[row, col] != null && trashcanRandom.NextDouble() < 0.05)
                    {
                        trashcanPictureBoxes[row, col].Image = trashcanFullImage;
                    }
                }
            }
        }

    }
}
