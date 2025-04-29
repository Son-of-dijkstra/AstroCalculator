namespace MyWinFormsApp;
public partial class Kepler3 : Form
{
    private System.ComponentModel.IContainer components = null;
    TextBox txtPeriod,txtBigA,txtMass;
    double Period,BigA,Mass;//period-Years, BigA-a.e., Mass-Msun
    double Gr=6.67430*Math.Pow(10.0,-11);
    double oneAE=149597870700;
    double Msun=1.98892 * Math.Pow(10.0,30);
    double SecinYear=3600*24*365.2422;
    Label no2=new Label(){
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
    public Kepler3()
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
            Text="III закон Кеплера",
            Font=new Font("Arial",12),
            AutoSize=true,
            Location = new Point(300,20)
        };
        Label instruction=new Label(){
            Text="Введите два значения, получите третье",
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
        txtPeriod=new TextBox(){
            Size=new Size(150,20),
            Location=new Point(100,150)
        };
        Label lper=new Label(){
            Text="Период системы (T)",
            Font=new Font("Arial",10),
            AutoSize=true,            
            Location=new Point(100,txtPeriod.Location.Y-20)
        };
        txtBigA=new TextBox(){
            Size=new Size(150,20),
            Location=new Point(100,250)
        };
        Label lBigA=new Label(){
            Text="Большая полуось системы (a)",
            Font=new Font("Arial",10),
            AutoSize=true,            
            Location=new Point(100,txtBigA.Location.Y-20)
        };
        txtMass=new TextBox(){
            Size=new Size(150,20),
            Location=new Point(100,350)
        };
        Label lMass=new Label(){
            Text="Масса системы (M)",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(100,txtMass.Location.Y-20)
        };
        Label merPer=new Label(){
            Text="лет",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(txtPeriod.Location.X+txtPeriod.Size.Width+5,txtPeriod.Location.Y+5)
        };
        Label merBigA=new Label(){
            Text="a.e.",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(txtBigA.Location.X+txtBigA.Size.Width+5,txtBigA.Location.Y+5)
        };
        Label merMass=new Label(){
            Text="M⊙",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(txtMass.Location.X+txtMass.Size.Width+5,txtMass.Location.Y+5)
        };
        no2.Location=new Point(to_count.Location.X,to_count.Location.Y+50);
        grnull.Location=new Point(to_count.Location.X,to_count.Location.Y+50);
        not_double.Location=new Point(to_count.Location.X,to_count.Location.Y+50);
        to_count.Click+=button_count;
        Controls.Add(merPer);
        Controls.Add(merBigA);
        Controls.Add(merMass);
        Controls.Add(lper);
        Controls.Add(lBigA);
        Controls.Add(lMass);
        Controls.Add(to_count);
        Controls.Add(txtPeriod);
        Controls.Add(txtBigA);
        Controls.Add(txtMass);
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
        Controls.Remove(no2);
        Controls.Remove(writeans);
        Controls.Remove(grnull);
        Controls.Remove(not_double);
        string sP=txtPeriod.Text;
        string sA=txtBigA.Text;
        string sM=txtMass.Text;
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
        if(sA.Length==0){
            cntem++;
        }
        else{
            if(!MenuForm.check_if_double(sA)){
                Controls.Add(not_double);
                return;
            }
        }
        if(sM.Length==0){
            cntem++;
        }
        else{
            if(!MenuForm.check_if_double(sM)){
                Controls.Add(not_double);
                return;
            }
        }
        if(cntem!=1){
            Controls.Add(no2);
            return;
        }
        if(sP.Length==0){
            BigA=double.Parse(sA);
            Mass=double.Parse(sM);
            if(BigA<=0||Mass<=0){
                Controls.Add(grnull);
                return;
            }
            Period=4*Math.PI*Math.PI/Gr;
            Period*=Math.Pow((BigA*oneAE),3);
            Period/=(Mass*Msun);
            Period=Math.Sqrt(Period);
            Period/=SecinYear;
            writeans=new Label(){
                Text="Период cистемы: "+Math.Round(Period,4)+" лет",
                AutoSize=true,
                Location=new Point(to_count.Location.X,to_count.Location.Y+50),
                Font=new Font("Arial",10)
            };
            Controls.Add(writeans);
            return;
        }
        if(sA.Length==0){
            Period=double.Parse(sP);
            Mass=double.Parse(sM);
            if(Period<=0||Mass<=0){
                Controls.Add(grnull);
                return;
            }
            BigA=Gr/(4*Math.PI*Math.PI);
            BigA*=(Mass*Msun);
            BigA*=Math.Pow(Period*SecinYear,2);
            BigA=Math.Cbrt(BigA);
            BigA/=oneAE;
            writeans=new Label(){
                Text="Большая полуось системы: "+Math.Round(BigA,4)+" a.e.",
                AutoSize=true,
                Location=new Point(to_count.Location.X,to_count.Location.Y+50),
                Font=new Font("Arial",10)
            };
            Controls.Add(writeans);
            return;
        }
        if(sM.Length==0){
            Period=double.Parse(sP);
            BigA=double.Parse(sA);
            if(BigA<=0||Period<=0){
                Controls.Add(grnull);
                return;
            }
            Mass=4*Math.PI*Math.PI/Gr;
            Mass*=Math.Pow(BigA*oneAE,3);
            Mass/=Math.Pow(Period*SecinYear,2);
            Mass/=Msun;
            writeans=new Label(){
                Text="Масса системы: "+Math.Round(Mass,4)+" масс Солнца",
                AutoSize=true,
                Location=new Point(to_count.Location.X,to_count.Location.Y+50),
                Font=new Font("Arial",10)
            };
            Controls.Add(writeans);
            return;
        }
    }
}