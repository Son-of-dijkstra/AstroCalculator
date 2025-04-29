namespace MyWinFormsApp;
public partial class Boltsman : Form
{
     private System.ComponentModel.IContainer components = null;
     TextBox txtTemp,txtRad,txtLum;
     double Temp,Rad,Lum,StBL=5.67036713*Math.Pow(10.0,-8);
     double Lsun=3.827*Math.Pow(10,26);
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
    Button to_count;
    Label writeans;
    public Boltsman(){
        InitializeComponent();
    }
    public void InitializeComponent(){
        components = new System.ComponentModel.Container();
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Text = "AstronomyCalc";
        Label title = new Label(){
            Text="Температура - Радиус - Светимость",
            Font=new Font("Arial",12),
            AutoSize=true,
            Location = new Point(300,20)
        };
        Label instruction=new Label(){
            Text="Введите два значения, получите третье",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location = new Point(300,50)
        };
        Button go_to_menu=new Button(){
            Text="Назад",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location=new Point(10,10)
        };
        go_to_menu.Click+=ButtonClick_back;
        txtTemp=new TextBox(){
            Size=new Size(100,20),
            Location=new Point(100,150)
        };
        txtRad=new TextBox(){
            Size=new Size(100,20),
            Location=new Point(100,250)
        };
        txtLum=new TextBox(){
            Size=new Size(100,20),
            Location=new Point(100,350)
        };
        Label lTemp=new Label(){
            Text="Температура (Т)",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location=new Point(100,txtTemp.Location.Y-20)
        };
        Label lRad=new Label(){
            Text="Радиус (R)",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location=new Point(100,txtRad.Location.Y-20)
        };
        Label lLum=new Label(){
            Text="Светимость (L)",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location=new Point(100,txtLum.Location.Y-20)
        };
        Label merTemp=new Label(){
            Text="K",
            AutoSize=true,
            Font=new Font("Arial", 10),
            Location=new Point(txtTemp.Location.X+txtTemp.Size.Width+5, txtTemp.Location.Y+5)
        };
        Label merRad=new Label(){
            Text="km",
            AutoSize=true,
            Font=new Font("Arial", 10),
            Location=new Point(txtRad.Location.X+txtRad.Size.Width+5, txtRad.Location.Y+5)
        };
        Label merLum=new Label(){
            Text="L⊙",
            AutoSize=true,
            Font=new Font("Arial", 10),
            Location=new Point(txtLum.Location.X+txtLum.Size.Width+5, txtLum.Location.Y+5)
        };
        to_count=new Button(){
            Text="Посчитать",
            Font=new Font("Arial",10),
            AutoSize=true,
            Location=new Point(400,250)
        };
        no2.Location=new Point(to_count.Location.X,to_count.Location.Y+50);
        grnull.Location=new Point(to_count.Location.X,to_count.Location.Y+50);
        not_double.Location=new Point(to_count.Location.X,to_count.Location.Y+50);
        to_count.Click+=button_count;
        Controls.Add(to_count);
        Controls.Add(instruction);
        Controls.Add(merTemp);
        Controls.Add(merRad);
        Controls.Add(merLum);
        Controls.Add(lLum);
        Controls.Add(lRad);
        Controls.Add(lTemp);
        Controls.Add(go_to_menu);
        Controls.Add(txtTemp);
        Controls.Add(txtRad);
        Controls.Add(txtLum);
        Controls.Add(title);
     }
     private void ButtonClick_back(object sender,EventArgs args){
        this.Hide();
        MenuForm menu=new MenuForm();
        menu.ShowDialog();
    }
    private void button_count(object sender,EventArgs args){
        Controls.Remove(no2);
        Controls.Remove(grnull);
        Controls.Remove(not_double);
        Controls.Remove(writeans);
        string sR=txtRad.Text,sT=txtTemp.Text,sL=txtLum.Text;
        int cntem=0;
        if(sR.Length==0){
            cntem++;
        }
        else{
            if(!MenuForm.check_if_double(sR)){
                Controls.Add(not_double);
                return;
            }
        }
        if(sT.Length==0){
            cntem++;
        }
        else{
            if(!MenuForm.check_if_double(sT)){
                Controls.Add(not_double);
                return;
            }
        }
        if(sL.Length==0){
            cntem++;
        }
        else{
            if(!MenuForm.check_if_double(sL)){
                Controls.Add(not_double);
                return;
            }
        }
        if(cntem!=1){
            Controls.Add(no2);
            return;
        }
        if(sR.Length==0){
            Temp=double.Parse(sT);
            Lum=double.Parse(sL);
            if(Temp<=0||Lum<=0){
                Controls.Add(grnull);
                return;
            }
            Rad=Lum*Lsun/(4*Math.PI*StBL*Math.Pow(Temp,4));
            Rad=Math.Sqrt(Rad)/1000;
            writeans=new Label(){
                Text="Радиус cветила: "+Math.Round(Rad)+" км",
                AutoSize=true,
                Location=new Point(to_count.Location.X,to_count.Location.Y+50),
                Font=new Font("Arial",10)
            };
            Controls.Add(writeans);
            return;
        }
        if(sT.Length==0){
            Rad=double.Parse(sR);
            Lum=double.Parse(sL);
            if(Rad<=0||Lum<=0){
                Controls.Add(grnull);
                return;
            }
            Temp=Lum*Lsun/(4*Math.PI*Math.Pow(Rad*1000,2)*StBL);
            Temp=Math.Sqrt(Math.Sqrt(Temp));
            writeans=new Label(){
                Text="Температура светила: "+Math.Round(Temp)+" К",
                AutoSize=true,
                Location=new Point(to_count.Location.X,to_count.Location.Y+50),
                Font=new Font("Arial",10)
            };
            Controls.Add(writeans);
            return;
        }
        if(sL.Length==0){
            Rad=double.Parse(sR);
            Temp=double.Parse(sT);
            if(Rad<=0||Temp<=0){
                Controls.Add(grnull);
                return;
            }
            Lum=4*Math.PI*StBL*Math.Pow(Rad*1000,2)*Math.Pow(Temp,4);
            Lum/=Lsun;
            writeans=new Label(){
                Text="Светимость светила: "+Math.Round(Lum,4)+" L⊙",
                AutoSize=true,
                Location=new Point(to_count.Location.X,to_count.Location.Y+50),
                Font=new Font("Arial",10)
            };
            Controls.Add(writeans);
            return;
        }
    }
}