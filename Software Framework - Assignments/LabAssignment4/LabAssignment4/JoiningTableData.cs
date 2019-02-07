using LabAssignment4;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BookQueries
{
    public partial class JoiningTableData : Form
    {
        public JoiningTableData()
        {
            InitializeComponent();
        } 

        private void JoiningTableData_Load(object sender, EventArgs e)
        {
            BooksEntities dbcontext =
               new BooksEntities();

            var authorsAndISBNs =
               from author in dbcontext.Authors
               from book in author.Titles
               orderby author.LastName, author.FirstName
               select new { author.FirstName, author.LastName, book.ISBN };

            textBoxOutputTextBox.AppendText("Authors and ISBNs:");
            
            foreach (var element in authorsAndISBNs)
            {
                textBoxOutputTextBox.AppendText(
                   String.Format("\r\n\t{0,-10} {1,-10} {2,-10}",
                      element.FirstName, element.LastName, element.ISBN));
            } 

            var authorsAndTitles =
               from book in dbcontext.Titles
               from author in book.Authors
               orderby author.LastName, author.FirstName, book.Title1
               select new
               {
                   author.FirstName,
                   author.LastName,
                   book.Title1
               };

            textBoxOutputTextBox.AppendText("\r\n\r\nAuthors and titles:");

            foreach (var element in authorsAndTitles)
            {
                textBoxOutputTextBox.AppendText(
                   String.Format("\r\n\t{0,-10} {1,-10} {2}",
                      element.FirstName, element.LastName, element.Title1));
            } 

            var titlesByAuthor =
               from author in dbcontext.Authors
               orderby author.LastName, author.FirstName
               select new
               {
                   Name = author.FirstName + " " + author.LastName,
                   Titles =
                     from book in author.Titles
                     orderby book.Title1
                     select book.Title1
               };

            textBoxOutputTextBox.AppendText("\r\n\r\nTitles grouped by author:");

            foreach (var author in titlesByAuthor)
            {
                textBoxOutputTextBox.AppendText("\r\n\t" + author.Name + ":");

                foreach (var title in author.Titles)
                {
                    textBoxOutputTextBox.AppendText("\r\n\t\t" + title);
                } 
            } 
        } 
    } 
} 

