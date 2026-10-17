namespace Moreno_785_Proy1
{
    public partial class Form1 : Form
    {
        //Colores a usar
        Color c_activo = Color.FromArgb(167, 223, 242);
        Color c_inactivo = SystemColors.Control;
        Color c_moviendo = Color.FromArgb(177, 252, 167);
        Color c_esperando = Color.FromArgb(246, 252, 149);

        //Elementos generales
        Button btn_subir, btn_bajar, btn_elevador = new Button();
        Label lbl_piso;

        //Vectores
        Button[] v_btn_subir = new Button[12], v_btn_bajar = new Button[12];
        Label[] v_lbl_piso = new Label[13];
        bool[] v_llamadasSubir = new bool[12], v_llamadasBajar = new bool[12];

        //Variables sueltas
        int pisoAct = 0, destino = 0, dirY = 0;
        string estado = "detenido", atendiendo = "ninguno";
        int pisoMayor = -1, pisoMenor = -1;

        /*==================================
        ====================================
        ======== Inicia el programa. =======
        ====================================
        ====================================*/

        public Form1()
        {
            InitializeComponent();
            iniciar();
        }
        private void iniciar()
        {
            for (int i = 0; i <= 11; i++)
            {
                btn_subir = new Button();
                btn_subir.Size = new Size(60, 25);
                btn_subir.Location = new Point(115, 430 - (30 * i));
                btn_subir.Text = "Subir";
                btn_subir.Tag = i;
                btn_subir.Click += Btn_subir_Click;

                v_btn_subir[i] = btn_subir;


                btn_bajar = new Button();
                btn_bajar.Size = new Size(60, 25);
                btn_bajar.Location = new Point(210, 400 - (30 * i));
                btn_bajar.Text = "Bajar";
                btn_bajar.Tag = i + 1;
                btn_bajar.Click += Btn_bajar_Click;

                v_btn_bajar[i] = btn_bajar;


                this.Controls.Add(btn_bajar);
                this.Controls.Add(btn_subir);
            }


            for (int i = 0; i <= 12; i++)
            {
                lbl_piso = new Label();
                lbl_piso.Size = new Size(25, 25);
                lbl_piso.Location = new Point(180, 430 - (30 * i));
                lbl_piso.Text = i.ToString();

                v_lbl_piso[i] = lbl_piso;

                this.Controls.Add(lbl_piso);
            }

            btn_elevador.Size = new Size(40, 25);
            btn_elevador.Location = new Point(65, 430);
            btn_elevador.Text = "0";
            btn_elevador.BackColor = c_esperando;

            this.Controls.Add(btn_elevador);
        }
        private void tmr_verificar_Tick(object sender, EventArgs e)
        {
            revisarSubida();
            //verificarsubir();
            //verificarbajar();

        }
        private void tmr_mover_Tick(object sender, EventArgs e)
        {
            int x, y, piso;
            x = btn_elevador.Location.X;
            y = btn_elevador.Location.Y;

            calcularPiso();

            btn_elevador.BackColor = c_moviendo;
            btn_elevador.Location = new Point(x, y + dirY);
            
            if (atendiendo == "subir" && estado == "bajando")
                buscarpiso();
            else if (estado == "subiendo" && v_llamadasSubir[pisoAct])
                detenerPiso();


        }
        private void calcularPiso()
        {
            int y = btn_elevador.Location.Y;


            if (estado == "subiendo")
            {
                if ((430 - y) % 30 == 0)
                    pisoAct = (430 - y) / 30;
            }
            else if (estado == "bajando")
            {
                if ((430 - 30 - y) % 30 == 0)
                    pisoAct = (430 + 29 - y) / 30;
            }


            btn_elevador.Text = pisoAct.ToString();
        }
        private void detenerPiso()
        {
                tmr_mover.Stop();
                dirY = 0;
                estado = "detenido";
                txt_estado.Text = estado;

                btn_elevador.BackColor = c_esperando;
                v_btn_subir[pisoAct].BackColor = c_inactivo;
                v_llamadasSubir[pisoAct] = false;

                tmr_esperar.Start();
                tmr_verificar.Stop();
        }
        private void buscarpiso() 
        {
            if (pisoAct == pisoMenor)
            {
                detenerPiso();
            }
        }
        private void tmr_esperar_Tick(object sender, EventArgs e)
        {
            tmr_esperar.Stop();
            tmr_verificar.Start();

        }


        /*=================================
        ===================================
        ======= Logica para subir. ========
        ===================================
        ===================================*/
        private void Btn_subir_Click(object? sender, EventArgs e)
        {
            Button tmp = (Button)sender;

            int piso = (int)tmp.Tag;

            v_llamadasSubir[piso] = true;
            tmp.BackColor = c_activo;
        }
        private void revisarSubida()
        {
            pisoMayor = -1;
            pisoMenor = -1;

            for (int i = 0; i < v_llamadasSubir.Length; i++)
            {
                if (v_llamadasSubir[i])
                {

                    if (pisoMenor == -1)
                    {
                        atendiendo = "subir";
                        txt_atendiendo.Text = atendiendo;
                        pisoMenor = i;
                        txt_menor.Text = pisoMenor.ToString();
                    }
                    pisoMayor = i;
                    txt_mayor.Text = pisoMayor.ToString();
                }
            }
            definirDireccion();
        }
        private void definirDireccion()
        {
            if (atendiendo == "subir" && pisoMayor != -1)
            {
                if (estado == "detenido")
                {
                    if (pisoMayor > pisoAct )
                    {
                        //destino = pisoMayor;
                        dirY = -1;
                        estado = "subiendo";
                        txt_estado.Text = estado;
                        subir();
                    }
                    else if (pisoMayor < pisoAct)
                    {
                        //destino = pisoMenor;
                        dirY = 1;
                        estado = "bajando";
                        txt_estado.Text = estado;
                        subir();
                    }
                    else if (pisoMayor == -1)
                    {
                        //destino = pisoAct;
                        dirY = 0;
                    }
                }
                txt_destino.Text = destino.ToString();

            }
            else
                atendiendo = "ninguno";
        }

        private void subir()
        {

            btn_elevador.BackColor = c_moviendo;
            tmr_mover.Start();
        }



        /*=================================
        ===================================
        ======= Logica para bajar. ========
        ===================================
        ===================================*/
        private void Btn_bajar_Click(object? sender, EventArgs e)
        {
            Button tmp = sender as Button;

            int piso = ((int)tmp.Tag - 1);

            v_llamadasBajar[piso] = true;
            tmp.BackColor = c_activo;
        }

        /*====================================
        ======================================
        ======== Sin Actualizar ==============
        ======================================
        ======================================*/

        private void compararPiso(int y)
        {
            int piso;
            //i = (430 - y) * 30
            piso = (430 - y) / 30;
            btn_elevador.Text = piso.ToString();
            v_btn_subir[piso].BackColor = c_inactivo;

            //txt_estado.Text = y.ToString();

            /*
            for (int i = 0; i <= 12; i++)
            {
                if (y == v_lbl_piso[i].Location.Y)
                    btn_elevador.Text = i.ToString();
            }
            */
        }

        //Para pruebas


        /*
        private void verificarsubir()
        {
            bool llamadaSubir = false;

            for (int i = pisoActual + 1; i < v_btn_subir.Length; i++)
            {
                if (v_btn_subir[i].BackColor == c_activo)
                {
                    v_llamadasSubir[i] = true;
                    llamadaSubir = true;
                }
                else if (v_btn_bajar[i].BackColor == c_activo)
                {
                    v_llamadasBajar[i] = true;
                    llamadaSubir = true;
                }
                else
                    v_llamadasSubir[i] = false;
            }
            if (llamadaSubir && estado == 0)
            {
                estado = 1;
                subir();
            }
        }




        private void verificarbajar()
        {
            bool llamadaBajar = false;

            for (int i = pisoActual - 1; i >= 0; i--)
            {
                if (v_btn_bajar[i].BackColor == c_activo)
                {
                    v_llamadasBajar[i] = true;
                    llamadaBajar = true;
                }
                else if (v_btn_subir[i].BackColor == c_activo)
                {
                    v_llamadasSubir[i] = true;
                    llamadaBajar = true;
                }
                else
                    v_llamadasBajar[i] = false;

            }
            if (llamadaBajar && estado == 0)
            {
                estado = 1;
                bajar();
        }



        */


    }
}