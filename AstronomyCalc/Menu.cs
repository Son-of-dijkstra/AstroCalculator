namespace MyWinFormsApp;

public partial class MenuForm : Form
{
    public MenuForm()
    {
        InitializeComponent();
    }
    private void btn_back(object sender,EventArgs args)
    {
        this.Hide();
        Form1 back_to_greet=new Form1();
        back_to_greet.ShowDialog();
    }
    private void btn_culm(object sender,EventArgs args)
    {
        this.Hide();
        Kulm go_to_culm=new Kulm();
        go_to_culm.ShowDialog();
    }
    private void btn_kepler3(object sender,EventArgs args)
    {
        this.Hide();
        Kepler3 go_to_kepler3=new Kepler3();
        go_to_kepler3.ShowDialog();
    }
    private void btn_boltsman(object sender,EventArgs args)
    {
        this.Hide();
        Boltsman go_to_boltsman=new Boltsman();
        go_to_boltsman.ShowDialog();
    }
    private void btn_parallax(object sender,EventArgs args)
    {
        this.Hide();
        Prlx go_to_parallax=new Prlx();
        go_to_parallax.ShowDialog();
    }
    static public bool check_if_double(string s){
        bool ok=true;
        int cntnum=0;
        for (int i = 0; i < s.Length; i++){
            if((s[i]>'9'||s[i]<'0')&&s[i]!=','&&s[i]!='-'&&s[i]!='+'){
                ok=false;
                break;
            }
            if(s[i]>='0'&&s[i]<='9'){
                cntnum++;
            }
        }
        if(!ok||cntnum==0){
            return false;
        }
        int cntdt=0,cntmn=0,cntpl=0;
        for (int i = 0; i < s.Length; i++)
        {
            if(s[i]==','){
                cntdt++;
            }
            if(s[i]=='-'){
                cntmn++;
            }
            if(s[i]=='+'){
                cntpl++;
            }
        }
        if(cntdt>=2||(cntmn+cntpl>=2)){
            return false;
        }
        if(cntmn==1&&s[0]!='-'){
            return false;
        }
        if(cntpl==1&&s[0]!='+'){
            return false;
        }
        return ok;
    }
}