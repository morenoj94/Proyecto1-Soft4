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
                btn_bajar.Tag = i+1;
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
            int pisoMayor = -1, pisoMenor = -1;

            for (int i = 0; i < v_llamadasSubir.Length; i++)
            {
                if (v_llamadasSubir[i])
                {
                    if (pisoMenor == -1)
                    {
                        pisoMenor = i;
                    }
                    pisoMayor = i;
                }
            }

            if (pisoMayor != -1)
            {
                atendiendo = "subir";

                if (pisoMayor > pisoAct)
                {
                    destino = pisoMayor;
                    dirY = 1;
                }
                else if (pisoMenor < pisoAct)
                {
                    destino = pisoMenor;
                    dirY = -1;
                }
                else
                {
                    destino = pisoAct;
                    dirY = 0;
                }
            }
        }



/*=================================
===================================
======= Logica para bajar. ========
===================================
===================================*/
        private void Btn_bajar_Click(object? sender, EventArgs e)
        {
            Button tmp = sender as Button;

            int piso = (int)tmp.Tag;

            v_llamadasBajar[piso] = true;
            tmp.BackColor = c_activo;
        }

/*====================================
======================================
======== Sin Actualizar ==============
======================================
======================================*/
        private void tmr_verificar_Tick(object sender, EventArgs e)
        {
            verificarsubir();
            verificarbajar();

        }
        private void verificarsubir()
        {
            bool llamadaSubir = false;

            for (int i = 0; i < v_btn_subir.Length; i++)
            {
                if (v_btn_subir[i].BackColor == c_activo)
                {
                    v_llamadasSubir[i] = true;

                    if (i > pisoActual)
                    { 
                        destino = i;
                        llamadaSubir = true;
                    }
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
        private void subir()
        {

            dirY = -1;
            btn_elevador.BackColor = c_moviendo;
            txt_estado.Text = "Subiendo";
            tmr_subir.Start();
        }
        private void tmr_subir_Tick(object sender, EventArgs e)
        {
            int x, y, piso;
            x = btn_elevador.Location.X;
            y = btn_elevador.Location.Y;

            piso = (430 - y) / 30;
            pisoActual = piso;

            btn_elevador.Text = piso.ToString();

            btn_elevador.Location = new Point(x, y + dirY);

            if (v_llamadasSubir[piso])
            {
                tmr_subir.Stop();
                dirY = 0;

                btn_elevador.BackColor = c_esperando;
                v_btn_subir[piso].BackColor = c_inactivo;
                v_llamadasSubir[piso] = false;

                tmr_esperar.Start();
            }

        }
        private void tmr_esperar_Tick(object sender, EventArgs e)
        {
            tmr_esperar.Stop();
            //btn_elevador.BackColor = c_activo;
            estado = 0;
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
                else
                    v_llamadasBajar[i] = false;

            }
            if (llamadaBajar && estado == 0)
            {
                estado = 1;
                bajar();
            }
        }
        private void bajar()
        {
            dirY = 1;
            btn_elevador.BackColor = c_moviendo;
            txt_estado.Text = "bajando";
            tmr_bajar.Start();
        }
        private void tmr_bajar_Tick(object sender, EventArgs e)
        {
            int x, y, piso, p;
            x = btn_elevador.Location.X;
            y = btn_elevador.Location.Y;

            piso = (430 - y) / 30;
            p = (430 + 29 - y) / 30;
            pisoActual = piso;

            btn_elevador.Text = p.ToString();

            btn_elevador.Location = new Point(x, y + dirY);

            if (v_llamadasBajar[piso] == true)
            {
                tmr_bajar.Stop();
                dirY = 0;

                btn_elevador.BackColor = c_esperando;
                v_btn_bajar[piso].BackColor = c_inactivo;
                v_llamadasBajar[piso] = false;

                tmr_esperar.Start();
            }
        }






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
        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            dirY = -1;
            tmr_mover.Start();
        }
        private void btn_parar_Click(object sender, EventArgs e)
        {
            dirY = 0;
            tmr_mover.Stop();
        }
        private void tmr_mover_Tick(object sender, EventArgs e)
        {
            int x, y;
            x = btn_elevador.Location.X;
            y = btn_elevador.Location.Y;

            btn_elevador.Location = new Point(x, y + dirY);

            compararPiso(y);

            if (btn_elevador.Location.Y == 430 || btn_elevador.Location.Y == 70)
            {
                dirY = -dirY;
            }


        }

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
        }



        */


    }
}