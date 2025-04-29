using System.Numerics;

namespace MyWinFormsApp;

partial class MenuForm : Form
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Text = "AstronomyCalc";
        Label title=new Label(){
            Text="Каталог вычислений",
            Size=new Size(200,20),
            Location=new Point(300,10),
            Font=new Font("Arial",12)
        };
        Button bt_culm=new Button(){
            Text="Верхняя и нижняя кульминации",
            Size=new Size(300,30),
            Font=new Font("Arial",10),
            Location=new Point(50,100)
        };
        Button bt_Kepler3=new Button(){
            Text="Третий закон Кеплера",
            Size=new Size(300,30),
            Font=new Font("Arial",10),
            Location=new Point(50,150)
        };
        Button bt_Bolts=new Button(){
            Text="Расчет светимости звезд",
            Size=new Size(300,30),
            Font=new Font("Arial",10),
            Location=new Point(50,200)
        };
        Button bt_Parallax=new Button(){
            Text="Годичный параллакс",
            Size=new Size(300,30),
            Font=new Font("Arial",10),
            Location=new Point(50,250)
        };
        Button go_to_greet=new Button(){
            Text="Назад",
            AutoSize=true,
            Font=new Font("Arial",10),
            Location=new Point(10,10)
        };
        go_to_greet.Click+=btn_back;
        bt_culm.Click+=btn_culm;
        bt_Bolts.Click+=btn_boltsman;
        bt_Kepler3.Click+=btn_kepler3;
        bt_Parallax.Click+=btn_parallax;
        Controls.Add(go_to_greet);
        Controls.Add(bt_culm);
        Controls.Add(bt_Parallax);
        Controls.Add(bt_Bolts);
        Controls.Add(bt_Kepler3);
        Controls.Add(title);
    }
    #endregion
}
