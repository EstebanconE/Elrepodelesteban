using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioInterfacesBasicas
{
    public partial class Programa : Form
    {
















        // Usuario
           public class Usuario
        {
            // Esta clase es parte de la capa logica, como otras cosas, pero la dejamos aca para entender mejor, y los atributos publicos para q los pueda leer el datagriedview.
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Telefono { get; set; }
            public string Correo { get; set; }
            public string Calle { get; set; }
            public int Numero { get; set; }

            public Usuario(string nombre, string apellido, int telefono, string correo, string calle, int numero)
            {
                Nombre = nombre;
                Apellido = apellido;
                Telefono = telefono;
                Correo = correo;
                Calle = calle;
                Numero = numero;
            }
        }
























        // Atributos

        private string nombre;
        private string apellido;
        private int telefono;
        private string correo;
        private string calle;
        private int numero;

        // Creamos una objeto de tipo lista y esa lista de tipo Usuario, para ir agregando los usuarios, como privado para que solo se pueda acceder desde esta clase.
        private List<Usuario> usuarios = new List<Usuario>();
        
        // Para mover la ventana.
        int X = 0, Y = 0;















        // Constructor del formulario.
        public Programa()
        {
            InitializeComponent();
            // Inicia la ventana en el centro.
            this.StartPosition = FormStartPosition.CenterScreen;
            // Definir las columnas del DataGridView
            dgvUsuarios.Columns.Add("Nombre", "Nombre");
            dgvUsuarios.Columns.Add("Apellido", "Apellido");
            dgvUsuarios.Columns.Add("Telefono", "Teléfono");
            dgvUsuarios.Columns.Add("Correo", "Correo");
            dgvUsuarios.Columns.Add("Calle", "Calle");
            dgvUsuarios.Columns.Add("Numero", "Número");
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }



















        // Cerrar la ventana mas facil.
        private void btnCerrar_Click(object sender, EventArgs e) => Application.Exit();



















        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Expresiones Regulares para controlar que los datos sean segun su patrón establecido.

            // Lo que hace el método IsMatch de la clase Regex es evaluar si una cadena coincide con el patrón especificado.
            // Si la coincidencia es positiva, devuelve True; si no, devuelve False.

            // En este caso, estamos negando el resultado del método. Cuando IsMatch devuelve true (lo que significa que los datos coinciden
            // con el patrón), negamos ese resultado utilizando el operador !, lo que nos da false, entonces la condicion se volvera falsa si los datos no coinciden.

            if (!Regex.IsMatch(txtCorreo.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("El formato del correo eléctronico no es valido.");
                return;
            }
            else if (!Regex.IsMatch(txtTelefono.Text, @"^\d{10}$"))
            {
                MessageBox.Show("El número de telefono debe tener 10 dígitos.");
                return;
            }
            else if (!Regex.IsMatch(txtNumero.Text, @"^\d+$"))
            {
                MessageBox.Show("El número de puerta debe ser un dato numérico.");
                return;
            } 
            // Con el operador OR  = ||, evalua que si solo un dato no cumple la condicion entonces ya esta todo mal.
            else if (!Regex.IsMatch(txtApellido.Text, @"^[a-zA-Z]+$") || !Regex.IsMatch(txtCalle.Text, @"^[a-zA-Z]+$") || !Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Nombre, apellido y calle deben contener solo letras.");
                return;
            } 
            // Si todo esta correcto entonces se realiza la inyeccion del usuario
            else
            {
               
                // Se llenan los atributos y se parsean los datos necesarios a su valor int, ya que las cajas de texto son siempre de tipo String.
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                telefono = int.Parse(txtTelefono.Text);
                correo = txtCorreo.Text;
                calle = txtCalle.Text;
                numero = int.Parse(txtNumero.Text);

                // Se crea el objeto usuario con sus atributos recibidos.
                Usuario usuarioNuevo = new Usuario(nombre, apellido, telefono, correo, calle, numero);

                //Agregarmos el usuario nuevo
                usuarios.Add(usuarioNuevo);
                // Agrega los datos al datagriedview mediante la propieadad Rows (columnas ).
                dgvUsuarios.Rows.Add(usuarioNuevo.Nombre, usuarioNuevo.Apellido, usuarioNuevo.Telefono, usuarioNuevo.Correo, usuarioNuevo.Calle, usuarioNuevo.Numero);

                // Actualiza la lista cada vez que se agrega un nuevo usuario.
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                txtCalle.Clear();
                txtNumero.Clear();

                dgvUsuarios.Refresh();
            }

        }




















        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Creamos una variable indice que con la propiedad SelectedRows va a tomar esa posicion que se selecciono del datagriedview que es la primera, y con el .Index va a tomar su indice.
                int indice = dgvUsuarios.SelectedRows[0].Index;

                // Creamos un objeto de tipo Usuario para mandarle a la lista usuarios esos datos nuevos.
                Usuario usuarioModificado = new Usuario(
                    txtNombre.Text,
                    txtApellido.Text,
                    int.Parse(txtTelefono.Text),
                    txtCorreo.Text,
                    txtCalle.Text,
                    int.Parse(txtNumero.Text)
                );

                // Aca se actualiza el usuario en la lista usando el índice.
                usuarios[indice] = usuarioModificado;

                // Actualiza la lista cada vez que se modifica un usuario.
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                txtCalle.Clear();
                txtNumero.Clear();

                dgvUsuarios.Refresh();

            }

        }




















        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Aca agarra el indice de la fila que se seleccione, empezando por el primero"0".
                int indice = dgvUsuarios.SelectedRows[0].Index;

                // Elimina el usuario utilizando el metodo RemoveAt.
                usuarios.RemoveAt(indice);

                // Remueve la fila seleccionada del DataGridView, mediante la propiedad Rows, usando el metodo RemoveAt que usa el índice.
                dgvUsuarios.Rows.RemoveAt(indice);

                // Actualiza la interfaz gráfica del DataGridView para que se noten los cambios.
                dgvUsuarios.Refresh();

                // Para probar nomas que los cambios esten correctos
                dgvUsuarios.Update();
            }
        }


















        private void btnEliminarTodos_Click(object sender, EventArgs e)
        {
            // Limpia todas las filas del DataGridView (elimina todo pal carajo)
            dgvUsuarios.Rows.Clear();
        }






















        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Esto es para que las columnas vacias, cuando sean nulas, no se genere una excepcion.
            //asegura que primero se verifique si la celda en sí y su valor son no nulos antes de
            //intentar acceder al valor y mostrarlo en los TextBox correspondientes.
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];

                if (row.Cells["Nombre"] != null && row.Cells["Nombre"].Value != null)
                {
                    txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                }

                if (row.Cells["Apellido"] != null && row.Cells["Apellido"].Value != null)
                {
                    txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                }

                if (row.Cells["Calle"] != null && row.Cells["Calle"].Value != null)
                {
                    txtCalle.Text = row.Cells["Calle"].Value.ToString();
                }

                if (row.Cells["Correo"] != null && row.Cells["Correo"].Value != null)
                {
                    txtCorreo.Text = row.Cells["Correo"].Value.ToString();
                }

                if (row.Cells["Telefono"] != null && row.Cells["Telefono"].Value != null)
                {
                    txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                }

                if (row.Cells["Numero"] != null && row.Cells["Numero"].Value != null)
                {
                    txtNumero.Text = row.Cells["Numero"].Value.ToString();
                }
            }
        }





















        //Para mover la ventana desde el panel superior ( si se apreta en el titulo (label) no funka).
        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                X = e.X;
                Y = e.Y;
            }
            else
            {
                Left = Left + (e.X - X);
                Top = Top + (e.Y - Y);
            }
        }
    }

}






































