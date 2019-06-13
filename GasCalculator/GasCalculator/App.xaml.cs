using GasCalculator.Entities;
using GasCalculator.Storage;
using System.Configuration;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Windows;

namespace GasCalculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string dbFileName = ConfigurationManager.AppSettings["DatabaseFileName"];
            if (!File.Exists(dbFileName))
            {
                var sqlEngine = new SqlCeEngine(ConfigurationManager.ConnectionStrings["GasCalculatorContext"].ConnectionString);
                sqlEngine.CreateDatabase();
            }

            var pendingMigrations = DataContext.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                DataContext.UpdateDatabase();
            }

            using (var db = new DataContext())
            {
                if (!db.Gases.Any())
                {
                    var aceton = new Gas() { Name = "Aceton", Factor = 0.9M, DGW = 2.5M, GGW = 13.0M, Consistency = 2.0M, Description = "Wysoce łatwopalna ciecz i pary. Działa drażniąco na oczy. Może wywoływać uczucie senności lub zawroty głowy" };
                    db.Gases.Add(aceton);

                    var acetylen = new Gas() { Name = "Acetylen", Factor = 0.7M, DGW = 2.5M, GGW = 80M, Consistency = 0.91M, Description = "Skrajnie łatwopalny gaz. Może reagować wybuchowo nawet bez dostępu powietrza. Zawiera gaz pod ciśnieniem ogrzanie grozi wybuchem. W wysokich stężeniach może spowodować uduszenie" };
                    db.Gases.Add(acetylen);

                    var benzen = new Gas() { Name = "Benzen", Factor = 1M, DGW = 1.2M, GGW = 8.0M, Consistency = 0.87M  , Description = "Wysoce łatwopalna ciecz i pary. Działa szkodliwie po połknięciu. Działa drażniąco na skórę. Działa drażniąco na oczy. Może powodować wady genetyczne. Może powodować raka. Połknięcie i dostanie się przez drogi oddechowe może grozić śmiercią. Powoduje uszkodzenie narządów poprzez długotrwałe lub powtarzane narażenie" };
                    db.Gases.Add(benzen);

                    var butan = new Gas() { Name = "butan", Factor = 0.93M, DGW = 1.9M, GGW = 8.4M, Consistency = 2.11M, Description = "Gaz pod ciśnieniem. Skrajnie łatwopalny." };
                    db.Gases.Add(butan);

                    var etan = new Gas() { Name = "Etan", Factor = 0.7M, DGW = 3M, GGW = 12.5M, Consistency = 1.05M, Description = " Skrajnie łatwopalny gaz. Zawiera gaz pod ciśnieniem ogrzanie grozi" };
                    db.Gases.Add(etan);

                    var etanol = new Gas() { Name = "Etanol", Factor = 0.74M, DGW = 3.3M, GGW = 27.7M, Consistency = 1.59M, Description = "Łatwopalna ciecz i pary. W ogniu oraz w razie ogrzania dochodzi do wzrostu ciśnienia i pojemnik może pęknąć, co stwarza ryzyko eksplozji. Wyciek do kanalizacji może spowodować pożar lub niebezpieczeństwo wybuchu. Produkty rozkładu mogą zawierać tlenki węgla." };
                    db.Gases.Add(etanol);

                    var etylen = new Gas() { Name = "Etylen", Factor = 0.7M, DGW = 2.7M, GGW = 32.6M, Consistency = 0.98M, Description = "Skrajnie łatwopalny gaz. Zawiera gaz pod ciśnieniem ogrzanie grozi wybuchem. Może wywoływać uczucie senności lub zawroty głowy." };
                    db.Gases.Add(etylen);

                    var heksan = new Gas() { Name = "Heksan", Factor = 1.42M, DGW = 1.1M, GGW = 8.1M, Consistency = 2.98M, Description = "Wysoce łatwopalna ciecz i pary. Działa drażniąco na skórę. Powoduje podrażnienie oczu Podejrzewa się, że działa szkodliwie na płodność. Połknięcie i dostanie się przez drogi oddechowe może grozić śmiercią. Może wywoływać uczucie senności lub zawroty głowy. Może powodować uszkodzenie narządów poprzez długotrwałe lub narażenie powtarzane. Działa toksycznie na organizmy wodne, powodując długotrwałe skutki." };
                    db.Gases.Add(heksan);

                    var wodor = new Gas() { Name = "Wodór", Factor = 0.47M, DGW = 4M, GGW = 74.2M, Consistency = 0.07M, Description = "Skrajnie łatwopalny gaz. Zawiera gaz pod ciśnieniem ogrzanie grozi wybuchem. W wysokich stężeniach może spowodować uduszenie" };
                    db.Gases.Add(wodor);

                    var izopropanol = new Gas() { Name = "Izopropanol", Factor = 1M, DGW = 2M, GGW = 12.0M, Consistency = 2.08M, Description = "Wysoce łatwopalna ciecz i pary. Działa drażniąco na oczy. Może wywoływać uczucie senności lub zawroty głowy" };
                    db.Gases.Add(izopropanol);

                    var metan = new Gas() { Name = "Metan", Factor = 0.5M, DGW = 5M, GGW = 14.0M, Consistency = 0.55M, Description = "Gaz łatwopalny. Gaz pod ciśnieniem ogrzanie grozi wybuchem. W wysokich stężeniach może spowodować uduszenie" };
                    db.Gases.Add(metan);

                    var metanol = new Gas() { Name = "Metanol", Factor = 0.6M, DGW = 6M, GGW = 44.0M, Consistency = 1.11M, Description = "Wysoce łatwopalna ciecz i pary. Działa toksycznie po połknięciu. Działa toksycznie w kontakcie ze skórą. Działa toksycznie w następstwie wdychania. Działa drażniąco na skórę. Działa drażniąco na oczy. Powoduje uszkodzenie narządów." };
                    db.Gases.Add(metanol);

                    var nonan = new Gas() { Name = "Nonan", Factor = 1.84M, DGW = 0.7M, GGW = 5.6M, Consistency = 4.43M, Description = "Łatwopalna ciecz i pary. Połknięcie i dostanie się przez drogi oddechowe może grozić śmiercią. Działa drażniąco na skórę. Działa drażniąco na oczy. Działa szkodliwie w następstwie wdychania. Może wywoływać uczucie senności lub zawroty głowy. Działa bardzo toksycznie na organizmy wodne, powodując długotrwałe skutki." };
                    db.Gases.Add(nonan);

                    var pentan = new Gas() { Name = "Pentan", Factor = 1M, DGW = 1.4M, GGW = 7.8M, Consistency = 2.49M, Description = "Wysoce łatwopalna ciecz i pary. Połknięcie i dostanie się przez drogi oddechowe może grozić śmiercią. Może wywoływać uczucie senności lub zawroty głowy. Działa toksycznie " };
                    db.Gases.Add(pentan);
                    
                    var propan = new Gas() { Name = "Propan", Factor = 0.8M, DGW = 2.1M, GGW = 9.5M, Consistency = 1.55M, Description = "Substancja skrajnie łatwopalna. Zawiera gaz pod ciśnieniem. Substancja tworzy palne i wybuchowe mieszaniny z powietrzem." };
                    db.Gases.Add(propan);
                    
                    var styren = new Gas() { Name = "Styren", Factor = 1.1M, DGW = 0.9M, GGW = 8.0M, Consistency = 3.6M, Description = "Łatwopalna ciecz i pary. Działa szkodliwie w następstwie wdychania. Działa drażniąco na skórę. Działa drażniąco na oczy" };
                    db.Gases.Add(styren);
                    
                    var toluen = new Gas() { Name = "Toluen", Factor = 1.26M, DGW = 1.1M, GGW = 7.8M, Consistency = 3.18M, Description = "Wysoce łatwopalna ciecz i pary. Działa drażniąco na skórę. Podejrzewa się, że działa szkodliwie na płód. Połknięcie i dostanie się przez drogi oddechowe może grozić śmiercią. Może wywoływać uczucie senności lub zawroty głowy. Może powodować uszkodzenie narządów poprzez długotrwałe lub narażenie powtarzane." };
                    db.Gases.Add(toluen);

                    var ksylen = new Gas() { Name = "Ksylen", Factor = 1.3M, DGW = 1.1M, GGW = 8.0M, Consistency = 3.67M, Description = "Łatwopalna ciecz i pary.Działa szkodliwie w kontakcie ze skórą.Działa szkodliwie w następstwie wdychania.Działa drażniąco na skórę." };
                    db.Gases.Add(ksylen);
                    
                    db.SaveChanges();
                }
            }
        }
    }
}
