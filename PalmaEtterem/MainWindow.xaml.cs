using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PalmaEtterem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Desszert> desszertek = new();
        public MainWindow()
        {
            InitializeComponent();
            using StreamReader sr = new(
                path: @"..\..\..\src\palma.txt",
                encoding: UTF32Encoding.UTF8);
            while (!sr.EndOfStream) desszertek.Add(new(sr.ReadLine()));
            //2. feladat
            Random random = new Random();
            int rnd = random.Next(desszertek.Count());
            Ajanlas.Content = "Mai ajánlatunk: " + desszertek[Convert.ToInt32(rnd)].Nev;
           // kep = desszertek.Where(d => d.Nev);
            //3. feladat
            Legdragabb.Content = desszertek.MaxBy(d => d.Ar).Nev.ToString();
            LegdragabbAra.Content = desszertek.MaxBy(d => d.Ar).Ar.ToString() + " Ft";
            Legolcsobb.Content = desszertek.MinBy(d => d.Ar).Nev.ToString();
            LegolcsobbAra.Content = desszertek.MinBy(d => d.Ar).Ar.ToString() + " Ft";
            //Tipus.Text = desszertek.Where(d => d.Tipus);

            //4. feladat
            Dijas.Content = desszertek.Where(d => d.Dijazott == true).Count().ToString() + " féle díjnyertes édességből választhat!";


            //5. feladat
            var KiirasLista = desszertek.Select(l => $"{l.Nev} {l.Tipus}").Distinct();
            File.WriteAllLines(@"..\..\..\src\lista.txt", KiirasLista);

            //6. feladat
            var stat = desszertek
                .GroupBy(s => s.Tipus)
                .Select(s => new { tipus = s.Key, mennyiseg = s.Count() });
                using (StreamWriter writer = new StreamWriter(@"..\..\..\src\stat.txt"))
                    {
                        foreach (var item in stat)
                        {
                            writer.WriteLine($"{ item.tipus}-{item.mennyiseg}");
                        }
                    };
         
            //7. feladat
        
        }

        private void SutiFelvetel_Click(object sender, RoutedEventArgs e)
        {
            string UjSutiNev = SutiNev.Text;
            string UjSutiTipus = SutiNev.Text;
            string UjSutiEgyseg = SutiNev.Text;
            string UjSutiAr = SutiNev.Text;
            bool UjSutiDijazott = false;
            if (SutiDijazott.IsChecked == true)
            {
                UjSutiDijazott = true;
            }
            else {
                UjSutiDijazott = false;
            }
        }

        private void Tipus_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}