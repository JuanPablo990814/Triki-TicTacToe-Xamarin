using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrikiXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Dificultad dificultad = new Dificultad();
        private void btnMaquina_Click(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new Views.Dificultad());
            //Views.Dificultad dificultad = new Views.Dificultad();
            //Controlador.Controlador controlador = new Controlador.Controlador();
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Views.Jugadores());

            
        }
    }
}
