using System;
using System.IO;
using SQLExample.Classes;
using UIKit;

namespace SQLExample
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            buttonSave.TouchUpInside += ButtonSave_TouchUpInside; // Call Method when save button is clicked/touched
        }

        void ButtonSave_TouchUpInside(object sender, EventArgs e)
        {
            string db_name = "books_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name); // set database file path to the folder & filename

            Book newBook = new Book() { Author = txtBookAuthor.Text, Name = txtBookTitle.Text };

            if (DatabaseHelper.Insert(ref newBook, db_path))
                // Console.WriteLine("Success");
                NavigationController.PopToRootViewController(true); //After adding to db, return view to root
			else
                Console.WriteLine("Failure"); // Log success/failure to console
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
