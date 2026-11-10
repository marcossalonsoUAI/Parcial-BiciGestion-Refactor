namespace UI
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbTipoBicicleta = new ComboBox();
            txtDni = new TextBox();
            numImporte = new NumericUpDown();
            dtpFechaAlquiler = new DateTimePicker();
            btnAgregarBorrador = new Button();
            btnGuardarTransaccion = new Button();
            dgvAlquileres = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            numIdAlquiler = new NumericUpDown();
            numImporteModificar = new NumericUpDown();
            btnModificar = new Button();
            btnEliminar = new Button();
            dtpFechaAlquilerModificar = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)numImporte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlquileres).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIdAlquiler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numImporteModificar).BeginInit();
            SuspendLayout();
            // 
            // cmbTipoBicicleta
            // 
            cmbTipoBicicleta.FormattingEnabled = true;
            cmbTipoBicicleta.Location = new Point(40, 48);
            cmbTipoBicicleta.Name = "cmbTipoBicicleta";
            cmbTipoBicicleta.Size = new Size(152, 23);
            cmbTipoBicicleta.TabIndex = 0;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(40, 89);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(152, 23);
            txtDni.TabIndex = 1;
            // 
            // numImporte
            // 
            numImporte.Location = new Point(40, 130);
            numImporte.Name = "numImporte";
            numImporte.Size = new Size(152, 23);
            numImporte.TabIndex = 2;
            // 
            // dtpFechaAlquiler
            // 
            dtpFechaAlquiler.Location = new Point(40, 171);
            dtpFechaAlquiler.Name = "dtpFechaAlquiler";
            dtpFechaAlquiler.Size = new Size(152, 23);
            dtpFechaAlquiler.TabIndex = 3;
            // 
            // btnAgregarBorrador
            // 
            btnAgregarBorrador.Location = new Point(198, 48);
            btnAgregarBorrador.Name = "btnAgregarBorrador";
            btnAgregarBorrador.Size = new Size(105, 64);
            btnAgregarBorrador.TabIndex = 4;
            btnAgregarBorrador.Text = "Agregar a Borrador";
            btnAgregarBorrador.UseVisualStyleBackColor = true;
            btnAgregarBorrador.Click += btnAgregarBorrador_Click;
            // 
            // btnGuardarTransaccion
            // 
            btnGuardarTransaccion.Location = new Point(198, 130);
            btnGuardarTransaccion.Name = "btnGuardarTransaccion";
            btnGuardarTransaccion.Size = new Size(105, 64);
            btnGuardarTransaccion.TabIndex = 5;
            btnGuardarTransaccion.Text = "Guardar Transaccion";
            btnGuardarTransaccion.UseVisualStyleBackColor = true;
            btnGuardarTransaccion.Click += btnGuardarTransaccion_Click;
            // 
            // dgvAlquileres
            // 
            dgvAlquileres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlquileres.Location = new Point(321, 12);
            dgvAlquileres.Name = "dgvAlquileres";
            dgvAlquileres.Size = new Size(467, 426);
            dgvAlquileres.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 246);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 7;
            label1.Text = "Modificar - Eliminar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 12);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 8;
            label2.Text = "Alta";
            // 
            // numIdAlquiler
            // 
            numIdAlquiler.Location = new Point(40, 291);
            numIdAlquiler.Name = "numIdAlquiler";
            numIdAlquiler.Size = new Size(152, 23);
            numIdAlquiler.TabIndex = 9;
            // 
            // numImporteModificar
            // 
            numImporteModificar.Location = new Point(40, 329);
            numImporteModificar.Name = "numImporteModificar";
            numImporteModificar.Size = new Size(152, 23);
            numImporteModificar.TabIndex = 10;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(198, 268);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(105, 64);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(198, 349);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(105, 64);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dtpFechaAlquilerModificar
            // 
            dtpFechaAlquilerModificar.Location = new Point(40, 368);
            dtpFechaAlquilerModificar.Name = "dtpFechaAlquilerModificar";
            dtpFechaAlquilerModificar.Size = new Size(152, 23);
            dtpFechaAlquilerModificar.TabIndex = 13;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpFechaAlquilerModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(numImporteModificar);
            Controls.Add(numIdAlquiler);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvAlquileres);
            Controls.Add(btnGuardarTransaccion);
            Controls.Add(btnAgregarBorrador);
            Controls.Add(dtpFechaAlquiler);
            Controls.Add(numImporte);
            Controls.Add(txtDni);
            Controls.Add(cmbTipoBicicleta);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            Load += FormPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)numImporte).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlquileres).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIdAlquiler).EndInit();
            ((System.ComponentModel.ISupportInitialize)numImporteModificar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTipoBicicleta;
        private TextBox txtDni;
        private NumericUpDown numImporte;
        private DateTimePicker dtpFechaAlquiler;
        private Button btnAgregarBorrador;
        private Button btnGuardarTransaccion;
        private DataGridView dgvAlquileres;
        private Label label1;
        private Label label2;
        private NumericUpDown numIdAlquiler;
        private NumericUpDown numImporteModificar;
        private Button btnModificar;
        private Button btnEliminar;
        private DateTimePicker dtpFechaAlquilerModificar;
    }
}