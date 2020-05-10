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
    public partial class Dificultad : ContentPage
    {
        private Controlador.Controlador var = new Controlador.Controlador();
        private Maquina juego;
        public Imposible Demon;

        public Dificultad()
        {
            InitializeComponent();
        }


        private void btnFacil_Click(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(juego = new Views.Maquina());
            var.dificultad = "Facil";
            juego.lblDificultad.Text = "Facil";
            juego.imagen.Source = "facil.png";
        }

        private void btnMedio_Click(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(juego = new Views.Maquina());
            var.dificultad = "Medio";
            juego.lblDificultad.Text = "Medio";
            juego.imagen.Source = "medio.png";
        }
        private void btnDificil_Click(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(juego = new Views.Maquina());
            var.dificultad = "Dificil";
            juego.lblDificultad.Text = "Dificil";
            juego.imagen.Source = "dificil.png";
            
        }

        private void btnImposible_Click(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(Demon = new Views.Imposible());
            var.dificultad = "Imposible";
            Demon.lblDificultad.Text = "Imposible";
        }
    }
}