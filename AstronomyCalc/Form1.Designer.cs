namespace MyWinFormsApp;

partial class Form1
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
        Button start=new Button();
        start.Text="START";
        start.Location=new Point(400,225);
        start.Size=new Size(100,50);
        start.DialogResult=DialogResult.OK;
        Label Greetings=new Label(){
            Text ="Welcome to the AstronomyCalc!",
            Location =new Point(300,10),
            Size=new Size(300,30),
            TabIndex=10,
            Font=new Font("Arial",12)
        };
        start.Location=new Point(Greetings.Location.X + Greetings.Size.Width/2-start.Size.Width/2,Greetings.Bounds.Bottom+Padding.Top+20);
        Label creator=new Label(){
            Text="Created by Khakim Khamitov",
            Size=new Size(230,20),
            Location=new Point(10,ClientSize.Height-25)
        };
        start.Click+=OpenButton_Click;
        Controls.Add(Greetings);
        Controls.Add(start);
        Controls.Add(creator);
    }
    #endregion
}
