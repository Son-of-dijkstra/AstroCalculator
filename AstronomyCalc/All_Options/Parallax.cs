namespace MyWinFormsApp;
public partial class Prlx : Form{
    private System.ComponentModel.IContainer components = null;
    TextBox txtprlx,txtdist;
    double Parall,Dist;
    Label no1=new Label(){
            Text="Вы ввели слишком много\nили слишком мало значений!",
            AutoSize=true,
            Font=new Font("Arial",10)
    };
    Label grnull=new Label(){
        Text="Введенные значения должны быть больше нуля!",
        AutoSize=true,
        Font=new Font("Arial",10)
    };
    Label not_double=new Label(){
        Text="Введенные значения должны быть\nрациональными числами с запятой!",
        AutoSize=true,
        Font=new Font("Arial",10)
    };
    Label writeans;
    Button to_count;
    public Prlx()
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
            Text="Параллакс и расстояние",
            Font=new Font("Arial",12),
            AutoSize=true,
            Location = new Point(300,20)
        };
        Label instruction=new Label(){
            Text="Введите одно значение, получите второе",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location = new Point(230,50)
        };
        Button go_to_menu=new Button(){
            Text="Назад",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location=new Point(10,10)
        };
        go_to_menu.Click+=ButtonClick_back;
         to_count=new Button(){
            Text="Посчитать",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location=new Point(400,250)
        };
        txtprlx=new TextBox(){
            Size=new Size(150,20),
            Location=new Point(100,150)
        };
        Label lprlx=new Label(){
            Text="Годичный параллакс (p)",
            Font=new Font("Arial",10),
            AutoSize=true,            
            Location=new Point(100,txtprlx.Location.Y-20)
        };
        txtdist=new TextBox(){
            Size=new Size(150,20),
            Location=new Point(100,250)
        };
        Label ldist=new Label(){
            Text= "Расстояние (D)",
            Font=new Font("Arial",10),
            AutoSize=true,            
            Location=new Point(100,txtdist.Location.Y-20)
        };
        Label merprlx=new Label(){
            Text="''",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(txtprlx.Location.X+txtprlx.Size.Width+5,txtprlx.Location.Y+5)
        };
        Label merdist=new Label(){
            Text="пк",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(txtdist.Location.X+txtdist.Size.Width+5,txtdist.Location.Y+5)
        };
        no1.Location=new Point(to_count.Location.X,to_count.Location.Y+50);
        grnull.Location=new Point(to_count.Location.X,to_count.Location.Y+50);
        not_double.Location=new Point(to_count.Location.X,to_count.Location.Y+50);
        to_count.Click+=button_count;
        Controls.Add(merprlx);
        Controls.Add(merdist);
        Controls.Add(lprlx);
        Controls.Add(ldist);
        Controls.Add(to_count);
        Controls.Add(txtprlx);
        Controls.Add(txtdist);
        Controls.Add(go_to_menu);
        Controls.Add(title);
        Controls.Add(instruction);
    }
    private void ButtonClick_back(object sender,EventArgs args){
        this.Hide();
        MenuForm menu=new MenuForm();
        menu.ShowDialog();
    }
    private void button_count(object sender,EventArgs args){
        Controls.Remove(no1);
        Controls.Remove(writeans);
        Controls.Remove(grnull);
        Controls.Remove(not_double);
        string sP=txtprlx.Text;
        string sD=txtdist.Text;
        int cntem=0;
        if(sP.Length==0){
            cntem++;
        }
        else{
            if(!MenuForm.check_if_double(sP)){
                Controls.Add(not_double);
                return;
            }
        }
        if(sD.Length==0){
            cntem++;
        }
        else{
            if(!MenuForm.check_if_double(sD)){
                Controls.Add(not_double);
                return;
            }
        }
        if(cntem!=1){
            Controls.Add(no1);
            return;
        }
        if(sP.Length==0){
            Dist=double.Parse(sD);
            if(Dist<=0){
                Controls.Add(grnull);
                return;
            }
            Parall=1.0/Dist;
            writeans=new Label(){
                Text="Годичный параллакс: "+Math.Round(Parall,4)+"''",
                AutoSize=true,
                Location=new Point(to_count.Location.X,to_count.Location.Y+50),
                Font=new Font("Arial",10)
            };
            Controls.Add(writeans);
            return;
        }
        if(sD.Length==0){
            Parall=double.Parse(sP);
            if(Parall<=0){
                Controls.Add(grnull);
                return;
            }
            Dist=1.0/Parall;
            writeans=new Label(){
                Text="Расстояние: "+Math.Round(Dist,4)+" пк",
                AutoSize=true,
                Location=new Point(to_count.Location.X,to_count.Location.Y+50),
                Font=new Font("Arial",10)
            };
            Controls.Add(writeans);
            return;
        }
    }
}