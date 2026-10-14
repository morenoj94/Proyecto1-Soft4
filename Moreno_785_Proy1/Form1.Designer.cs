namespace Moreno_785_Proy1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lbl_uni_facu = new Label();
            lbl_identificadores_restante = new Label();
            grb_rango = new GroupBox();
            txt_hasta = new TextBox();
            lbl_hasta = new Label();
            txt_desde = new TextBox();
            lbl_desde = new Label();
            grb_pisos = new GroupBox();
            rb_todos = new RadioButton();
            rb_impares = new RadioButton();
            rb_pares = new RadioButton();
            grb_estado = new GroupBox();
            rb_mantenimiento = new RadioButton();
            rb_apagado = new RadioButton();
            rb_encendido = new RadioButton();
            tmr_mover = new System.Windows.Forms.Timer(components);
            lbl_estado = new Label();
            txt_estado = new TextBox();
            tmr_verificar = new System.Windows.Forms.Timer(components);
            tmr_esperar = new System.Windows.Forms.Timer(components);
            txt_atendiendo = new TextBox();
            lbl_atendiendo = new Label();
            grb_rango.SuspendLayout();
            grb_pisos.SuspendLayout();
            grb_estado.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_uni_facu
            // 
            lbl_uni_facu.AutoSize = true;
            lbl_uni_facu.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_uni_facu.Location = new Point(610, 62);
            lbl_uni_facu.Name = "lbl_uni_facu";
            lbl_uni_facu.Size = new Size(393, 75);
            lbl_uni_facu.TabIndex = 0;
            lbl_uni_facu.Text = "UNIVERSIDAD TECNOLÓGICA DE PANAMÁ\r\n\r\nFACULTAD DE INGENIERÍA DE SISTEMAS ";
            lbl_uni_facu.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl_identificadores_restante
            // 
            lbl_identificadores_restante.AutoSize = true;
            lbl_identificadores_restante.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_identificadores_restante.Location = new Point(644, 150);
            lbl_identificadores_restante.Name = "lbl_identificadores_restante";
            lbl_identificadores_restante.Size = new Size(324, 350);
            lbl_identificadores_restante.TabIndex = 2;
            lbl_identificadores_restante.Text = resources.GetString("lbl_identificadores_restante.Text");
            lbl_identificadores_restante.TextAlign = ContentAlignment.TopCenter;
            // 
            // grb_rango
            // 
            grb_rango.Controls.Add(txt_hasta);
            grb_rango.Controls.Add(lbl_hasta);
            grb_rango.Controls.Add(txt_desde);
            grb_rango.Controls.Add(lbl_desde);
            grb_rango.Location = new Point(438, 94);
            grb_rango.Name = "grb_rango";
            grb_rango.Size = new Size(156, 100);
            grb_rango.TabIndex = 3;
            grb_rango.TabStop = false;
            grb_rango.Text = "Rango";
            // 
            // txt_hasta
            // 
            txt_hasta.Location = new Point(85, 60);
            txt_hasta.Name = "txt_hasta";
            txt_hasta.Size = new Size(52, 27);
            txt_hasta.TabIndex = 3;
            txt_hasta.Text = "12";
            // 
            // lbl_hasta
            // 
            lbl_hasta.AutoSize = true;
            lbl_hasta.Location = new Point(3, 63);
            lbl_hasta.Name = "lbl_hasta";
            lbl_hasta.Size = new Size(47, 20);
            lbl_hasta.TabIndex = 2;
            lbl_hasta.Text = "Hasta";
            // 
            // txt_desde
            // 
            txt_desde.Location = new Point(85, 27);
            txt_desde.Name = "txt_desde";
            txt_desde.Size = new Size(52, 27);
            txt_desde.TabIndex = 1;
            txt_desde.Text = "0";
            // 
            // lbl_desde
            // 
            lbl_desde.AutoSize = true;
            lbl_desde.Location = new Point(3, 30);
            lbl_desde.Name = "lbl_desde";
            lbl_desde.Size = new Size(51, 20);
            lbl_desde.TabIndex = 0;
            lbl_desde.Text = "Desde";
            // 
            // grb_pisos
            // 
            grb_pisos.Controls.Add(rb_todos);
            grb_pisos.Controls.Add(rb_impares);
            grb_pisos.Controls.Add(rb_pares);
            grb_pisos.Location = new Point(438, 199);
            grb_pisos.Name = "grb_pisos";
            grb_pisos.Size = new Size(156, 100);
            grb_pisos.TabIndex = 4;
            grb_pisos.TabStop = false;
            grb_pisos.Text = "Pisos";
            // 
            // rb_todos
            // 
            rb_todos.AutoSize = true;
            rb_todos.Checked = true;
            rb_todos.Location = new Point(6, 69);
            rb_todos.Name = "rb_todos";
            rb_todos.Size = new Size(131, 24);
            rb_todos.TabIndex = 2;
            rb_todos.TabStop = true;
            rb_todos.Text = "Todos los pisos";
            rb_todos.UseVisualStyleBackColor = true;
            // 
            // rb_impares
            // 
            rb_impares.AutoSize = true;
            rb_impares.Location = new Point(6, 47);
            rb_impares.Name = "rb_impares";
            rb_impares.Size = new Size(120, 24);
            rb_impares.TabIndex = 1;
            rb_impares.Text = "Pisos impares";
            rb_impares.UseVisualStyleBackColor = true;
            // 
            // rb_pares
            // 
            rb_pares.AutoSize = true;
            rb_pares.Location = new Point(6, 26);
            rb_pares.Name = "rb_pares";
            rb_pares.Size = new Size(103, 24);
            rb_pares.TabIndex = 0;
            rb_pares.Text = "Pisos pares";
            rb_pares.UseVisualStyleBackColor = true;
            // 
            // grb_estado
            // 
            grb_estado.Controls.Add(rb_mantenimiento);
            grb_estado.Controls.Add(rb_apagado);
            grb_estado.Controls.Add(rb_encendido);
            grb_estado.Location = new Point(438, 304);
            grb_estado.Name = "grb_estado";
            grb_estado.Size = new Size(156, 100);
            grb_estado.TabIndex = 5;
            grb_estado.TabStop = false;
            grb_estado.Text = "Estado del elevador";
            // 
            // rb_mantenimiento
            // 
            rb_mantenimiento.AutoSize = true;
            rb_mantenimiento.Location = new Point(6, 69);
            rb_mantenimiento.Name = "rb_mantenimiento";
            rb_mantenimiento.Size = new Size(131, 24);
            rb_mantenimiento.TabIndex = 2;
            rb_mantenimiento.Text = "Mantenimiento";
            rb_mantenimiento.UseVisualStyleBackColor = true;
            // 
            // rb_apagado
            // 
            rb_apagado.AutoSize = true;
            rb_apagado.Location = new Point(6, 47);
            rb_apagado.Name = "rb_apagado";
            rb_apagado.Size = new Size(92, 24);
            rb_apagado.TabIndex = 1;
            rb_apagado.Text = "Apagado";
            rb_apagado.UseVisualStyleBackColor = true;
            // 
            // rb_encendido
            // 
            rb_encendido.AutoSize = true;
            rb_encendido.Checked = true;
            rb_encendido.Location = new Point(6, 26);
            rb_encendido.Name = "rb_encendido";
            rb_encendido.Size = new Size(100, 24);
            rb_encendido.TabIndex = 0;
            rb_encendido.TabStop = true;
            rb_encendido.Text = "Encendido";
            rb_encendido.UseVisualStyleBackColor = true;
            // 
            // tmr_mover
            // 
            tmr_mover.Interval = 50;
            tmr_mover.Tick += tmr_mover_Tick;
            // 
            // lbl_estado
            // 
            lbl_estado.AutoSize = true;
            lbl_estado.Location = new Point(12, 495);
            lbl_estado.Name = "lbl_estado";
            lbl_estado.Size = new Size(54, 20);
            lbl_estado.TabIndex = 9;
            lbl_estado.Text = "Estado";
            // 
            // txt_estado
            // 
            txt_estado.Location = new Point(105, 492);
            txt_estado.Name = "txt_estado";
            txt_estado.Size = new Size(75, 27);
            txt_estado.TabIndex = 10;
            // 
            // tmr_verificar
            // 
            tmr_verificar.Enabled = true;
            tmr_verificar.Interval = 50;
            tmr_verificar.Tick += tmr_verificar_Tick;
            // 
            // tmr_esperar
            // 
            tmr_esperar.Interval = 3000;
            tmr_esperar.Tick += tmr_esperar_Tick;
            // 
            // txt_atendiendo
            // 
            txt_atendiendo.Location = new Point(105, 525);
            txt_atendiendo.Name = "txt_atendiendo";
            txt_atendiendo.Size = new Size(75, 27);
            txt_atendiendo.TabIndex = 12;
            // 
            // lbl_atendiendo
            // 
            lbl_atendiendo.AutoSize = true;
            lbl_atendiendo.Location = new Point(12, 528);
            lbl_atendiendo.Name = "lbl_atendiendo";
            lbl_atendiendo.Size = new Size(87, 20);
            lbl_atendiendo.TabIndex = 11;
            lbl_atendiendo.Text = "Atendiendo";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 633);
            Controls.Add(txt_atendiendo);
            Controls.Add(lbl_atendiendo);
            Controls.Add(txt_estado);
            Controls.Add(lbl_estado);
            Controls.Add(grb_estado);
            Controls.Add(grb_pisos);
            Controls.Add(grb_rango);
            Controls.Add(lbl_identificadores_restante);
            Controls.Add(lbl_uni_facu);
            Name = "Form1";
            Text = "Form1";
            grb_rango.ResumeLayout(false);
            grb_rango.PerformLayout();
            grb_pisos.ResumeLayout(false);
            grb_pisos.PerformLayout();
            grb_estado.ResumeLayout(false);
            grb_estado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_uni_facu;
        private Label lbl_identificadores_restante;
        private GroupBox grb_rango;
        private TextBox txt_hasta;
        private Label lbl_hasta;
        private TextBox txt_desde;
        private Label lbl_desde;
        private GroupBox grb_pisos;
        private RadioButton rb_pares;
        private RadioButton rb_todos;
        private RadioButton rb_impares;
        private GroupBox grb_estado;
        private RadioButton rb_mantenimiento;
        private RadioButton rb_apagado;
        private RadioButton rb_encendido;
        private System.Windows.Forms.Timer tmr_mover;
        private Label lbl_estado;
        private TextBox txt_estado;
        private System.Windows.Forms.Timer tmr_verificar;
        private System.Windows.Forms.Timer tmr_esperar;
        private TextBox txt_atendiendo;
        private Label lbl_atendiendo;
    }
}