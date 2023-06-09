namespace BattleShip.model
{
    public class Consola
    {
        private static Consola? instance;
        private TextBox textBox;

        private Consola(TextBox textBox)
        {
            this.textBox = textBox;
        }

        public static Consola GetInstance(TextBox textBox)
        {
            if (instance == null)
            {
                instance = new Consola(textBox);
            }
            return instance;
        }

        public void Write(string texto)
        {
            textBox.AppendText(texto);
        }

        public void WriteLine(string texto)
        {
            textBox.AppendText(texto + Environment.NewLine);
        }

        public void WriteLine()
        {
            WriteLine(string.Empty);
        }

        public void Clear()
        {
            textBox.Clear();
        }
    }
}
