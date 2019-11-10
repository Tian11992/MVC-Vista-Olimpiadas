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
using Controlador.Participantes;

namespace MVC_Vista_
{
    public partial class Participantes : Form
    {

        ParticipantesDTO participantesDTO = null;
        ParticipantesDAO participantesDAO = null;
        PaisesDTO paisesDTO = null;
        PaisesDAO paisesDAO = null;
        DataTable DttPaises = null;
        DataTable DttParticipantes = null;

        public Participantes()
        {
            InitializeComponent();
            ListarPaises();
            cmbpais.SelectedIndex = 0;
            ListarParticipantes();

            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
        }

        private void ListarPaises()
        {
            paisesDTO = new PaisesDTO();
            paisesDAO = new PaisesDAO(paisesDTO);

            DttPaises = new DataTable();
            DttPaises = paisesDAO.ListarPaises();

            if (DttPaises.Rows.Count > 0)
            {
                cmbpais.DataSource = DttPaises;

                DataRow dataRow = DttPaises.NewRow();
                dataRow["nombrepais"] = "Seleccione";
                DttPaises.Rows.InsertAt(dataRow, 0);

                cmbpais.DisplayMember = "nombrepais";
                cmbpais.ValueMember = "idpais";
            }
        }

        private void GuardarParticipantes()
        {
            if (cmbpais.SelectedIndex == 0)
            {
                MessageBox.Show("Selecciona un pais.");
            }
            else
            {
                participantesDTO = new ParticipantesDTO();
                participantesDTO.setCedula(Convert.ToInt32(txtcedula.Text));
                participantesDTO.setNombre(txtnombre.Text);
                participantesDTO.setPais(int.Parse(cmbpais.SelectedValue.ToString()));
                participantesDTO.setEdad(int.Parse(txtedad.Text));

                participantesDAO = new ParticipantesDAO(participantesDTO);

                participantesDAO.GuardarParticipantes();

                MessageBox.Show("Participante guardado.");
            }
            
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtedad.Text) > 200)
            {
                MessageBox.Show("La edad es incorrecra.");
                txtedad.Focus();
            }
            else
            {
                GuardarParticipantes();
                ListarParticipantes();
                LimpiaDatos();
            }
            
        }
        private void ListarParticipantes()
        {
            participantesDTO = new ParticipantesDTO();
            participantesDAO = new ParticipantesDAO(participantesDTO);

            DttParticipantes = new DataTable();
            DttParticipantes = participantesDAO.ListarParticipantes();

            if (DttParticipantes.Rows.Count > 0)
            {
                dtparticipantes.DataSource = DttParticipantes;
            }
            else
            {
                MessageBox.Show("No hay participantes registrados.");
            }
        }
        private void LimpiaDatos()
        {
            txtcedula.Clear();
            txtnombre.Clear();
            cmbpais.SelectedIndex = 0;
            txtedad.Clear();
            txtcedula.Focus();
        }

        private void dtparticipantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcedula.Text = dtparticipantes.Rows[dtparticipantes.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dtparticipantes.Rows[dtparticipantes.CurrentRow.Index].Cells[1].Value.ToString();
            txtedad.Text = dtparticipantes.Rows[dtparticipantes.CurrentRow.Index].Cells[3].Value.ToString();
            MostrarInfoPais();
            lblpais.Text = dtparticipantes.Rows[dtparticipantes.CurrentRow.Index].Cells[2].Value.ToString();

            txtcedula.Enabled = false;
            btnguardar.Enabled = false;
            btnguardarcambios.Enabled = true;
            btneliminar.Enabled = true;
            btncancelar.Enabled = true;

        }
        private void GuardarCambiosSinPaisParticipantes()
        {
            participantesDTO = new ParticipantesDTO();
            participantesDTO.setCedula(Convert.ToInt32(txtcedula.Text));
            participantesDTO.setNombre(txtnombre.Text);
            participantesDTO.setEdad(int.Parse(txtedad.Text));

            participantesDAO = new ParticipantesDAO(participantesDTO);

            participantesDAO.GuardarCambiosParticipantesSinPais();

            MessageBox.Show("Participante actualizado.");
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtedad.Text) > 200)
            {
                MessageBox.Show("La edad es incorrecra.");
                txtedad.Focus();
            }
            else
            {
                if (cmbpais.SelectedIndex == 0)
                {
                    GuardarCambiosSinPaisParticipantes();
                }
                else
                {
                    GuardarCambiosConPaisParticipantes();
                }
                txtcedula.Enabled = true;
                btnguardar.Enabled = true;
                btnguardarcambios.Enabled = false;
                btneliminar.Enabled = false;
                btncancelar.Enabled = false;
                AccionesCampos();
            }
            
            
        }

        private void GuardarCambiosConPaisParticipantes()
        {
            participantesDTO = new ParticipantesDTO();
            participantesDTO.setCedula(Convert.ToInt32(txtcedula.Text));
            participantesDTO.setNombre(txtnombre.Text);
            participantesDTO.setPais(int.Parse(cmbpais.SelectedValue.ToString()));
            participantesDTO.setEdad(int.Parse(txtedad.Text));

            participantesDAO = new ParticipantesDAO(participantesDTO);

            participantesDAO.GuardarCambiosParticipantesConPais();

            MessageBox.Show("Participante actualizado.");
        }

        private void ElimiarParticipante()
        {
            participantesDTO = new ParticipantesDTO();
            participantesDTO.setCedula(Convert.ToInt32(txtcedula.Text));
            participantesDAO = new ParticipantesDAO(participantesDTO);

            participantesDAO.EliminarParticipantes();

            MessageBox.Show("Participante eliminado.");
            LimpiaDatos();
            ListarPaises();
            ListarParticipantes();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            ElimiarParticipante();
            txtcedula.Enabled = true;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
            AccionesCampos();
        }

        private void MostrarInfoPais()
        {
            label6.Visible = true;
            lblpais.Visible = true;
        }

        private void OcultarInfoPais()
        {
            label6.Visible = false;
            lblpais.Visible = false;
        }

        private void AccionesCampos()
        {
            ListarParticipantes();
            ListarPaises();
            OcultarInfoPais();
            LimpiaDatos();
            cmbpais.SelectedIndex = 0;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            txtcedula.Enabled = true;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
            AccionesCampos();
        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionCampos.validacionNumerica(sender, e);
        }

        private void txtedad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionCampos.validacionNumerica(sender, e);
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Dispose();

        }
    }
}
