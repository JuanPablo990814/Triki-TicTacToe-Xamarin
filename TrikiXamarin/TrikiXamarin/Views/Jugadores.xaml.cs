using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Toast;

namespace TrikiXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Jugadores : ContentPage
    {
        Controlador.Controlador var = new Controlador.Controlador();

        public Jugadores()
        {
            InitializeComponent();
            
        }

        public void escoger(int i, int j)
        {
            if (var.matrix[i, j] != null)
            {
                //MessageBox.Show("Ya fue escogido", "Porfavor", MessageBoxButtons.OK);
            }
            else
            {
                if (var.jugador == "uno")
                {
                    var.jugador = "dos";
                    lblJugador.Text = "2";
                    var.texto = "x";
                    var.matrix[i, j] = "x";
                }
                else
                {
                    var.jugador = "uno";
                    lblJugador.Text = "1";
                    var.texto = "o";
                    var.matrix[i, j] = "o";
                }
            }
        }

        public void validar()
        {
            
            var.validar();
            if (var.ganar1)
            {
                //instalar el plugin den Nuget de pluginToast de iShrak El Andoloussi
                CrossToastPopUp.Current.ShowToastMessage("El jugador 1 Gana");
                reiniciar();
            }
            if (var.ganar2)
            {
                CrossToastPopUp.Current.ShowToastMessage("El jugador 2 Gana");
                reiniciar();
            }
        }

        public void reiniciar()
        {
            Navigation.RemovePage(this);
            ((NavigationPage)this.Parent).PushAsync(new Views.Jugadores());
        }

        public void reiniciarlleno()
        {
            var.reiniciar();
            if (var.matrixllena)
            {
                Navigation.RemovePage(this);
                ((NavigationPage)this.Parent).PushAsync(new Views.Jugadores());
            }
        }

        private void btn00_Clicked(object sender, EventArgs e)
        {
            var.texto = btn00.Text;
            escoger(0, 0);
            btn00.Text = var.texto;
            validar();
            reiniciarlleno();
        }
        private void btn01_Clicked(object sender, EventArgs e)
        {
            var.texto = btn01.Text;
            escoger(0, 1);
            btn01.Text = var.texto;
            validar();
            reiniciarlleno();
        }

        private void btn02_Clicked(object sender, EventArgs e)
        {
            var.texto = btn02.Text;
            escoger(0, 2);
            btn02.Text = var.texto;
            validar();
            reiniciarlleno();
        }

        private void btn10_Clicked(object sender, EventArgs e)
        {
            var.texto = btn10.Text;
            escoger(1, 0);
            btn10.Text = var.texto;
            validar();
            reiniciarlleno();
        }

        private void btn11_Clicked(object sender, EventArgs e)
        {
            var.texto = btn11.Text;
            escoger(1, 1);
            btn11.Text = var.texto;
            validar();
            reiniciarlleno();
        }

        private void btn12_Clicked(object sender, EventArgs e)
        {
            var.texto = btn12.Text;
            escoger(1, 2);
            btn12.Text = var.texto;
            validar();
            reiniciarlleno();
        }

        private void btn20_Clicked(object sender, EventArgs e)
        {
            var.texto = btn20.Text;
            escoger(2, 0);
            btn20.Text = var.texto;
            validar();
            reiniciarlleno();
        }

        private void btn21_Clicked(object sender, EventArgs e)
        {
            var.texto = btn21.Text;
            escoger(2, 1);
            btn21.Text = var.texto;
            validar();
            reiniciarlleno();
        }

        private void btn22_Clicked(object sender, EventArgs e)
        {
            var.texto = btn22.Text;
            escoger(2, 2);
            btn22.Text = var.texto;
            validar();
            reiniciarlleno();
        }
        
    }
}