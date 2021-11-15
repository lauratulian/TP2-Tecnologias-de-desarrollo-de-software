
namespace UI.Desktop
{
    partial class Docentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Docentes));
            this.tcDocentes = new System.Windows.Forms.ToolStripContainer();
            this.tlDocentes = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDocentes = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsDocentes = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDocente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcDocentes.ContentPanel.SuspendLayout();
            this.tcDocentes.TopToolStripPanel.SuspendLayout();
            this.tcDocentes.SuspendLayout();
            this.tlDocentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes)).BeginInit();
            this.tsDocentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcDocentes
            // 
            // 
            // tcDocentes.ContentPanel
            // 
            this.tcDocentes.ContentPanel.Controls.Add(this.tlDocentes);
            this.tcDocentes.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.tcDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDocentes.Location = new System.Drawing.Point(0, 0);
            this.tcDocentes.Name = "tcDocentes";
            this.tcDocentes.Size = new System.Drawing.Size(800, 450);
            this.tcDocentes.TabIndex = 0;
            this.tcDocentes.Text = "toolStripContainer1";
            // 
            // tcDocentes.TopToolStripPanel
            // 
            this.tcDocentes.TopToolStripPanel.Controls.Add(this.tsDocentes);
            // 
            // tlDocentes
            // 
            this.tlDocentes.ColumnCount = 2;
            this.tlDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlDocentes.Controls.Add(this.dgvDocentes, 0, 0);
            this.tlDocentes.Controls.Add(this.btnActualizar, 0, 1);
            this.tlDocentes.Controls.Add(this.btnSalir, 1, 1);
            this.tlDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDocentes.Location = new System.Drawing.Point(0, 0);
            this.tlDocentes.Name = "tlDocentes";
            this.tlDocentes.RowCount = 2;
            this.tlDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlDocentes.Size = new System.Drawing.Size(800, 425);
            this.tlDocentes.TabIndex = 0;
            // 
            // dgvDocentes
            // 
            this.dgvDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Cargo,
            this.IDCurso,
            this.IDDocente});
            this.tlDocentes.SetColumnSpan(this.dgvDocentes, 2);
            this.dgvDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocentes.Location = new System.Drawing.Point(3, 3);
            this.dgvDocentes.Name = "dgvDocentes";
            this.dgvDocentes.Size = new System.Drawing.Size(794, 390);
            this.dgvDocentes.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(635, 399);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(78, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualzar";
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
            this.btnSalir.Location = new System.Drawing.Point(719, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(78, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsDocentes
            // 
            this.tsDocentes.Dock = System.Windows.Forms.DockStyle.None;
            this.tsDocentes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsDocentes.Location = new System.Drawing.Point(3, 0);
            this.tsDocentes.Name = "tsDocentes";
            this.tsDocentes.Size = new System.Drawing.Size(81, 25);
            this.tsDocentes.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "toolStripButton2";
            this.tsbEditar.ToolTipText = "Editar";
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "toolStripButton3";
            this.tsbEliminar.ToolTipText = "Eliminar";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "Cargo";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            // 
            // IDCurso
            // 
            this.IDCurso.DataPropertyName = "IDCurso";
            this.IDCurso.HeaderText = "IDCurso";
            this.IDCurso.Name = "IDCurso";
            this.IDCurso.ReadOnly = true;
            // 
            // IDDocente
            // 
            this.IDDocente.DataPropertyName = "IDDocente";
            this.IDDocente.HeaderText = "IDDocente";
            this.IDDocente.Name = "IDDocente";
            this.IDDocente.ReadOnly = true;
            // 
            // Docentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcDocentes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Docentes";
            this.Text = "Docentes";
            this.Load += new System.EventHandler(this.Docentes_Load);
            this.tcDocentes.ContentPanel.ResumeLayout(false);
            this.tcDocentes.TopToolStripPanel.ResumeLayout(false);
            this.tcDocentes.TopToolStripPanel.PerformLayout();
            this.tcDocentes.ResumeLayout(false);
            this.tcDocentes.PerformLayout();
            this.tlDocentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes)).EndInit();
            this.tsDocentes.ResumeLayout(false);
            this.tsDocentes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcDocentes;
        private System.Windows.Forms.TableLayoutPanel tlDocentes;
        private System.Windows.Forms.DataGridView dgvDocentes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsDocentes;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDocente;
    }
}