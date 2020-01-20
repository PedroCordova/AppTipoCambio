using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTipoCambio
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            double _DOF = ConexionBanxico._requestData();
            InitializeComponent();
            DateTime Fecha = DateTime.Today;
            lblTipo.Text = Fecha.ToString("dd-MM-yyyy");
            lblCambio.Text = "$ "+_DOF.ToString();
        }
    }
}
