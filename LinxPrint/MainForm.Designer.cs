namespace LinxPrint
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.editModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePrintedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.importToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editModeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.searchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dateToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.stateToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.portNameToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalCodesToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.printedCodesToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressLabelToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarToolStrip = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrinted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPrintedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrintedDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.printToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(762, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.MenuActivate += new System.EventHandler(this.menuStrip_MenuActivate);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.fileToolStripMenuItem.Text = "&Archivo";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.importToolStripMenuItem.Text = "Importar...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.exitToolStripMenuItem.Text = "Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.toolStripSeparator4,
            this.editModeToolStripMenuItem,
            this.deleteToolStripSubMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.editToolStripMenuItem.Text = "&Edición";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.searchToolStripMenuItem.Text = "Buscar";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // editModeToolStripMenuItem
            // 
            this.editModeToolStripMenuItem.CheckOnClick = true;
            this.editModeToolStripMenuItem.Name = "editModeToolStripMenuItem";
            this.editModeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editModeToolStripMenuItem.Text = "Modo de edición";
            this.editModeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.editModeToolStripMenuItem_CheckedChanged);
            this.editModeToolStripMenuItem.Click += new System.EventHandler(this.editModeToolStripMenuItem_Click);
            // 
            // deleteToolStripSubMenuItem
            // 
            this.deleteToolStripSubMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.deletePrintedToolStripMenuItem,
            this.deleteAllToolStripMenuItem});
            this.deleteToolStripSubMenuItem.Name = "deleteToolStripSubMenuItem";
            this.deleteToolStripSubMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteToolStripSubMenuItem.Text = "Eliminar";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.deleteToolStripMenuItem.Text = "Eliminar";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deletePrintedToolStripMenuItem
            // 
            this.deletePrintedToolStripMenuItem.Name = "deletePrintedToolStripMenuItem";
            this.deletePrintedToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.deletePrintedToolStripMenuItem.Text = "Eliminar impresos";
            this.deletePrintedToolStripMenuItem.Click += new System.EventHandler(this.deletePrintedToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.deleteAllToolStripMenuItem.Text = "Eliminar todos";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.deleteAllToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printAllToolStripMenuItem,
            this.printSelectionToolStripMenuItem});
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.printToolStripMenuItem.Text = "&Impresión";
            // 
            // printAllToolStripMenuItem
            // 
            this.printAllToolStripMenuItem.Name = "printAllToolStripMenuItem";
            this.printAllToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.printAllToolStripMenuItem.Text = "Imprimir todo";
            this.printAllToolStripMenuItem.Click += new System.EventHandler(this.printAllToolStripMenuItem_Click);
            // 
            // printSelectionToolStripMenuItem
            // 
            this.printSelectionToolStripMenuItem.Name = "printSelectionToolStripMenuItem";
            this.printSelectionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.printSelectionToolStripMenuItem.Text = "Imprimir selección";
            this.printSelectionToolStripMenuItem.Click += new System.EventHandler(this.printSelectionToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.serialPortConfigToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.toolsToolStripMenuItem.Text = "&Herramientas";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.settingsToolStripMenuItem.Text = "Configuración...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // serialPortConfigToolStripMenuItem
            // 
            this.serialPortConfigToolStripMenuItem.Name = "serialPortConfigToolStripMenuItem";
            this.serialPortConfigToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.serialPortConfigToolStripMenuItem.Text = "SerialPort Información";
            this.serialPortConfigToolStripMenuItem.Click += new System.EventHandler(this.serialPortConfigToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripButton,
            this.toolStripSeparator1,
            this.editModeToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator2,
            this.printToolStripButton,
            this.toolStripSeparator3,
            this.searchToolStripButton,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.dateToolStripTextBox,
            this.toolStripLabel2,
            this.stateToolStripComboBox});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(762, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // importToolStripButton
            // 
            this.importToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("importToolStripButton.Image")));
            this.importToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importToolStripButton.Name = "importToolStripButton";
            this.importToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.importToolStripButton.Text = "Importar...";
            this.importToolStripButton.ToolTipText = "Importar...";
            this.importToolStripButton.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // editModeToolStripButton
            // 
            this.editModeToolStripButton.CheckOnClick = true;
            this.editModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editModeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editModeToolStripButton.Image")));
            this.editModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editModeToolStripButton.Name = "editModeToolStripButton";
            this.editModeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editModeToolStripButton.Text = "Modo de edición";
            this.editModeToolStripButton.ToolTipText = "Modo de edición";
            this.editModeToolStripButton.Click += new System.EventHandler(this.editModeToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "Eliminar";
            this.deleteToolStripButton.ToolTipText = "Eliminar";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "Imprimir todo";
            this.printToolStripButton.ToolTipText = "Imprimir todo";
            this.printToolStripButton.Click += new System.EventHandler(this.printAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // searchToolStripButton
            // 
            this.searchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripButton.Image")));
            this.searchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchToolStripButton.Name = "searchToolStripButton";
            this.searchToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.searchToolStripButton.Text = "toolStripButton1";
            this.searchToolStripButton.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel1.Text = "Fecha:";
            // 
            // dateToolStripTextBox
            // 
            this.dateToolStripTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.dateToolStripTextBox.Name = "dateToolStripTextBox";
            this.dateToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            this.dateToolStripTextBox.ToolTipText = "Seleccione una fecha para ver los pincodes importados ese día";
            this.dateToolStripTextBox.TextChanged += new System.EventHandler(this.dateToolStripTextBox_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel2.Text = "Estado:";
            // 
            // stateToolStripComboBox
            // 
            this.stateToolStripComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.stateToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateToolStripComboBox.Items.AddRange(new object[] {
            "Todos",
            "Impreso",
            "No Impreso"});
            this.stateToolStripComboBox.Name = "stateToolStripComboBox";
            this.stateToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.stateToolStripComboBox.ToolTipText = "Filtra los pincodes en función de su estado";
            this.stateToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.stateToolStripComboBox_SelectedIndexChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portNameToolStrip,
            this.toolStripStatusLabel4,
            this.totalCodesToolStripLabel,
            this.toolStripStatusLabel3,
            this.printedCodesToolStripLabel,
            this.progressLabelToolStrip,
            this.progressBarToolStrip});
            this.statusStrip.Location = new System.Drawing.Point(0, 362);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(762, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // portNameToolStrip
            // 
            this.portNameToolStrip.Name = "portNameToolStrip";
            this.portNameToolStrip.Size = new System.Drawing.Size(82, 17);
            this.portNameToolStrip.Text = "Puerto: COM1";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.AutoSize = false;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            // 
            // totalCodesToolStripLabel
            // 
            this.totalCodesToolStripLabel.Name = "totalCodesToolStripLabel";
            this.totalCodesToolStripLabel.Size = new System.Drawing.Size(106, 17);
            this.totalCodesToolStripLabel.Text = "Total de códigos: 0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.AutoSize = false;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            // 
            // printedCodesToolStripLabel
            // 
            this.printedCodesToolStripLabel.Name = "printedCodesToolStripLabel";
            this.printedCodesToolStripLabel.Size = new System.Drawing.Size(114, 17);
            this.printedCodesToolStripLabel.Text = "Códigos impresos: 0";
            // 
            // progressLabelToolStrip
            // 
            this.progressLabelToolStrip.ForeColor = System.Drawing.Color.DarkViolet;
            this.progressLabelToolStrip.Name = "progressLabelToolStrip";
            this.progressLabelToolStrip.Size = new System.Drawing.Size(85, 17);
            this.progressLabelToolStrip.Text = "Imprimiendo...";
            this.progressLabelToolStrip.Visible = false;
            // 
            // progressBarToolStrip
            // 
            this.progressBarToolStrip.Enabled = false;
            this.progressBarToolStrip.Name = "progressBarToolStrip";
            this.progressBarToolStrip.Size = new System.Drawing.Size(100, 16);
            this.progressBarToolStrip.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarToolStrip.Visible = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.colRecNo,
            this.colPrinted,
            this.colPrintedOn,
            this.colPrintedDetails});
            this.dataGridView.DataSource = this.bindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 49);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(762, 313);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowValidated);
            this.dataGridView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            this.dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserDeletedRow);
            // 
            // bindingSource
            // 
            this.bindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.bindingSource_AddingNew);
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Código";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colRecNo
            // 
            this.colRecNo.DataPropertyName = "RecNo";
            this.colRecNo.HeaderText = "No.";
            this.colRecNo.Name = "colRecNo";
            this.colRecNo.ReadOnly = true;
            // 
            // colPrinted
            // 
            this.colPrinted.DataPropertyName = "Printed";
            this.colPrinted.HeaderText = "Impreso";
            this.colPrinted.Name = "colPrinted";
            this.colPrinted.ReadOnly = true;
            this.colPrinted.Width = 60;
            // 
            // colPrintedOn
            // 
            this.colPrintedOn.DataPropertyName = "PrintedOn";
            this.colPrintedOn.HeaderText = "Fecha de impresión";
            this.colPrintedOn.Name = "colPrintedOn";
            this.colPrintedOn.ReadOnly = true;
            this.colPrintedOn.Width = 140;
            // 
            // colPrintedDetails
            // 
            this.colPrintedDetails.DataPropertyName = "PrintedDetails";
            this.colPrintedDetails.HeaderText = "Detalles de la impresión";
            this.colPrintedDetails.Name = "colPrintedDetails";
            this.colPrintedDetails.ReadOnly = true;
            this.colPrintedDetails.Width = 300;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 384);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LinxPrint";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editModeToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton importToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton editModeToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox dateToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem printAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel totalCodesToolStripLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel progressLabelToolStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBarToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel portNameToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialPortConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox stateToolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePrintedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton searchToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel printedCodesToolStripLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPrinted;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrintedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrintedDetails;
    }
}