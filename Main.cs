using dam_battleship.models;

namespace dam_battleship;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();

        var console = Consola.GetInstance(textBox1);
    }

    private void BtnExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void BtnBegin_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}