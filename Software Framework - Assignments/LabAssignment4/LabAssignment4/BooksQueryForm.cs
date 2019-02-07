using LabAssignment4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookQueries
{
    public partial class BooksQueryForm : Form
    {
        public BooksQueryForm()
        {
            InitializeComponent();
        }

        private void button_FullOutput(object sender, EventArgs e)
        {
            textBoxResultText.Clear();
            BooksEntities beDBContent = new BooksEntities();

            //Option A - List of all the titles and the authors who wrote them. Result sorted by title.
            var optionA =
               from author in beDBContent.Authors
               from title in author.Titles
               orderby title.Title1
               select new { title.Title1 , author.FirstName, author.LastName};
            textBoxResultText.AppendText("Titles and Authors sorted by title:");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");

            foreach (var item in optionA)
            {
                textBoxResultText.AppendText(item.Title1+" "+item.FirstName+" "+item.LastName+"\n");
            }
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");

            //Option B - List of all the titles and the authors who wrote them. Result sorted by title. 
            //For each title, the authors are sorted alphabetically by last name, then first name.
            var optionB =
               from author in beDBContent.Authors
               from title in author.Titles
               orderby title.Title1, author.LastName, author.FirstName
               select new { title.Title1, author.FirstName, author.LastName };
            textBoxResultText.AppendText("Titles and Authors sorted by title with each title sorted by authors name:");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");

            foreach (var item in optionB)
            {
                textBoxResultText.AppendText(item.Title1 + " " + item.FirstName + " " + item.LastName + "\n");
            }
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");

            //Option C - List of all the authors grouped by title, sorted by title.
            //For a given title the author names are sorted alphabetically by last name first then first name.
            var optionC =
                from title in beDBContent.Titles
                orderby title.Title1
                select new
                {
                    Name = title.Title1,
                    authorNames =
                    from author in title.Authors
                    orderby author.LastName, author.FirstName
                    select new { author.FirstName, author.LastName }

                };
            textBoxResultText.AppendText("Authors grouped by title, sorted by title and with each title sorted by authors name:");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");

            foreach (var title in optionC)
            {
                textBoxResultText.AppendText(title.Name + ":\n");
                foreach (var author in title.authorNames)
                {
                    textBoxResultText.AppendText(author.FirstName + " " + author.LastName + "\n");
                } 
            }
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");
        }

        private void button_OptionA(object sender, EventArgs e)
        {
            textBoxResultText.Clear();
            BooksEntities beDBContent = new BooksEntities();

            //Option A - List of all the titles and the authors who wrote them. Result sorted by title.
            var optionA =
               from author in beDBContent.Authors
               from title in author.Titles
               orderby title.Title1
               select new { title.Title1, author.FirstName, author.LastName };
            textBoxResultText.AppendText("Titles and Authors who wrote them:");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");

            foreach (var item in optionA)
            {
                textBoxResultText.AppendText(item.Title1 + " " + item.FirstName + " " + item.LastName + "\n");
            }
        }

        private void button_OptionB(object sender, EventArgs e)
        {
            textBoxResultText.Clear();
            BooksEntities beDBContent = new BooksEntities();

            //Option B - List of all the titles and the authors who wrote them. Result sorted by title. 
            //For each title, the authors are sorted alphabetically by last name, then first name.
            var optionB =
              from author in beDBContent.Authors
              from title in author.Titles
              orderby title.Title1, author.LastName, author.FirstName
              select new { title.Title1, author.FirstName, author.LastName };
            textBoxResultText.AppendText("Titles and Authors sorted by title with each title sorted by authors name:");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");

            foreach (var item in optionB)
            {
                textBoxResultText.AppendText(item.Title1 + " " + item.FirstName + " " + item.LastName + "\n");
            }
        }

        private void button_OptionC(object sender, EventArgs e)
        {
            textBoxResultText.Clear();
            BooksEntities beDBContent = new BooksEntities();

            //Option C - List of all the authors grouped by title, sorted by title.
            //For a given title the author names are sorted alphabetically by last name first then first name.
            var optionC =
                from title in beDBContent.Titles
                orderby title.Title1
                select new
                {
                    Name = title.Title1,
                    authorNames =
                    from author in title.Authors
                    orderby author.LastName, author.FirstName
                    select new { author.FirstName, author.LastName }

                };
            textBoxResultText.AppendText("Authors grouped by title, sorted by title and with each title sorted by authors name:");
            textBoxResultText.AppendText("\n");
            textBoxResultText.AppendText("\n");

            foreach (var title in optionC)
            {
                textBoxResultText.AppendText(title.Name + ":\n");
                foreach (var author in title.authorNames)
                {
                    textBoxResultText.AppendText(author.FirstName + " " + author.LastName + "\n");
                }
            }
        }
    }
}

       
