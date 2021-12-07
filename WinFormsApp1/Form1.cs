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
using System.Xml;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetComboBoxItems();
            radioButtonLINQ_CheckedChanged(this, EventArgs.Empty);
            radioButtonLINQ.Checked = true;
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
                var p = _strategy.search(people);
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
                Document Doc = _strategy.CreateFile(people);
                if (Doc.doc == null)
                {
                    XDocument xDoc = Doc.XDoc;
                    xDoc.Save("C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\File112.xml");
                    string f3 = "C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\people112.html";
                    xslt.Transform(f2, f3);
                }
                else 
                {
                    XmlDocument Xdoc = Doc.doc;
                    Xdoc.Save("C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\File112.xml");
                    string f3 = "C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\people112.html";
                    xslt.Transform(f2, f3);
                }
            }
        }
        public class Document
        {
            public XmlDocument doc;
            public XDocument XDoc;
        }
        public interface IStrategy
        {
            public List<People> search(People people);
            public Document CreateFile(People people);  
        }
        
        class linqStrategy : IStrategy
        {
            public List<People> search(People p)
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

                    if (search(name, p.name, ActiveParametrs.nameActive) && search(faculty.Value, p.faculty, ActiveParametrs.facultyActive)
                        && search(cathedra.Value, p.cathedra, ActiveParametrs.cathedraActive)&& search(course.Value, p.course, ActiveParametrs.courseActive)
                        && search(data.Value, p.data, ActiveParametrs.dataActive)) 
                    {
                        Result.Add(new People(name, faculty.Value, cathedra.Value, course.Value, data.Value));
                    }
                }
                return Result;
            }
            public Document CreateFile(People p)
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

                    if (search(name, p.name, ActiveParametrs.nameActive) && search(faculty.Value, p.faculty, ActiveParametrs.facultyActive)
                        && search(cathedra.Value, p.cathedra, ActiveParametrs.cathedraActive) && search(course.Value, p.course, ActiveParametrs.courseActive)
                        && search(data.Value, p.data, ActiveParametrs.dataActive))
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
                Document doc = new Document();
                doc.XDoc = Result;
                return doc;
            }
            bool search(string parametr1, string parametr2, bool Active)
            {
                if (Active == false) return true;
                return parametr1 == parametr2;
            }
        }
        class domStrategy : IStrategy
        {
            public List<People> search(People people)
            {
                List<People> result = new List<People>();
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\Users\Веталь\Desktop\С#\Paterns\File.xml");
                XmlNode node = doc.DocumentElement;
                foreach (XmlNode nod in node.ChildNodes)
                {
                    string name="";
                    string faculty="";
                    string cathedra="";
                    string course="";
                    string data="";
                    string firstname = "";
                    string secondname = "";
                    string patronymic = "";
                   

                    foreach (XmlAttribute attribute in nod.Attributes)
                    {
                        if (attribute.Name.Equals("firstname"))
                        {
                            firstname += attribute.Value;
                        }
                        if (attribute.Name.Equals("secondname"))
                        {
                            secondname += attribute.Value;
                        }
                        if (attribute.Name.Equals("patronymic"))
                        {
                            patronymic += attribute.Value;
                        }
                    }
                    name = secondname + " " + firstname + " " + patronymic;
                    foreach (XmlNode Node in nod.ChildNodes)
                    {
                        if (Node.Name.Equals("faculty"))
                        {
                            faculty += Node.InnerText;
                        }
                        if (Node.Name.Equals("cathedra"))
                        {
                            cathedra += Node.InnerText;
                        }
                        if (Node.Name.Equals("course"))
                        {
                            course += Node.InnerText;
                        }
                        if (Node.Name.Equals("data"))
                        {
                            data += Node.InnerText;
                        }
                    }
                    if (search(people.name, name, ActiveParametrs.nameActive) && search(people.data, data, ActiveParametrs.dataActive) && search(people.cathedra, cathedra, ActiveParametrs.cathedraActive)
                     && search(people.course, course, ActiveParametrs.courseActive) && search(people.faculty, faculty, ActiveParametrs.facultyActive))
                    {
                        result.Add(new People(name, faculty, cathedra, course, data));
                    }
                }
                return result;
            }
            public Document CreateFile(People people)
            { 
                XmlDocument doc = new XmlDocument();
                XmlDocument result = new XmlDocument();
                doc.Load(@"C:\Users\Веталь\Desktop\С#\Paterns\File.xml");
                XmlNode node = doc.DocumentElement;
                result.AppendChild(result.CreateXmlDeclaration("1.0", "utf-8", null));
                XmlElement hotel = result.CreateElement("hotel");

                foreach (XmlNode nod in node.ChildNodes)
                {
                    string name = "";
                    string faculty = "";
                    string cathedra = "";
                    string course = "";
                    string data = "";
                    string firstname = "";
                    string secondname = "";
                    string patronymic = "";
                    

                    foreach (XmlAttribute attribute in nod.Attributes)
                    {
                        if (attribute.Name.Equals("firstname"))
                        {
                            firstname += attribute.Value;
                        }
                        if (attribute.Name.Equals("secondname"))
                        {
                            secondname += attribute.Value;
                        }
                        if (attribute.Name.Equals("patronymic"))
                        {
                            patronymic += attribute.Value;
                        }
                    }
                    name = secondname + " " + firstname + " " + patronymic;
                    foreach (XmlNode Node in nod.ChildNodes)
                    {
                        if (Node.Name.Equals("faculty"))
                        {
                            faculty += Node.InnerText;
                        }
                        if (Node.Name.Equals("cathedra"))
                        {
                            cathedra += Node.InnerText;
                        }
                        if (Node.Name.Equals("course"))
                        {
                            course += Node.InnerText;
                        }
                        if (Node.Name.Equals("data"))
                        {
                            data += Node.InnerText;
                        }
                    }
                    if (search(people.name, name, ActiveParametrs.nameActive) && search(people.data, data, ActiveParametrs.dataActive) && search(people.cathedra, cathedra, ActiveParametrs.cathedraActive)
                     && search(people.course, course, ActiveParametrs.courseActive) && search(people.faculty, faculty, ActiveParametrs.facultyActive))
                    {

                    
                        
                            XmlElement facultyX = result.CreateElement("faculty");
                            XmlElement cathedraX = result.CreateElement("cathedra");
                            XmlElement dataX = result.CreateElement("data");
                            XmlElement peopleX = result.CreateElement("people");
                            XmlElement courseX = result.CreateElement("course");
                            XmlAttribute firstnameX = result.CreateAttribute("firstname");
                            XmlAttribute secondnameX = result.CreateAttribute("secondname");
                            XmlAttribute patronymicX = result.CreateAttribute("patronymic");
                            firstnameX.Value = firstname;
                            secondnameX.Value = secondname;
                            patronymicX.Value = patronymic;
                            peopleX.Attributes.Append(firstnameX);
                            peopleX.Attributes.Append(secondnameX);
                            peopleX.Attributes.Append(patronymicX);
                            dataX.InnerText = data;
                            cathedraX.InnerText = cathedra;
                            courseX.InnerText = course;
                            facultyX.InnerText = faculty;
                            peopleX.AppendChild(facultyX);
                            peopleX.AppendChild(cathedraX);
                            peopleX.AppendChild(courseX);
                            peopleX.AppendChild(dataX);
                            hotel.AppendChild(peopleX);

                        
                    }

                }
                result.AppendChild(hotel);
                Document resultDoc = new Document();
                resultDoc.doc = result;
                return resultDoc;
            }
            bool search(string parametr1, string parametr2, bool Active)
            {
                if (Active == false) return true;
                return parametr1 == parametr2;
            }
        }
        class saxStrategy : IStrategy
        {
            public List<People> search(People people)
            {
                List<People> result = new List<People>();
                var xmlReader = new XmlTextReader("C:\\Users\\Веталь\\Desktop\\С#\\Paterns\\File.xml");
                    string name = "";
                    string firstname = "";
                    string secondname = "";
                    string patronymic = "";
                    string date = "";
                    string course = "";
                    string cathedra = "";
                    string faculty = "";
                while (xmlReader.Read())
                {
                   
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (xmlReader.Name.Equals("faculty"))
                            {
                                xmlReader.Read();
                                faculty = xmlReader.Value;
                                break;
                            }
                            if (xmlReader.Name.Equals("data"))
                            {
                                xmlReader.Read();
                                date = xmlReader.Value;
                                break;
                            }
                            if (xmlReader.Name.Equals("cathedra"))
                            {
                                xmlReader.Read();
                                cathedra = xmlReader.Value;
                                break;
                            }
                            if (xmlReader.Name.Equals("course"))
                            {
                                xmlReader.Read();
                                course = xmlReader.Value;
                                break;
                            }
                            break;
                        case XmlNodeType.EndElement:
                            if (xmlReader.Name.Equals("people"))
                            {

                                name = secondname + " " + firstname + " " + patronymic;
                                if (search(people.name, name, ActiveParametrs.nameActive) && search(people.data, date, ActiveParametrs.dataActive) && search(people.cathedra, cathedra, ActiveParametrs.cathedraActive)
                    && search(people.course, course, ActiveParametrs.courseActive) && search(people.faculty, faculty, ActiveParametrs.facultyActive))
                                {
                                    result.Add(new People(name, faculty, cathedra, course, date));
                                }
                            }
                            break;
                    }
                    if (xmlReader.HasAttributes)
                    {
                            
                        while (xmlReader.MoveToNextAttribute())
                        {
                            
                            if (xmlReader.Name.Equals("firstname"))
                            {
                                firstname = xmlReader.Value;
                            }
                            if (xmlReader.Name.Equals("secondname"))
                            {
                                secondname = xmlReader.Value;
                            }
                            if (xmlReader.Name.Equals("patronymic"))
                            {
                                patronymic = xmlReader.Value;
                            }
                        }
                    }
                }
                return result;
            }
            public Document CreateFile(People p)
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

                    if (search(name, p.name, ActiveParametrs.nameActive) && search(faculty.Value, p.faculty, ActiveParametrs.facultyActive)
                        && search(cathedra.Value, p.cathedra, ActiveParametrs.cathedraActive) && search(course.Value, p.course, ActiveParametrs.courseActive)
                        && search(data.Value, p.data, ActiveParametrs.dataActive))
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
                Document doc = new Document();
                doc.XDoc = Result;
                return doc;
            }
            bool search(string parametr1, string parametr2, bool Active)
            {
                if (Active == false) return true;
                return parametr1 == parametr2;
            }
        }
        Context context = new Context();
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
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
            context.TransformFile(new People(nameBox.Text, facultyBox.Text, cathedraBox.Text, courseBox.Text, dataBox.Text));
            richTextBox1.Text = " ";
            richTextBox1.Text = context.SearchResult(new People(nameBox.Text, facultyBox.Text, cathedraBox.Text, courseBox.Text, dataBox.Text));
        }
        private void radioButtonLINQ_CheckedChanged(object sender, EventArgs e)
        {
            linqStrategy linq = new linqStrategy();
            context = new Context(linq); 
        }

        private void radioButtonSAX_CheckedChanged(object sender, EventArgs e)
        {
            saxStrategy SAX = new saxStrategy();
            context = new Context(SAX);
        }

        private void radioButtonDOM_CheckedChanged(object sender, EventArgs e)
        {
            domStrategy DOM = new domStrategy();
            context = new Context(DOM);
        }
    }
}
