using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFinal.Dominio;
using EFinal.Logic;

namespace EFinal.AppWin
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        private void frmCliente_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            var listado = ClienteBL.Listar();
            dgvListado.Rows.Clear();
            foreach (var cliente in listado)
            {
                dgvListado.Rows.Add(cliente.ID, cliente.NombreCompleto, cliente.Direccion, cliente.Referencia, cliente.IdTipoCliente,
                    cliente.IdTipoDocumento, cliente.NumeroDocumento, cliente.Estado);
            }
        }

        private void nuevoRegistro(object sender, EventArgs e)
        {
            var nuevoCliente = new Cliente();
            var frm = new frmClienteEditcs(nuevoCliente);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var exito = ClienteBL.Insertar(nuevoCliente);
                if (exito)
                {
                    MessageBox.Show("El cliente ha sido registrado", "Final",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("El cliente no se ha podido registrar", "Final",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idCliente = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var clienteEditar = ClienteBL.BuscarPorId(idCliente);
                var frm = new frmClienteEditcs(clienteEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = ClienteBL.Actualizar(clienteEditar);
                    if (exito)
                    {
                        MessageBox.Show("El cliente ha sido actualizado", "Final",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la actualizacion", "Final",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void eliminarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idCliente = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var nombreCliente = dgvListado.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("Realmente desea eliminar al cliente" + nombreCliente + " ?",
                    "Final", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    var exito = ClienteBL.Eliminar(idCliente);
                    if (exito)
                    {
                        MessageBox.Show("El cliente ha sido eliminado", "Final",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar al cliente", "Final",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
