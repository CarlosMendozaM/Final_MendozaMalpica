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
    public partial class frmConsultaPrestamo : Form
    {
        Prestamo prestamo;

        public frmConsultaPrestamo()
        {
            InitializeComponent();
        }

        private void abrirConsulta(object sender, EventArgs e)
        {
            cargardatos();
            if (prestamo.ID > 0)
            {
                asignarControles();
            }
        }

        private void cargardatos()
        {
            cboPrestamo.DataSource = PrestamoBL.Listar();
            cboPrestamo.DisplayMember = "Numero";
            cboPrestamo.ValueMember = "ID";
        }

        private void grabarDatos(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }

        private void asignarObjeto()
        {
            this.prestamo.IdCliente = int.Parse(txtCliente.Text);
            this.prestamo.Importe = int.Parse(txtImporte.Text);
            this.prestamo.Tasa = int.Parse(txtTaza.Text);
            this.prestamo.Plazo = int.Parse(txtPlazo.Text);
        }
        private void asignarControles()
        {
            txtCliente.Text = this.prestamo.IdCliente.ToString();
            txtImporte.Text = this.prestamo.Importe.ToString();
            txtTaza.Text = this.prestamo.Tasa.ToString();
            txtPlazo.Text = this.prestamo.Plazo.ToString();
        }

        private void frmConsultaPrestamo_Load(object sender, EventArgs e)
        {
            //    cargarDatos2();
        }
        //private void cargarDatos2()
        //{
        //    var listado = PrestamoBL.Listar();
        //    dgvListado.Rows.Clear();
        //    foreach (var cliente in listado)
        //    {
        //        dgvListado.Rows.Add(prestamo.ID, prestamo.Numero, prestamo.Fecha, prestamo.Importe);
        //    }
        //}
    }
}
