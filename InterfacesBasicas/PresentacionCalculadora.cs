using System;
using System.Windows.Forms;
namespace InterfacesBasicas
{
    public partial class PresentacionCalculadora : Form
    {
        //Atributo de tipo LogicaCalculadora para acceder desde la instancia de la clase a sus propiedades.
        private LogicaCalculadora logicaCalculadora;
        public PresentacionCalculadora()
        {
            InitializeComponent();
            //Se crea una nueva instancia, un objeto, y se le pasa el atributo anterior, para acceder.
            logicaCalculadora = new LogicaCalculadora();
        }
        private void PresentacionCalculadora_Load(object sender, EventArgs e)
        {
            //Aca va lo que se dispara cuando se abre el formulario x primera vez.
            //Text es la propiedad que contiene el texto.
            txtResultado.Text = "0";
            txtNum1.Text = "0";
            txtNum2.Text = "0";
        }
        private void btnSumar_Click(object sender, EventArgs e)
        {
            //Se crean las variables y se parsean de texto a double
            double num1 = double.Parse(txtNum1.Text);
            double num2 = double.Parse(txtNum2.Text);
            //Se utiliza el objeto logicaCalculadora para utilizar el metodo de esa clase y mandarle los datos necesarios como parametros.
            double resultado = logicaCalculadora.SumarNumeros(num1, num2);
            //El resultado es de tipo double tonces, con el metodo ToString lo cambia a texto para cargarlo en el campo de texto.
            txtResultado.Text = resultado.ToString();
        }
        private void btnRestar_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(txtNum1.Text);
            double num2 = double.Parse(txtNum2.Text);
            double resultado = logicaCalculadora.RestarNumeros(num1, num2);
            txtResultado.Text = resultado.ToString();
        }
        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(txtNum1.Text);
            double num2 = double.Parse(txtNum2.Text);
            double resultado = logicaCalculadora.MultiplicarNumeros(num1, num2);
            txtResultado.Text = resultado.ToString();
        }
        private void btnDividir_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(txtNum1.Text);
            double num2 = double.Parse(txtNum2.Text);
            if ( num2 == 0 ) { MessageBox.Show("No se divide entre 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { double resultado = logicaCalculadora.DividirNumeros(num1, num2); txtResultado.Text = resultado.ToString();}
        }
    }
}
