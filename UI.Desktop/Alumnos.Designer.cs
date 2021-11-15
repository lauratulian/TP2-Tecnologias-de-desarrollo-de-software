
namespace UI.Desktop
{
    partial class Alumnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alumnos));
            this.tcAlumnos = new System.Windows.Forms.ToolStripContainer();
            this.tlUsuarios = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbModificarNota = new System.Windows.Forms.ToolStripButton();
            this.tslCurso = new System.Windows.Forms.ToolStripLabel();
            this.tscbCurso = new System.Windows.Forms.ToolStripComboBox();
            this.tsbFiltro = new System.Windows.Forms.ToolStripButton();
            this.tcAlumnos.ContentPanel.SuspendLayout();
            this.tcAlumnos.TopToolStripPanel.SuspendLayout();
            this.tcAlumnos.SuspendLayout();
            this.tlUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcAlumnos
            // 
            // 
            // tcAlumnos.ContentPanel
            // 
            this.tcAlumnos.ContentPanel.Controls.Add(this.tlUsuarios);
            this.tcAlumnos.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tcAlumnos.ContentPanel.Size = new System.Drawing.Size(1067, 527);
            this.tcAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAlumnos.Location = new System.Drawing.Point(0, 0);
            this.tcAlumnos.Margin = new System.Windows.Forms.Padding(4);
            this.tcAlumnos.Name = "tcAlumnos";
            this.tcAlumnos.Size = new System.Drawing.Size(1067, 554);
            this.tcAlumnos.TabIndex = 0;
            this.tcAlumnos.Text = "toolStripContainer1";
            // 
            // tcAlumnos.TopToolStripPanel
            // 
            this.tcAlumnos.TopToolStripPanel.BackColor = System.Drawing.Color.White;
            this.tcAlumnos.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tlUsuarios
            // 
            this.tlUsuarios.BackColor = System.Drawing.Color.White;
            this.tlUsuarios.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tlUsuarios.ColumnCount = 2;
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlUsuarios.Controls.Add(this.dgvAlumnos, 0, 0);
            this.tlUsuarios.Controls.Add(this.btnActualizar, 0, 1);
            this.tlUsuarios.Controls.Add(this.btnSalir, 1, 1);
            this.tlUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tlUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.tlUsuarios.Name = "tlUsuarios";
            this.tlUsuarios.RowCount = 2;
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlUsuarios.Size = new System.Drawing.Size(1067, 527);
            this.tlUsuarios.TabIndex = 0;
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.AllowUserToResizeColumns = false;
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idCurso,
            this.nota,
            this.condicion});
            this.tlUsuarios.SetColumnSpan(this.dgvAlumnos, 2);
            this.dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos.Location = new System.Drawing.Point(7, 7);
            this.dgvAlumnos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.RowHeadersWidth = 51;
            this.dgvAlumnos.Size = new System.Drawing.Size(1053, 474);
            this.dgvAlumnos.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 125;
            // 
            // idCurso
            // 
            this.idCurso.DataPropertyName = "IDCurso";
            this.idCurso.HeaderText = "IDCurso";
            this.idCurso.MinimumWidth = 6;
            this.idCurso.Name = "idCurso";
            this.idCurso.ReadOnly = true;
            this.idCurso.Width = 125;
            // 
            // nota
            // 
            this.nota.DataPropertyName = "Nota";
            this.nota.HeaderText = "Nota";
            this.nota.MinimumWidth = 6;
            this.nota.Name = "nota";
            this.nota.ReadOnly = true;
            this.nota.Width = 125;
            // 
            // condicion
            // 
            this.condicion.DataPropertyName = "Condicion";
            this.condicion.HeaderText = "Condicion";
            this.condicion.MinimumWidth = 6;
            this.condicion.Name = "condicion";
            this.condicion.ReadOnly = true;
            this.condicion.Width = 125;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(841, 492);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(104, 28);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(956, 492);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 28);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEditar,
            this.tsbEliminar,
            this.tsbModificarNota,
            this.tslCurso,
            this.tscbCurso,
            this.tsbFiltro});
            this.toolStrip1.Location = new System.Drawing.Point(4, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(100, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(29, 24);
            this.tsbEditar.Text = "toolStripButton2";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(29, 24);
            this.tsbEliminar.Text = "toolStripButton3";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // tsbModificarNota
            // 
            this.tsbModificarNota.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbModificarNota.Image = ((System.Drawing.Image)(resources.GetObject("tsbModificarNota.Image")));
            this.tsbModificarNota.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModificarNota.Name = "tsbModificarNota";
            this.tsbModificarNota.Size = new System.Drawing.Size(29, 24);
            this.tsbModificarNota.Text = "toolStripButton1";
            this.tsbModificarNota.ToolTipText = "Modificar nota";
            this.tsbModificarNota.Click += new System.EventHandler(this.tsbModificarNota_Click);
            // 
            // tslCurso
            // 
            this.tslCurso.Name = "tslCurso";
            this.tslCurso.Size = new System.Drawing.Size(49, 25);
            this.tslCurso.Text = "Curso:";
            this.tslCurso.Visible = false;
            // 
            // tscbCurso
            // 
            this.tscbCurso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tscbCurso.Name = "tscbCurso";
            this.tscbCurso.Size = new System.Drawing.Size(121, 28);
            this.tscbCurso.Visible = false;
            // 
            // tsbFiltro
            // 
            this.tsbFiltro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltro.Image = ((System.Drawing.Image)(resources.GetObject("tsbFiltro.Image")));
            this.tsbFiltro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltro.Name = "tsbFiltro";
            this.tsbFiltro.Size = new System.Drawing.Size(29, 24);
            this.tsbFiltro.Text = "Filtrar";
            this.tsbFiltro.Visible = false;
            this.tsbFiltro.Click += new System.EventHandler(this.tsbFiltro_Click);
            // 
            // Alumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tcAlumnos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Alumnos";
            this.Text = "Alumnos";
            this.Load += new System.EventHandler(this.Alumnos_Load);
            this.tcAlumnos.ContentPanel.ResumeLayout(false);
            this.tcAlumnos.TopToolStripPanel.ResumeLayout(false);
            this.tcAlumnos.TopToolStripPanel.PerformLayout();
            this.tcAlumnos.ResumeLayout(false);
            this.tcAlumnos.PerformLayout();
            this.tlUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcAlumnos;
        private System.Windows.Forms.TableLayoutPanel tlUsuarios;
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbModificarNota;
        private System.Windows.Forms.ToolStripLabel tslCurso;
        private System.Windows.Forms.ToolStripComboBox tscbCurso;
        private System.Windows.Forms.ToolStripButton tsbFiltro;
    }
}