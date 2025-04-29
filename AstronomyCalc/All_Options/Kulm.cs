namespace MyWinFormsApp;
public partial class Kulm : Form
{
    private System.ComponentModel.IContainer components = null;
    double phi,delt;
    TextBox take_phi,take_delt;
    Label writeans;
    Label bad_values = new Label(){
        Text="Некоректно введены значения:\n широта от -90 до +90, склонение от -90 до +90!",
        Font = new Font("Arial",10),
        AutoSize = true,
        Location = new Point(300,200)
    };
    Button to_count;
    Label not_double=new Label(){
        Text="Введенные значения должны быть рациональными числами:\nот -90 до +90 с запятой!",
        Font = new Font("Arial",10),
        AutoSize = true,
        Location = new Point(300,200)
    };
    public Tuple<double,double> count_kulm(){
        return new (Math.Round(90-Math.Abs(phi-delt),2),Math.Round(Math.Abs(phi+delt)-90,2));
    }
    public Kulm()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Text = "AstronomyCalc";
        Label title = new Label(){
            Text="Верхняя и нижняя кульминации",
            Font=new Font("Arial",12),
            AutoSize=true,
            Location = new Point(300,20)
        };
        Button go_to_menu=new Button(){
            Text="Назад",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location=new Point(10,10)
        };
        go_to_menu.Click+=ButtonClick_back;
        take_phi=new TextBox(){
            Size=new Size(100,20),
            Location=new Point(100,100)
        };
        Label lphi=new Label(){
            Text="Широта (φ)",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(100,take_phi.Location.Y-20)
        };
        Label merphi=new Label(){
            Text="°",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(take_phi.Location.X+take_phi.Size.Width+5,take_phi.Location.Y+5)
        };
        take_delt=new TextBox(){
            Size=new Size(100,20),
            Location=new Point(100,200),
        };
        Label ldelt=new Label(){
            Text="Склонение (δ)",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(100,take_delt.Location.Y-20)
        };
        Label merdelt=new Label(){
            Text="°",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(take_delt.Location.X+take_delt.Size.Width+5,take_delt.Location.Y+5)
        };
        to_count=new Button(){
            Text="Посчитать",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location=new Point(300,150)
        };
        to_count.Click+=button_count;
        Controls.Add(merdelt);
        Controls.Add(merphi);
        Controls.Add(ldelt);
        Controls.Add(lphi);
        Controls.Add(to_count);
        Controls.Add(take_delt);
        Controls.Add(take_phi);
        Controls.Add(go_to_menu);
        Controls.Add(title);
    }
    private void ButtonClick_back(object sender,EventArgs args){
        this.Hide();
        MenuForm menu=new MenuForm();
        menu.ShowDialog();
    }
    private void button_count(object sender,EventArgs args){
        Controls.Remove(writeans);
        Controls.Remove(bad_values);
        Controls.Remove(not_double);
        string txtphi=take_phi.Text;
        string txtdelt=take_delt.Text;
        if(!MenuForm.check_if_double(txtphi)||!MenuForm.check_if_double(txtdelt)){
            Controls.Add(not_double);
            return;
        }
        phi=double.Parse(txtphi);
        delt=double.Parse(txtdelt);
        if(phi>90 ||phi<-90||delt>90||delt<-90){
            Controls.Add(bad_values);
            return;
        }
        Tuple<double,double> ans=count_kulm();
        writeans=new Label(){
            Text="Верхняя кульминация: "+ans.Item1+"°\nНижняя кульминация: "+ans.Item2+"°",
            AutoSize=true,
            Location=new Point(300,to_count.Location.Y+50),
            Font=new Font("Arial",10)
        };
        Controls.Add(writeans);
    }
}