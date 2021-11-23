using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Xsl;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetComboBoxItems();
        }
        static class ActiveParametrs
        {
            public static bool nameActive=false;
            public static bool facultyActive=false;
            public static bool cathedraActive=false;
            public static bool courseActive=false;
            public static bool dataActive=false;
        }
        public class People
        {
            public string name;
            public string faculty;
            public string cathedra;
            public string course;
            public string data;
            public People(string n, string f, string cath, string cour, string d)
            {
                name = n;
                faculty = f;
                cathedra = cath;
                course = cour;
                data = d;
            }
            public People()
            {
                name = "";
                faculty = "";
                cathedra = "";
                course = "";
                data = "";
            }
            public string String()
            {

                return name+'\n'+faculty+'\n'+cathedra+'\n'+course+'\n'+data;
            }
        }
        class Context
        {
            private IStrategy _strategy;
            public Context() { }
            public Context(IStrategy strategy)
            {
                this._strategy = strategy;
            }
            public void SetStrategy(IStrategy strategy)
            {
                this._strategy = strategy;
            }
            public string SearchResult(People people)
            {
                string result="";
                var p = _strategy.Search(people);
                foreach (var i in p)
                {
                    result += i.String() + '\n';
                }
                return result;
            }
            public void TransformFile(People people)
            {
                XslCompiledTransform xslt = new XslCompiledTransform();
                string f1 = "C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\XSLFile1.xsl";
                xslt.Load(f1);
                string f2 = "C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\File112.xml";
                XDocument xDoc = _strategy.CreateFile(people);
                xDoc.Save("C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\File112.xml");
                string f3 = "C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\people112.html";
                xslt.Transform(f2, f3);
            }
        }
        public interface IStrategy
        {
            public List<People> Search(People people);
            public XDocument CreateFile(People people);  
        }
        class linqStrategy : IStrategy
        {
            public List<People> Search(People p)
            {
                List<People> Result = new List<People>();
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load("C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\File.xml");
                foreach (XElement people in xDoc.Element("hotel").Elements("people"))
                {
                    XAttribute firstname = people.Attribute("firstname");
                    XAttribute secondname = people.Attribute("secondname");
                    XAttribute patronymic = people.Attribute("patronymic");
                    XElement faculty = people.Element("faculty");
                    XElement cathedra = people.Element("cathedra");
                    XElement course = people.Element("course");
                    XElement data = people.Element("data");
                    string name = secondname.Value + " " + firstname.Value + " " + patronymic.Value;

                    if (Search(name, p.name, ActiveParametrs.nameActive) && Search(faculty.Value, p.faculty, ActiveParametrs.facultyActive)
                        && Search(cathedra.Value, p.cathedra, ActiveParametrs.cathedraActive)&& Search(course.Value, p.course, ActiveParametrs.courseActive)
                        && Search(data.Value, p.data, ActiveParametrs.dataActive)) 
                    {
                        Result.Add(new People(name, faculty.Value, cathedra.Value, course.Value, data.Value));
                    }
                }
                return Result;
            }
            public XDocument CreateFile(People p)
            {
                XDocument Result = new XDocument();
                XDocument xDoc = new XDocument();
                XElement hotel = new XElement("hotel");
                xDoc = XDocument.Load("C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\File.xml");
                foreach (XElement people in xDoc.Element("hotel").Elements("people"))
                {
                    XAttribute firstname = people.Attribute("firstname");
                    XAttribute secondname = people.Attribute("secondname");
                    XAttribute patronymic = people.Attribute("patronymic");
                    XElement faculty = people.Element("faculty");
                    XElement cathedra = people.Element("cathedra");
                    XElement course = people.Element("course");
                    XElement data = people.Element("data");
                    string name = secondname.Value + " " + firstname.Value + " " + patronymic.Value;

                    if (Search(name, p.name, ActiveParametrs.nameActive) && Search(faculty.Value, p.faculty, ActiveParametrs.facultyActive)
                        && Search(cathedra.Value, p.cathedra, ActiveParametrs.cathedraActive) && Search(course.Value, p.course, ActiveParametrs.courseActive)
                        && Search(data.Value, p.data, ActiveParametrs.dataActive))
                    {
                        XElement Pe = new XElement("people");
                        Pe.Add(patronymic);
                        Pe.Add(secondname);
                        Pe.Add(firstname);
                        Pe.Add(faculty);
                        Pe.Add(cathedra);
                        Pe.Add(course);
                        Pe.Add(data);
                        hotel.Add(Pe);
                    }
                }
                Result.Add(hotel);
                return Result;
            }
            bool Search(string parametr1, string parametr2, bool Active)
            {
                if (Active == false) return true;
                return parametr1 == parametr2;
            }
        }
        class domStrategy : IStrategy
        {
            public List<People> Search(People people)
            {
                return null;
            }
            public XDocument CreateFile(People people)
            { return null; }
        }
        class saxStrategy : IStrategy
        {
            public List<People> Search(People people)
            {
                return null;
            }
            public XDocument CreateFile(People people)
            { return null; }
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
            linqStrategy linq = new linqStrategy();
            Context context = new Context(linq);
            richTextBox1.Text = context.SearchResult(new People(nameBox.Text,facultyBox.Text,cathedraBox.Text,courseBox.Text,dataBox.Text));
        }
        public void NewComboBoxItems()
        {
            nameBox.Items.Clear();
            facultyBox.Items.Clear();
            cathedraBox.Items.Clear();
            dataBox.Items.Clear();
            courseBox.Items.Clear();
            SetComboBoxItems();
        }
        public void SetComboBoxItems()
        {
            XDocument xDoc = new XDocument();
            xDoc = XDocument.Load("C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\File.xml");
            foreach (XElement people in xDoc.Element("hotel").Elements("people"))
            {
                XAttribute firstname = people.Attribute("firstname");
                XAttribute secondname = people.Attribute("secondname");
                XAttribute patronymic = people.Attribute("patronymic");
                XElement faculty = people.Element("faculty");
                XElement cathedra = people.Element("cathedra");
                XElement course = people.Element("course");
                XElement data = people.Element("data");
                string name = secondname.Value + " " + firstname.Value + " " + patronymic.Value;
                addItems(name, faculty.Value, cathedra.Value, data.Value, course.Value);
            }
        }
        public void addItems(string name,string faculty,string cathedra,string data,string course)
        {
            if (nameBox.Items.Contains(name) == false)
            {
                nameBox.Items.Add(name);
            }
            if (facultyBox.Items.Contains(faculty) == false)
            {
                facultyBox.Items.Add(faculty);
            }
            if (cathedraBox.Items.Contains(cathedra) == false)
            {
                cathedraBox.Items.Add(cathedra);
            }
            if (dataBox.Items.Contains(data) == false)
            {
                dataBox.Items.Add(data);
            }
            if (courseBox.Items.Contains(course) == false)
            {
                courseBox.Items.Add(course);
            }

        }
        private void nameBox_Click(object sender, EventArgs e)
        {
            NewComboBoxItems();
        }
        private void cathedra_Click(object sender, EventArgs e)
        {
            NewComboBoxItems();
        }
        private void faculty_Click(object sender, EventArgs e)
        {
            NewComboBoxItems();
        }
        private void data_Click(object sender, EventArgs e)
        {
            NewComboBoxItems();
        }
        private void course_Click(object sender, EventArgs e)
        {
            NewComboBoxItems();
        }
        private void nameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Button = (CheckBox)sender;
            ActiveParametrs.nameActive = Button.Checked;
        }
        private void facultyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Button = (CheckBox)sender;
            ActiveParametrs.facultyActive = Button.Checked;
        }
        private void cathedraСheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Button = (CheckBox)sender;
            ActiveParametrs.cathedraActive = Button.Checked;
        }
        private void dataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Button = (CheckBox)sender;
            ActiveParametrs.dataActive = Button.Checked;
        }
        private void courseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Button = (CheckBox)sender;
            ActiveParametrs.courseActive = Button.Checked;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            linqStrategy linq = new linqStrategy();
            Context context = new Context(linq);
            context.TransformFile(new People(nameBox.Text, facultyBox.Text, cathedraBox.Text, courseBox.Text, dataBox.Text));
        }
    }
}
