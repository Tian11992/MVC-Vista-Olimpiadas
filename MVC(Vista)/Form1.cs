using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador.Paises;

namespace MVC_Vista_
{
    public partial class Form1 : Form
    {

        PaisesDTO paisesDTO = null;
        PaisesDAO paisesDAO = null;
        DataTable Dtt = null;

        public Form1()
        {
            InitializeComponent();
            ListarPaises();
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
        }

        public void ListarPaises()
        {

            paisesDTO = new PaisesDTO();

            paisesDAO = new PaisesDAO(paisesDTO);

            Dtt = new DataTable();
            Dtt = paisesDAO.ListarPaises();

            if (Dtt.Rows.Count > 0)
            {
                dtpaises.DataSource = Dtt;
            }
            else
            {
                MessageBox.Show("No hay registros de Paises");
            }
        }
        public void Guardar()
        {

            paisesDTO = new PaisesDTO();
            paisesDTO.setNombrepais (txtnombre.Text);
            paisesDAO = new PaisesDAO(paisesDTO);


            paisesDAO.GuardarPais();
            MessageBox.Show("Registro guardado.");

        }

        public void GuardarCambios()
        {

            paisesDTO = new PaisesDTO();
            paisesDTO.setIdpais(Convert.ToInt16(txtcodigo.Text));
            paisesDTO.setNombrepais(txtnombre.Text);
            paisesDAO = new PaisesDAO(paisesDTO);


            paisesDAO.GuardarCambios();
            MessageBox.Show("Registro modificado.");

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            if (txtnombre.Text.Trim() == "")
            {
                MessageBox.Show("Oye Hacker, intenta un dato válido.");
                txtnombre.Focus();
            }
            else
            {

                Guardar();
                ListarPaises();
                txtnombre.Clear();
                txtnombre.Focus();

            }

        }

        private void dtpaises_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label4.Visible = true;
            txtcodigo.Visible = true;
            txtcodigo.Enabled = false;

            txtcodigo.Text = dtpaises.Rows[dtpaises.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dtpaises.Rows[dtpaises.CurrentRow.Index].Cells[1].Value.ToString();

            btnguardar.Enabled = false;
            btnguardarcambios.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;

        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {

            if (txtnombre.Text.Trim() == "")
            {
                MessageBox.Show("Oye Hacker, intenta un dato válido.");
                txtnombre.Focus();
            }
            else
            {
                GuardarCambios();
                ListarPaises();

                label4.Visible = false;
                txtcodigo.Visible = false;
                btnguardar.Enabled = true;
                btnguardarcambios.Enabled = false;
                btneliminar.Enabled = false;
                btncancelar.Enabled = false;
                txtnombre.Clear();
                txtnombre.Focus();
            }
     
        }

        public void EliminarRegistroPais()
        {
            paisesDTO = new PaisesDTO();
            paisesDTO.setIdpais(Convert.ToInt16(txtcodigo.Text));
            paisesDAO = new PaisesDAO(paisesDTO);


            paisesDAO.Eliminar();
            MessageBox.Show("Registro eliminado.");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistroPais();

            ListarPaises();
            label4.Visible = false;
            txtcodigo.Visible = false;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
            txtnombre.Clear();
            txtnombre.Focus();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            ListarPaises();
            label4.Visible = false;
            txtcodigo.Visible = false;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
            txtnombre.Clear();
            txtnombre.Focus();
        }
    }
}
