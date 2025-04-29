namespace MyWinFormsApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    private void OpenButton_Click(object sender, EventArgs e)
    {
        // Создаем и показываем новую форму
        this.Hide();
        MenuForm Menu = new MenuForm();
        Menu.ShowDialog(); // Для модального окна (блокирует родительское)
    }
}