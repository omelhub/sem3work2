using BusinessLogic;
using Model2;
using WinFormsView;
namespace WinFormsView;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        logic = new Logic();

        //�������� ������ ���������
        //logic.AddStudent("������", "�����������", "��21-18�");
        //logic.AddStudent("������", "�����������", "��21-21�");
        //logic.AddStudent("�������", "�����������", "��21-21�");
        //logic.AddStudent("�������", "�����������", "��21-21�");
        //logic.AddStudent("�������", "��������", "��21-01�");
        //logic.AddStudent("���������", "��������", "��21-02�");
    }

    public Logic logic;

    private void Form1_Load(object sender, EventArgs e)
    {
        RefreshListView();
    }

    public void RefreshListView()
    {
        listView1.Clear();

        listView1.View = View.Details;

        listView1.Columns.Add("���", 240);
        listView1.Columns.Add("C������������", 190);
        listView1.Columns.Add("������", 125);


        for (int i = 0; i < logic.GetAll().Count; i++)
        {
            ListViewItem newitem = new ListViewItem(logic.GetAll().ElementAt(i).Name);
            newitem.SubItems.Add(Convert.ToString(logic.GetAll().ElementAt(i).Speciality));
            newitem.SubItems.Add(Convert.ToString(logic.GetAll().ElementAt(i).Group));

            listView1.Items.Add(newitem);
        }
    }

    public void RefreshGraph()
    {
        if (Application.OpenForms.OfType<Form2>().Count() == 1)
        {
            Application.OpenForms.OfType<Form2>().First().Close();

            Form2 newForm2 = new Form2(logic);

            newForm2.Show();
        }
    }

    #region ����������� �������

    private void buttonAdd_Click(object sender, EventArgs e)
    {
        logic.AddStudent(NameBox.Text, SpecialityBox.Text, GroupBox.Text);

        RefreshListView();
        RefreshGraph();
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedIndices.Count != 0)
        {
            //foreach(int index in listView1.SelectedIndices)
            //{
            //    logic.DeleteStudent(index)
            //} //���, ������� ����� ���� �� ������������, ���� �� ��� ������� multiselection

            logic.DeleteStudent(logic.GetAll().ElementAt(listView1.SelectedIndices[0]).Id);

            RefreshListView();
            RefreshGraph();
        }
    }

    private void buttonViewGraph_Click(object sender, EventArgs e)
    {
        if (Application.OpenForms.OfType<Form2>().Count() == 1)
        {
            Application.OpenForms.OfType<Form2>().First().Close();
        }

        Form2 newForm2 = new Form2(logic);

        newForm2.Show();
    }

    #endregion

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}