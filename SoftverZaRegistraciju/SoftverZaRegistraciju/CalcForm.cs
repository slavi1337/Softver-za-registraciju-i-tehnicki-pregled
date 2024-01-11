using Microsoft.Web.WebView2.WinForms;
using System.Text;

namespace SoftverZaRegistraciju
{
    public partial class CalcForm : Form
    {
        private WebView2 webView;

        public CalcForm()
        {
            InitializeComponent();
            webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            this.Controls.Add(webView);
            webView.NavigationCompleted += webView21_NavigationCompleted;
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.Navigate("https://mbbanjaluka.com/home/calculator1/mkalkulator.php");
        }

        //funkcija koja cita .js skriptu liniju po liniju i onda izvrsava taj citav kod
        private void LoadJSfile(string putanja)
        {
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(putanja))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String? line;
                String? full = "";
                while ((line = streamReader.ReadLine()) != null)
                {
                    full += line;
                }
                webView.ExecuteScriptAsync(full);
            }
        }

        private void webView21_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            webView.Visible = false;
            // Sakrivanje sadržaja
            // Promena stila tela dokumenta
            // Pomeranje sadrzaja stranice ka gore (sakrivanje headera stranice)
            // Promena boje dugmeta za kalkulaciju
            LoadJSfile("C:\\Users\\Korisnik\\Desktop\\Softver Za Registraciju\\SoftverZaRegistraciju\\SoftverZaRegistraciju\\Scripts\\style.js");
            // Sakrivanje footera na stranici
            LoadJSfile("C:\\Users\\Korisnik\\Desktop\\Softver Za Registraciju\\SoftverZaRegistraciju\\SoftverZaRegistraciju\\Scripts\\removeFooter.js");
            // Sakrivanje dugmeta "pocetna"
            LoadJSfile("C:\\Users\\Korisnik\\Desktop\\Softver Za Registraciju\\SoftverZaRegistraciju\\SoftverZaRegistraciju\\Scripts\\removeButton1.js");
            // Sakrivanje naslova koji se pojave nakon racunanja na stranici
            LoadJSfile("C:\\Users\\Korisnik\\Desktop\\Softver Za Registraciju\\SoftverZaRegistraciju\\SoftverZaRegistraciju\\Scripts\\removeText.js");
            // Promena boje naslova h5 i h4 u plavu boju forme
            LoadJSfile("C:\\Users\\Korisnik\\Desktop\\Softver Za Registraciju\\SoftverZaRegistraciju\\SoftverZaRegistraciju\\Scripts\\changeHeader.js");
            // Uklanjanje modalnog dugmeta (dugme "Posalji upit" koje se pojavi nakon kalkulacije)
            LoadJSfile("C:\\Users\\Korisnik\\Desktop\\Softver Za Registraciju\\SoftverZaRegistraciju\\SoftverZaRegistraciju\\Scripts\\removeButton2.js");
            // Uklanjanje dugmeta za stampanje (dugme "Snimi u PDF" -||-)
            LoadJSfile("C:\\Users\\Korisnik\\Desktop\\Softver Za Registraciju\\SoftverZaRegistraciju\\SoftverZaRegistraciju\\Scripts\\removeButton3.js");
            // Primena stilova na odredjene elemente unutar diva 'results'
            LoadJSfile("C:\\Users\\Korisnik\\Desktop\\Softver Za Registraciju\\SoftverZaRegistraciju\\SoftverZaRegistraciju\\Scripts\\changeFontH.js");
            webView.Visible = true;
        }

        private void CalcForm_Load(object sender, EventArgs e)
        {
            webView.Visible = false;
        }
    }
}
