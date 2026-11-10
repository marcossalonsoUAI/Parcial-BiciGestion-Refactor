using BLL;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormPrincipal : Form
    {
        private List<Alquiler> borradorAlquileres;
        private AlquilerBLL alquilerBll;
        private TipoBicicletaBLL tipoBicicletaBll;
        public FormPrincipal()
        {
            InitializeComponent();
            alquilerBll = new AlquilerBLL();
            tipoBicicletaBll = new TipoBicicletaBLL();
            borradorAlquileres = new List<Alquiler>();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarTiposBicicleta();
            CargarGrilla();
        }
        private void CargarTiposBicicleta()
        {
            try
            {
                cmbTipoBicicleta.DataSource = tipoBicicletaBll.GetAll();
                cmbTipoBicicleta.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de bicicleta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla()
        {
            try
            {
                dgvAlquileres.DataSource = null;
                dgvAlquileres.DataSource = alquilerBll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los alquileres: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarBorrador_Click(object sender, EventArgs e)
        {
            try
            {
                var alquiler = new Alquiler
                {
                    TipoBicicleta = (TipoBicicleta)cmbTipoBicicleta.SelectedItem,
                    DniCliente = txtDni.Text,
                    ImporteTotal = numImporte.Value,
                    FechaAlquiler = dtpFechaAlquiler.Value
                };

                borradorAlquileres.Add(alquiler);
                MessageBox.Show($"Alquiler agregado al borrador.\nTotal en borrador: {borradorAlquileres.Count}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGuardarTransaccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (borradorAlquileres.Count == 0)
                {
                    MessageBox.Show("No hay alquileres en el borrador para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                alquilerBll.GuardarBorrador(borradorAlquileres);
                MessageBox.Show("Todos los alquileres fueron guardados correctamente mediante transacción.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                borradorAlquileres.Clear();
                CargarGrilla();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Validación de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)numIdAlquiler.Value;
                decimal importe = numImporteModificar.Value;
                DateTime fecha = dtpFechaAlquilerModificar.Value;

                alquilerBll.Update(id, importe, fecha);
                MessageBox.Show("Alquiler modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)numIdAlquiler.Value;

                var dialog = MessageBox.Show("¿Está seguro de eliminar el alquiler seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    alquilerBll.Delete(id);
                    MessageBox.Show("Alquiler eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                }
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvAlquileres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAlquileres.Rows[e.RowIndex];
                numIdAlquiler.Value = Convert.ToDecimal(row.Cells["NumeroAlquiler"].Value);
                numImporteModificar.Value = Convert.ToDecimal(row.Cells["ImporteTotal"].Value);
                dtpFechaAlquilerModificar.Value = Convert.ToDateTime(row.Cells["FechaAlquiler"].Value);
            }
        }

        private void LimpiarCampos()
        {
            txtDni.Text = string.Empty;
            numImporte.Value = 0;
            dtpFechaAlquiler.Value = DateTime.Now;
            if (cmbTipoBicicleta.Items.Count > 0)
                cmbTipoBicicleta.SelectedIndex = 0;
        }
    }
}
