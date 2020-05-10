using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrikiXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Imposible : ContentPage
    {
        Controlador.Controlador var;
        bool invalido;
        bool escogido;
        int contador = 1;
        private Imposible juego;

        public Imposible()
        {
            InitializeComponent();
            var = new Controlador.Controlador();
            mtPrimerMov();
        }

        private void escoger(int i, int j)
        {
            if (var.matrix[i, j] != null)
            {
                CrossToastPopUp.Current.ShowToastMessage("Ya fue escogido");
                invalido = true;
                escogido = true;

            }
            else
            {
                //var.jugador = "dos";
                var.texto = "x";
                var.matrix[i, j] = "x";
                invalido = false;
                escogido = false;
            }
        }
        public void mtPrimerMov()
        {
            int num = 0;
            Random r = new Random();
            num = r.Next(1, 4);

            switch (num)
            {
                case 1:
                    btn00.Text = "o";
                    var.matrix[0, 0] = "o";
                    break;
                case 2:
                    btn02.Text = "o";
                    var.matrix[0, 2] = "o";
                    break;
                case 3:
                    btn20.Text = "o";
                    var.matrix[2, 0] = "o";
                    break;
                case 4:
                    btn22.Text = "o";
                    var.matrix[2, 2] = "o";
                    break;

                default:
                    CrossToastPopUp.Current.ShowToastMessage("Error");
                    break;
            }
        }

        public void buscarBoton(int i, int j)
        {
            if (i == 0 && j == 0)
            {
                btn00.Text = "o";
            }
            if (i == 0 && j == 1)
            {
                btn01.Text = "o";
            }
            if (i == 0 && j == 2)
            {
                btn02.Text = "o";
            }
            if (i == 1 && j == 0)
            {
                btn10.Text = "o";
            }
            if (i == 1 && j == 1)
            {
                btn11.Text = "o";
            }
            if (i == 1 && j == 2)
            {
                btn12.Text = "o";

            }
            if (i == 2 && j == 0)
            {
                btn20.Text = "o";
            }
            if (i == 2 && j == 1)
            {
                btn21.Text = "o";
            }
            if (i == 2 && j == 2)
            {
                btn22.Text = "o";
            }
        }

        public void mtMaquinaFacil()
        {
            int i, j;
            Random r = new Random();
            i = r.Next(0, 3);
            j = r.Next(0, 3);

            while (var.matrix[i, j] != null)
            {
                Random l = new Random();
                i = l.Next(0, 3);
                j = l.Next(0, 3);
            }

            var.matrix[i, j] = "o";
            buscarBoton(i, j);

            //MessageBox.Show("i "+i+"j "+j);
        }

        public void validar()
        {
            var.validar();
            if (var.ganar1)
            {
                CrossToastPopUp.Current.ShowToastMessage("Ganaste");
                //this.Close();
                reiniciar();
                var.tamaño = 0;
                var.gano = true;
            }
            if (var.ganar2)
            {
                CrossToastPopUp.Current.ShowToastMessage("La Maquina Gana");
                reiniciar();
                var.tamaño = 0;
                var.gano = true;
            }
        }

        public void reiniciar()
        {
            var.dificultad = lblDificultad.Text;
            Navigation.RemovePage(this);
            ((NavigationPage)this.Parent).PushAsync(juego = new Views.Imposible());
            juego.lblDificultad.Text = var.dificultad;
        }

        public void reiniciarlleno()
        {
            var.reiniciar();
            if (var.matrixllena)
            {
                if (!var.gano)
                {
                    var.dificultad = lblDificultad.Text;
                    Navigation.RemovePage(this);
                    ((NavigationPage)this.Parent).PushAsync(juego = new Views.Imposible());
                    juego.lblDificultad.Text = var.dificultad;
                }

            }
        }

        public void mtImposible()
        {   //       ox ox ox ox
            //turnos 12 34 56 78
            //1 3 5 7
            if (contador == 3)
            {
                //mtDefensayOfensivaInteligenteMov2();
                //mtDefensayOfensivaInteligente();
                mtMov3();
            }
            else
            {
                if (contador == 5)
                {
                    mtRespuestaInteligente6();
                    //mtDefensayOfensivaInteligente();
                }
                else
                {
                    if (contador == 7)
                    {
                        mtMov7();
                    }
                    else
                    {
                        CrossToastPopUp.Current.ShowToastMessage("Error");
                    }

                }
            }
        }



        private void btn00_Clicked(object sender, EventArgs e)
        {
            escoger(0, 0);
            if (!escogido)
            {
                contador++;
                btn00.Text = var.texto;
            }
            validar();
            reiniciarlleno();

            //maquina
            if (!invalido)
            {
                if (var.gano != true && !var.matrixllena)
                {
                    contador++;
                    mtImposible();
                    validar();
                    reiniciarlleno();
                }
            }
        }

        private void btn01_Clicked(object sender, EventArgs e)
        {
            escoger(0, 1);
            if (!escogido)
            {
                contador++;
                btn01.Text = var.texto;
            }
            validar();
            reiniciarlleno();

            //maquina
            if (!invalido)
            {
                if (var.gano != true && !var.matrixllena)
                {
                    contador++;
                    mtImposible();
                    validar();
                    reiniciarlleno();
                }
            }
        }

        private void btn02_Clicked(object sender, EventArgs e)
        {
            escoger(0, 2);
            if (!escogido)
            {
                contador++;
                btn02.Text = var.texto;
            }
            validar();
            reiniciarlleno();

            //maquina
            if (!invalido)
            {
                if (var.gano != true && !var.matrixllena)
                {
                    contador++;
                    mtImposible();
                    validar();
                    reiniciarlleno();
                }
            }
        }

        private void btn10_Clicked(object sender, EventArgs e)
        {
            escoger(1, 0);
            if (!escogido)
            {
                contador++;
                btn10.Text = var.texto;
            }
            validar();
            reiniciarlleno();

            //maquina
            if (!invalido)
            {
                if (var.gano != true && !var.matrixllena)
                {
                    contador++;
                    mtImposible();
                    validar();
                    reiniciarlleno();
                }
            }
        }

        private void btn11_Clicked(object sender, EventArgs e)
        {
            escoger(1, 1);
            if (!escogido)
            {
                contador++;
                btn11.Text = var.texto;
            }
            validar();
            reiniciarlleno();

            //maquina
            if (!invalido)
            {
                if (var.gano != true && !var.matrixllena)
                {
                    contador++;
                    mtImposible();
                    validar();
                    reiniciarlleno();
                }
            }
        }

        private void btn12_Clicked(object sender, EventArgs e)
        {
            escoger(1, 2);
            if (!escogido)
            {
                contador++;
                btn12.Text = var.texto;
            }
            validar();
            reiniciarlleno();

            //maquina
            if (!invalido)
            {
                if (var.gano != true && !var.matrixllena)
                {
                    contador++;
                    mtImposible();
                    validar();
                    reiniciarlleno();
                }
            }
        }

        private void btn20_Clicked(object sender, EventArgs e)
        {
            escoger(2, 0);
            if (!escogido)
            {
                contador++;
                btn20.Text = var.texto;
            }
            validar();
            reiniciarlleno();

            //maquina
            if (!invalido)
            {
                if (var.gano != true && !var.matrixllena)
                {
                    contador++;
                    mtImposible();
                    validar();
                    reiniciarlleno();
                }
            }
        }

        private void btn21_Clicked(object sender, EventArgs e)
        {
            escoger(2, 1);
            if (!escogido)
            {
                contador++;
                btn21.Text = var.texto;
            }
            validar();
            reiniciarlleno();

            //maquina
            if (!invalido)
            {
                if (var.gano != true && !var.matrixllena)
                {
                    contador++;
                    mtImposible();
                    validar();
                    reiniciarlleno();
                }
            }
        }

        private void btn22_Clicked(object sender, EventArgs e)
        {
            escoger(2, 2);
            if (!escogido)
            {
                contador++;
                btn22.Text = var.texto;
            }
            validar();
            reiniciarlleno();

            //maquina
            if (!invalido)
            {
                if (var.gano != true && !var.matrixllena)
                {
                    contador++;
                    mtImposible();
                    validar();
                    reiniciarlleno();
                }
            }
        }

        public void mtMov3()
        {
            if (var.matrix[0, 0] == "o")
            {
                if (var.matrix[0, 2] == null && var.matrix[0, 1] != "x")
                {
                    var.matrix[0, 2] = "o";
                    buscarBoton(0, 2);
                }
                else
                {
                    if (var.matrix[2, 2] == null && var.matrix[1, 1] != "x")
                    {
                        var.matrix[2, 2] = "o";
                        buscarBoton(2, 2);
                    }
                    else
                    {
                        if (var.matrix[2, 0] == null && var.matrix[1, 0] != "x")
                        {
                            var.matrix[2, 0] = "o";
                            buscarBoton(2, 0);
                        }
                        else
                        {
                            mtMaquinaFacil();
                        }
                    }
                }
            }
            else
            {
                if (var.matrix[0, 2] == "o")
                {
                    if (var.matrix[0, 0] == null && var.matrix[0, 1] != "x")
                    {
                        var.matrix[0, 0] = "o";
                        buscarBoton(0, 0);
                    }
                    else
                    {
                        if (var.matrix[2, 2] == null && var.matrix[1, 2] != "x")
                        {
                            var.matrix[2, 2] = "o";
                            buscarBoton(2, 2);
                        }
                        else
                        {
                            if (var.matrix[2, 0] == null && var.matrix[1, 1] != "x")
                            {
                                var.matrix[2, 0] = "o";
                                buscarBoton(2, 0);
                            }
                            else
                            {
                                mtMaquinaFacil();
                            }
                        }
                    }
                }
                else
                {
                    if (var.matrix[2, 0] == "o")
                    {
                        if (var.matrix[0, 0] == null && var.matrix[1, 0] != "x")
                        {
                            var.matrix[0, 0] = "o";
                            buscarBoton(0, 0);
                        }
                        else
                        {
                            if (var.matrix[2, 2] == null && var.matrix[2, 1] != "x")
                            {
                                var.matrix[2, 2] = "o";
                                buscarBoton(2, 2);
                            }
                            else
                            {
                                if (var.matrix[0, 2] == null && var.matrix[1, 1] != "x")
                                {
                                    var.matrix[0, 2] = "o";
                                    buscarBoton(0, 2);
                                }
                                else
                                {
                                    mtMaquinaFacil();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (var.matrix[2, 2] == "o")
                        {
                            if (var.matrix[2, 0] == null && var.matrix[2, 1] != "x")
                            {
                                var.matrix[2, 0] = "o";
                                buscarBoton(2, 0);
                            }
                            else
                            {
                                if (var.matrix[0, 2] == null && var.matrix[1, 2] != "x")
                                {
                                    var.matrix[0, 2] = "o";
                                    buscarBoton(0, 2);
                                }
                                else
                                {
                                    if (var.matrix[0, 0] == null && var.matrix[1, 1] != "x")
                                    {
                                        var.matrix[0, 0] = "o";
                                        buscarBoton(0, 0);
                                    }
                                    else
                                    {
                                        mtMaquinaFacil();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void mtMov7()
        {
            //00 01 02
            //10 11 12
            //20 21 22

            // o 01 o
            //10 11 12
            //o 21 22

            if (var.matrix[0, 0] == "o" && var.matrix[0, 2] == "o" && var.matrix[2, 0] == "o")
            {
                if (var.matrix[0, 1] == null)
                {
                    var.matrix[0, 1] = "o";
                    buscarBoton(0, 1);
                }
                else
                {
                    if (var.matrix[1, 0] == null)
                    {
                        var.matrix[1, 0] = "o";
                        buscarBoton(1, 0);
                    }
                    else
                    {
                        if (var.matrix[1, 1] == null)
                        {
                            var.matrix[1, 1] = "o";
                            buscarBoton(1, 1);
                        }
                    }
                }
            }
            else
            {
                // o 01 02
                //10 11 12
                // o 21 o

                if (var.matrix[0, 0] == "o" && var.matrix[2, 0] == "o" && var.matrix[2, 2] == "o")
                {
                    if (var.matrix[2, 1] == null)
                    {
                        var.matrix[2, 1] = "o";
                        buscarBoton(2, 1);
                    }
                    else
                    {
                        if (var.matrix[1, 0] == null)
                        {
                            var.matrix[1, 0] = "o";
                            buscarBoton(1, 0);
                        }
                        else
                        {
                            if (var.matrix[1, 1] == null)
                            {
                                var.matrix[1, 1] = "o";
                                buscarBoton(1, 1);
                            }
                            else
                            {
                                mtMaquinaFacil();
                            }
                        }
                    }
                }
                else
                {
                    //00 01 o
                    //10 11 12
                    // o 21 o
                    if (var.matrix[0, 2] == "o" && var.matrix[2, 0] == "o" && var.matrix[2, 2] == "o")
                    {
                        if (var.matrix[2, 1] == null)
                        {
                            var.matrix[2, 1] = "o";
                            buscarBoton(2, 1);
                        }
                        else
                        {
                            if (var.matrix[1, 2] == null)
                            {
                                var.matrix[1, 2] = "o";
                                buscarBoton(1, 2);
                            }
                            else
                            {
                                if (var.matrix[1, 1] == null)
                                {
                                    var.matrix[1, 1] = "o";
                                    buscarBoton(1, 1);
                                }
                                else
                                {
                                    mtMaquinaFacil();
                                }
                            }
                        }
                    }
                    else
                    {
                        // o 01 o
                        //10 11 12
                        //20 21 o
                        if (var.matrix[0, 0] == "o" && var.matrix[0, 2] == "o" && var.matrix[2, 2] == "o")
                        {
                            if (var.matrix[0, 1] == null)
                            {
                                var.matrix[0, 1] = "o";
                                buscarBoton(0, 1);
                            }
                            else
                            {
                                if (var.matrix[1, 2] == null)
                                {
                                    var.matrix[1, 2] = "o";
                                    buscarBoton(1, 2);
                                }
                                else
                                {
                                    if (var.matrix[1, 1] == null)
                                    {
                                        var.matrix[1, 1] = "o";
                                        buscarBoton(1, 1);
                                    }
                                    else
                                    {
                                        mtMaquinaFacil();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //revisado
        public void mtDefensayOfensivaInteligente()
        {
            // o  01 o
            // 10 11 12
            // 20 21 22

            if (var.matrix[0, 0] == "x" && var.matrix[0, 2] == "x")
            {
                //para ganar
                if (var.matrix[0, 1] == null)
                {
                    var.matrix[0, 1] = "o";
                    buscarBoton(0, 1);
                }
                else
                {
                    mtRespuestaInteligente6();
                }

            }
            else
            {
                if (var.matrix[0, 0] == "x" && var.matrix[2, 0] == "x")
                {
                    //para ganar
                    if (var.matrix[1, 0] == null)
                    {
                        var.matrix[1, 0] = "o";
                        buscarBoton(1, 0);
                    }
                    else
                    {
                        mtRespuestaInteligente6();
                    }
                }
                else
                {
                    if (var.matrix[0, 0] == "x" && var.matrix[2, 2] == "x")
                    {
                        //para ganar
                        if (var.matrix[1, 1] == null)
                        {
                            var.matrix[1, 1] = "o";
                            buscarBoton(1, 1);
                        }
                        else { mtRespuestaInteligente6(); }

                    }
                    else
                    {
                        if (var.matrix[2, 2] == "x" && var.matrix[0, 2] == "x")
                        {

                            //para ganar
                            if (var.matrix[1, 2] == null)
                            {
                                var.matrix[1, 2] = "o";
                                buscarBoton(1, 2);
                            }
                            else { mtRespuestaInteligente6(); }
                        }
                        else
                        {
                            if (var.matrix[2, 0] == "x" && var.matrix[2, 2] == "x")
                            {
                                //para ganar
                                if (var.matrix[2, 1] == null)
                                {
                                    var.matrix[2, 1] = "o";
                                    buscarBoton(2, 1);
                                }
                                else { mtRespuestaInteligente6(); }
                            }
                            else
                            {
                                if (var.matrix[0, 0] == "x" && var.matrix[0, 1] == "x")
                                {
                                    //para ganar
                                    if (var.matrix[0, 2] == null)
                                    {
                                        var.matrix[0, 2] = "o";
                                        buscarBoton(0, 2);
                                    }
                                    else { mtRespuestaInteligente6(); }

                                }
                                else
                                {
                                    if (var.matrix[0, 0] == "x" && var.matrix[1, 0] == "x")
                                    {
                                        //para ganar
                                        if (var.matrix[2, 0] == null)
                                        {
                                            var.matrix[2, 0] = "o";
                                            buscarBoton(2, 0);
                                        }
                                        else { mtRespuestaInteligente6(); }
                                    }
                                    else
                                    {
                                        if (var.matrix[0, 0] == "x" && var.matrix[1, 1] == "x")
                                        {
                                            if (var.matrix[2, 2] == null)
                                            {
                                                var.matrix[2, 2] = "o";
                                                buscarBoton(2, 2);
                                            }
                                            else { mtRespuestaInteligente6(); }

                                        }
                                        else
                                        {
                                            if (var.matrix[0, 1] == "x" && var.matrix[0, 2] == "x")
                                            {
                                                if (var.matrix[0, 0] == null)
                                                {
                                                    var.matrix[0, 0] = "o";
                                                    buscarBoton(0, 0);
                                                }
                                                else { mtRespuestaInteligente6(); }

                                            }
                                            else
                                            {
                                                if (var.matrix[0, 1] == "x" && var.matrix[1, 1] == "x")
                                                {
                                                    if (var.matrix[2, 1] == null)
                                                    {
                                                        var.matrix[2, 1] = "o";
                                                        buscarBoton(2, 1);
                                                    }
                                                    else { mtRespuestaInteligente6(); }
                                                }
                                                else
                                                {
                                                    if (var.matrix[0, 2] == "x" && var.matrix[1, 2] == "x")
                                                    {
                                                        if (var.matrix[2, 2] == null)
                                                        {
                                                            var.matrix[2, 2] = "o";
                                                            buscarBoton(2, 2);
                                                        }
                                                        else { mtRespuestaInteligente6(); }
                                                    }
                                                    else
                                                    {
                                                        if (var.matrix[0, 2] == "x" && var.matrix[1, 1] == "x")
                                                        {
                                                            if (var.matrix[2, 0] == null)
                                                            {
                                                                var.matrix[2, 0] = "o";
                                                                buscarBoton(2, 0);
                                                            }
                                                            else { mtRespuestaInteligente6(); }
                                                        }
                                                        else
                                                        {
                                                            if (var.matrix[1, 0] == "x" && var.matrix[1, 1] == "x")
                                                            {
                                                                if (var.matrix[1, 2] == null)
                                                                {
                                                                    var.matrix[1, 2] = "o";
                                                                    buscarBoton(1, 2);
                                                                }
                                                                else { mtRespuestaInteligente6(); }
                                                            }
                                                            else
                                                            {
                                                                if (var.matrix[1, 0] == "x" && var.matrix[2, 0] == "x")
                                                                {
                                                                    if (var.matrix[0, 0] == null)
                                                                    {
                                                                        var.matrix[0, 0] = "o";
                                                                        buscarBoton(0, 0);
                                                                    }
                                                                    else { mtRespuestaInteligente6(); }
                                                                }
                                                                else
                                                                {
                                                                    if (var.matrix[1, 1] == "x" && var.matrix[1, 2] == "x")
                                                                    {
                                                                        if (var.matrix[1, 0] == null)
                                                                        {
                                                                            var.matrix[1, 0] = "o";
                                                                            buscarBoton(1, 0);
                                                                        }
                                                                        else { mtRespuestaInteligente6(); }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (var.matrix[1, 1] == "x" && var.matrix[2, 1] == "x")
                                                                        {
                                                                            if (var.matrix[0, 1] == null)
                                                                            {
                                                                                var.matrix[0, 1] = "o";
                                                                                buscarBoton(0, 1);
                                                                            }
                                                                            else { mtRespuestaInteligente6(); }

                                                                        }
                                                                        else
                                                                        {
                                                                            if (var.matrix[2, 0] == "x" && var.matrix[1, 1] == "x")
                                                                            {
                                                                                if (var.matrix[0, 2] == null)
                                                                                {
                                                                                    var.matrix[0, 2] = "o";
                                                                                    buscarBoton(0, 2);
                                                                                }
                                                                                else { mtRespuestaInteligente6(); }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (var.matrix[2, 0] == "x" && var.matrix[2, 1] == "x")
                                                                                {
                                                                                    if (var.matrix[2, 2] == null)
                                                                                    {
                                                                                        var.matrix[2, 2] = "o";
                                                                                        buscarBoton(2, 2);
                                                                                    }
                                                                                    else { mtRespuestaInteligente6(); }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (var.matrix[2, 2] == "x" && var.matrix[1, 2] == "x")
                                                                                    {
                                                                                        if (var.matrix[0, 2] == null)
                                                                                        {
                                                                                            var.matrix[0, 2] = "o";
                                                                                            buscarBoton(0, 2);
                                                                                        }
                                                                                        else { mtRespuestaInteligente6(); }

                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (var.matrix[2, 2] == "x" && var.matrix[2, 1] == "x")
                                                                                        {
                                                                                            if (var.matrix[2, 0] == null)
                                                                                            {
                                                                                                var.matrix[2, 0] = "o";
                                                                                                buscarBoton(2, 0);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                mtRespuestaInteligente6();
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            mtMaquinaFacil();
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //revisado
        public void mtRespuestaInteligente6()
        {

            if (var.matrix[0, 0] == "o" && var.matrix[0, 2] == "o")
            {
                //para ganar
                if (var.matrix[0, 1] == null)
                {
                    var.matrix[0, 1] = "o";
                    buscarBoton(0, 1);
                }
                else
                {
                    if (var.matrix[2, 2] == null && var.matrix[1, 2] != "x")
                    {
                        var.matrix[2, 2] = "o";
                        buscarBoton(2, 2);
                    }
                    else
                    {
                        if (var.matrix[2, 0] == null && var.matrix[1, 1] != "x")
                        {
                            var.matrix[2, 0] = "o";
                            buscarBoton(2, 0);
                        }
                        else
                        {
                            if (var.matrix[1, 1] == null)
                            {
                                var.matrix[1, 1] = "o";
                                buscarBoton(1, 1);
                            }
                            else { mtMaquinaFacil(); }
                        }
                    }

                }

            }
            else
            {
                // o  01 02
                // 10 11 12
                // o  21 22

                if (var.matrix[0, 0] == "o" && var.matrix[2, 0] == "o")
                {
                    //para ganar
                    if (var.matrix[1, 0] == null)
                    {
                        var.matrix[1, 0] = "o";
                        buscarBoton(1, 0);
                    }
                    else
                    {
                        if (var.matrix[2, 2] == null && var.matrix[2, 1] != "x")
                        {
                            var.matrix[2, 2] = "o";
                            buscarBoton(2, 2);
                        }
                        else
                        {
                            if (var.matrix[0, 2] == null)
                            {
                                var.matrix[0, 2] = "o";
                                buscarBoton(0, 2);
                            }
                            else
                            {
                                if (var.matrix[1, 1] == null)
                                {
                                    var.matrix[1, 1] = "o";
                                    buscarBoton(1, 1);
                                }
                                else { mtMaquinaFacil(); }
                            }
                        }
                    }
                }
                else
                {
                    // o  01 02
                    // 10 11 12
                    // 20 21 o
                    //faltan por revisar
                    if (var.matrix[0, 0] == "o" && var.matrix[2, 2] == "o")
                    {
                        //para ganar
                        if (var.matrix[1, 1] == null)
                        {
                            var.matrix[1, 1] = "o";
                            buscarBoton(1, 1);
                        }
                        else
                        {
                            if (var.matrix[2, 0] == null)
                            {
                                var.matrix[2, 0] = "o";
                                buscarBoton(2, 0);
                            }
                            else
                            {
                                if (var.matrix[0, 2] == null)
                                {
                                    var.matrix[0, 2] = "o";
                                    buscarBoton(0, 2);
                                }
                                else
                                { mtMaquinaFacil(); }
                            }
                        }
                    }
                    else
                    {
                        // 00 01 o
                        // 10 11 12
                        // 20 21 o

                        if (var.matrix[2, 2] == "o" && var.matrix[0, 2] == "o")
                        {

                            //para ganar
                            if (var.matrix[1, 2] == null)
                            {
                                var.matrix[1, 2] = "o";
                                buscarBoton(1, 2);
                            }
                            else
                            {
                                if (var.matrix[2, 0] == null)
                                {
                                    var.matrix[2, 0] = "o";
                                    buscarBoton(2, 0);
                                }
                                else
                                {
                                    if (var.matrix[0, 2] == null)
                                    {
                                        var.matrix[0, 2] = "o";
                                        buscarBoton(0, 2);
                                    }
                                    else
                                    {
                                        mtMaquinaFacil();
                                    }
                                }
                            }

                        }
                        else
                        {
                            // 00 01 02
                            // 10 11 12
                            // o  21 o
                            if (var.matrix[2, 0] == "o" && var.matrix[2, 2] == "o")
                            {
                                //para ganar
                                if (var.matrix[2, 1] == null)
                                {
                                    var.matrix[2, 1] = "o";
                                    buscarBoton(2, 1);
                                }
                                else
                                {
                                    if (var.matrix[0, 0] == null && var.matrix[1, 0] != "x")
                                    {
                                        var.matrix[0, 0] = "o";
                                        buscarBoton(0, 0);
                                    }

                                    else
                                    {
                                        if (var.matrix[0, 2] == null)
                                        {
                                            var.matrix[0, 2] = "o";
                                            buscarBoton(0, 2);
                                        }

                                        else
                                        {
                                            if (var.matrix[1, 1] == null)
                                            {
                                                var.matrix[1, 1] = "o";
                                                buscarBoton(1, 1);
                                            }
                                            else { mtMaquinaFacil(); }

                                        }
                                    }
                                }
                            }
                            else
                            {
                                //parejas juntas
                                // o  o 02
                                // 10 11 12
                                // 20 21 22
                                if (var.matrix[0, 0] == "o" && var.matrix[0, 1] == "o")
                                {
                                    //para ganar
                                    if (var.matrix[0, 2] == null)
                                    {
                                        var.matrix[0, 2] = "o";
                                        buscarBoton(0, 2);
                                    }
                                    else
                                    {
                                        if (var.matrix[1, 1] == null)
                                        {
                                            var.matrix[1, 1] = "o";
                                            buscarBoton(1, 1);
                                        }
                                        else
                                        {
                                            if (var.matrix[2, 0] == null)
                                            {
                                                var.matrix[2, 0] = "o";
                                                buscarBoton(2, 0);
                                            }
                                            else
                                            {
                                                if (var.matrix[2, 1] == null)
                                                {
                                                    var.matrix[2, 1] = "o";
                                                    buscarBoton(2, 1);
                                                }
                                                else
                                                {
                                                    if (var.matrix[2, 2] == null)
                                                    {
                                                        var.matrix[2, 2] = "o";
                                                        buscarBoton(2, 2);
                                                    }
                                                    else { mtMaquinaFacil(); }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {

                                    if (var.matrix[0, 0] == "o" && var.matrix[1, 0] == "o")
                                    {
                                        //para ganar
                                        if (var.matrix[2, 0] == null)
                                        {
                                            var.matrix[2, 0] = "o";
                                            buscarBoton(2, 0);
                                        }
                                        else
                                        {
                                            if (var.matrix[1, 1] == null)
                                            {
                                                var.matrix[1, 1] = "o";
                                                buscarBoton(1, 1);
                                            }
                                            else
                                            {
                                                if (var.matrix[0, 1] == null)
                                                {
                                                    var.matrix[0, 1] = "o";
                                                    buscarBoton(0, 1);
                                                }
                                                else
                                                {
                                                    if (var.matrix[0, 2] == null)
                                                    {
                                                        var.matrix[0, 2] = "o";
                                                        buscarBoton(0, 2);
                                                    }
                                                    else
                                                    {
                                                        if (var.matrix[1, 2] == null)
                                                        {
                                                            var.matrix[1, 2] = "o";
                                                            buscarBoton(1, 2);
                                                        }
                                                        else { mtMaquinaFacil(); }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (var.matrix[0, 0] == "o" && var.matrix[1, 1] == "o")
                                        {
                                            if (var.matrix[2, 2] == null)
                                            {
                                                var.matrix[2, 2] = "o";
                                                buscarBoton(2, 2);
                                            }
                                            else
                                            {
                                                if (var.matrix[2, 0] == null)
                                                {
                                                    var.matrix[2, 0] = "o";
                                                    buscarBoton(2, 0);
                                                }
                                                else
                                                {
                                                    if (var.matrix[0, 2] == null)
                                                    {
                                                        var.matrix[0, 2] = "o";
                                                        buscarBoton(0, 2);
                                                    }
                                                    else
                                                    {
                                                        if (var.matrix[2, 1] == null)
                                                        {
                                                            var.matrix[2, 1] = "o";
                                                            buscarBoton(2, 1);
                                                        }
                                                        else { mtMaquinaFacil(); }
                                                    }
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (var.matrix[0, 1] == "o" && var.matrix[0, 2] == "o")
                                            {
                                                if (var.matrix[0, 0] == null)
                                                {
                                                    var.matrix[0, 0] = "o";
                                                    buscarBoton(0, 0);
                                                }
                                                else
                                                {
                                                    if (var.matrix[1, 1] == null)
                                                    {
                                                        var.matrix[1, 1] = "o";
                                                        buscarBoton(1, 1);
                                                    }
                                                    else
                                                    {
                                                        if (var.matrix[2, 1] == null)
                                                        {
                                                            var.matrix[2, 1] = "o";
                                                            buscarBoton(2, 1);
                                                        }
                                                        else
                                                        {
                                                            if (var.matrix[2, 2] == null)
                                                            {
                                                                var.matrix[2, 2] = "o";
                                                                buscarBoton(2, 2);
                                                            }
                                                            else { mtMaquinaFacil(); }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (var.matrix[0, 1] == "o" && var.matrix[1, 1] == "o")
                                                {
                                                    if (var.matrix[2, 1] == null)
                                                    {
                                                        var.matrix[2, 1] = "o";
                                                        buscarBoton(2, 1);
                                                    }
                                                    else
                                                    {
                                                        if (var.matrix[2, 0] == null)
                                                        {
                                                            var.matrix[2, 0] = "o";
                                                            buscarBoton(2, 0);
                                                        }
                                                        else
                                                        {
                                                            if (var.matrix[0, 2] == null)
                                                            {
                                                                var.matrix[0, 2] = "o";
                                                                buscarBoton(0, 2);
                                                            }
                                                            else
                                                            {
                                                                if (var.matrix[2, 2] == null)
                                                                {
                                                                    var.matrix[2, 2] = "o";
                                                                    buscarBoton(2, 2);
                                                                }
                                                                else { mtMaquinaFacil(); }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (var.matrix[0, 2] == "o" && var.matrix[1, 2] == "o")
                                                    {
                                                        if (var.matrix[2, 2] == null)
                                                        {
                                                            var.matrix[2, 2] = "o";
                                                            buscarBoton(2, 2);
                                                        }
                                                        else
                                                        {
                                                            if (var.matrix[2, 0] == null)
                                                            {
                                                                var.matrix[2, 0] = "o";
                                                                buscarBoton(2, 0);
                                                            }
                                                            else
                                                            {
                                                                if (var.matrix[1, 0] == null)
                                                                {
                                                                    var.matrix[1, 0] = "o";
                                                                    buscarBoton(1, 0);
                                                                }
                                                                else
                                                                {
                                                                    if (var.matrix[0, 0] == null)
                                                                    {
                                                                        var.matrix[0, 0] = "o";
                                                                        buscarBoton(0, 0);
                                                                    }
                                                                    else { mtMaquinaFacil(); }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (var.matrix[0, 2] == "o" && var.matrix[1, 1] == "o")
                                                        {
                                                            if (var.matrix[2, 0] == null)
                                                            {
                                                                var.matrix[2, 0] = "o";
                                                                buscarBoton(2, 0);
                                                            }
                                                            else
                                                            {
                                                                if (var.matrix[2, 2] == null)
                                                                {
                                                                    var.matrix[2, 2] = "o";
                                                                    buscarBoton(2, 2);
                                                                }
                                                                else
                                                                {
                                                                    if (var.matrix[0, 0] == null)
                                                                    {
                                                                        var.matrix[0, 0] = "o";
                                                                        buscarBoton(0, 0);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (var.matrix[1, 2] == null)
                                                                        {
                                                                            var.matrix[1, 2] = "o";
                                                                            buscarBoton(1, 2);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (var.matrix[1, 0] == null)
                                                                            {
                                                                                var.matrix[1, 0] = "o";
                                                                                buscarBoton(1, 0);
                                                                            }
                                                                            else { mtMaquinaFacil(); }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (var.matrix[1, 0] == "o" && var.matrix[1, 1] == "o")
                                                            {
                                                                if (var.matrix[1, 2] == null)
                                                                {
                                                                    var.matrix[1, 2] = "o";
                                                                    buscarBoton(1, 2);
                                                                }
                                                                else
                                                                {
                                                                    if (var.matrix[0, 2] == null)
                                                                    {
                                                                        var.matrix[0, 2] = "o";
                                                                        buscarBoton(0, 2);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (var.matrix[0, 1] == null)
                                                                        {
                                                                            var.matrix[0, 1] = "o";
                                                                            buscarBoton(0, 1);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (var.matrix[0, 0] == null)
                                                                            {
                                                                                var.matrix[0, 0] = "o";
                                                                                buscarBoton(0, 0);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (var.matrix[2, 2] == null)
                                                                                {
                                                                                    var.matrix[2, 2] = "o";
                                                                                    buscarBoton(2, 2);
                                                                                }
                                                                                else { mtMaquinaFacil(); }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (var.matrix[1, 0] == "o" && var.matrix[2, 0] == "o")
                                                                {
                                                                    if (var.matrix[0, 0] == null)
                                                                    {
                                                                        var.matrix[0, 0] = "o";
                                                                        buscarBoton(0, 0);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (var.matrix[0, 2] == null)
                                                                        {
                                                                            var.matrix[0, 2] = "o";
                                                                            buscarBoton(0, 2);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (var.matrix[1, 2] == null)
                                                                            {
                                                                                var.matrix[1, 2] = "o";
                                                                                buscarBoton(1, 2);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (var.matrix[2, 2] == null)
                                                                                {
                                                                                    var.matrix[2, 2] = "o";
                                                                                    buscarBoton(2, 2);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (var.matrix[1, 1] == null)
                                                                                    {
                                                                                        var.matrix[1, 1] = "o";
                                                                                        buscarBoton(1, 1);
                                                                                    }
                                                                                    else { mtMaquinaFacil(); }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (var.matrix[1, 1] == "o" && var.matrix[1, 2] == "o")
                                                                    {
                                                                        if (var.matrix[1, 0] == null)
                                                                        {
                                                                            var.matrix[1, 0] = "o";
                                                                            buscarBoton(1, 0);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (var.matrix[2, 0] == null)
                                                                            {
                                                                                var.matrix[2, 0] = "o";
                                                                                buscarBoton(2, 0);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (var.matrix[0, 2] == null)
                                                                                {
                                                                                    var.matrix[0, 2] = "o";
                                                                                    buscarBoton(0, 2);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (var.matrix[0, 1] == null)
                                                                                    {
                                                                                        var.matrix[0, 1] = "o";
                                                                                        buscarBoton(0, 1);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (var.matrix[2, 1] == null)
                                                                                        {
                                                                                            var.matrix[2, 1] = "o";
                                                                                            buscarBoton(2, 1);
                                                                                        }
                                                                                        else { mtMaquinaFacil(); }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (var.matrix[1, 1] == "o" && var.matrix[2, 1] == "o")
                                                                        {
                                                                            if (var.matrix[0, 1] == null)
                                                                            {
                                                                                var.matrix[0, 1] = "o";
                                                                                buscarBoton(0, 1);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (var.matrix[0, 2] == null)
                                                                                {
                                                                                    var.matrix[0, 2] = "o";
                                                                                    buscarBoton(0, 2);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (var.matrix[2, 0] == null)
                                                                                    {
                                                                                        var.matrix[2, 0] = "o";
                                                                                        buscarBoton(2, 0);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (var.matrix[2, 2] == null)
                                                                                        {
                                                                                            var.matrix[2, 2] = "o";
                                                                                            buscarBoton(2, 2);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (var.matrix[0, 0] == null)
                                                                                            {
                                                                                                var.matrix[0, 0] = "o";
                                                                                                buscarBoton(0, 0);
                                                                                            }
                                                                                            else { mtMaquinaFacil(); }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (var.matrix[2, 0] == "o" && var.matrix[1, 1] == "o")
                                                                            {
                                                                                if (var.matrix[0, 2] == null)
                                                                                {
                                                                                    var.matrix[0, 2] = "o";
                                                                                    buscarBoton(0, 2);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (var.matrix[0, 0] == null)
                                                                                    {
                                                                                        var.matrix[0, 0] = "o";
                                                                                        buscarBoton(0, 0);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (var.matrix[2, 0] == null)
                                                                                        {
                                                                                            var.matrix[2, 0] = "o";
                                                                                            buscarBoton(2, 0);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (var.matrix[2, 1] == null)
                                                                                            {
                                                                                                var.matrix[2, 1] = "o";
                                                                                                buscarBoton(2, 1);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (var.matrix[1, 0] == null)
                                                                                                {
                                                                                                    var.matrix[1, 0] = "o";
                                                                                                    buscarBoton(1, 0);
                                                                                                }
                                                                                                else { mtMaquinaFacil(); }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (var.matrix[2, 0] == "o" && var.matrix[2, 1] == "o")
                                                                                {
                                                                                    if (var.matrix[2, 2] == null)
                                                                                    {
                                                                                        var.matrix[2, 2] = "o";
                                                                                        buscarBoton(2, 2);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (var.matrix[0, 2] == null)
                                                                                        {
                                                                                            var.matrix[0, 2] = "o";
                                                                                            buscarBoton(0, 2);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (var.matrix[1, 1] == null)
                                                                                            {
                                                                                                var.matrix[1, 1] = "o";
                                                                                                buscarBoton(1, 1);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (var.matrix[1, 0] == null)
                                                                                                {
                                                                                                    var.matrix[1, 0] = "o";
                                                                                                    buscarBoton(1, 0);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (var.matrix[0, 0] == null)
                                                                                                    {
                                                                                                        var.matrix[0, 0] = "o";
                                                                                                        buscarBoton(0, 0);
                                                                                                    }
                                                                                                    else { mtMaquinaFacil(); }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (var.matrix[2, 2] == "o" && var.matrix[1, 2] == "o")
                                                                                    {
                                                                                        if (var.matrix[0, 2] == null)
                                                                                        {
                                                                                            var.matrix[0, 2] = "o";
                                                                                            buscarBoton(0, 2);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (var.matrix[1, 1] == null)
                                                                                            {
                                                                                                var.matrix[1, 1] = "o";
                                                                                                buscarBoton(1, 1);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (var.matrix[1, 0] == null)
                                                                                                {
                                                                                                    var.matrix[1, 0] = "o";
                                                                                                    buscarBoton(1, 0);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (var.matrix[2, 0] == null)
                                                                                                    {
                                                                                                        var.matrix[2, 0] = "o";
                                                                                                        buscarBoton(2, 0);
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (var.matrix[0, 0] == null)
                                                                                                        {
                                                                                                            var.matrix[0, 0] = "o";
                                                                                                            buscarBoton(0, 0);
                                                                                                        }
                                                                                                        else { mtMaquinaFacil(); }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {


                                                                                        if (var.matrix[2, 2] == "o" && var.matrix[2, 1] == "o")
                                                                                        {
                                                                                            if (var.matrix[2, 0] == null)
                                                                                            {
                                                                                                var.matrix[2, 0] = "o";
                                                                                                buscarBoton(2, 0);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (var.matrix[1, 1] == null)
                                                                                                {
                                                                                                    var.matrix[1, 1] = "o";
                                                                                                    buscarBoton(1, 1);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (var.matrix[1, 2] == null)
                                                                                                    {
                                                                                                        var.matrix[1, 2] = "o";
                                                                                                        buscarBoton(1, 2);
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (var.matrix[0, 0] == null)
                                                                                                        {
                                                                                                            var.matrix[0, 0] = "o";
                                                                                                            buscarBoton(0, 0);
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (var.matrix[0, 2] == null)
                                                                                                            {
                                                                                                                var.matrix[0, 2] = "o";
                                                                                                                buscarBoton(0, 2);
                                                                                                            }
                                                                                                            else { mtMaquinaFacil(); }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            mtMaquinaFacil();
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }

        }
    }
}