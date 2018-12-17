using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility
{
       enum SoruDerece
       {
           Düsük,
           Orta,
           Yüksek,
       }
    class Program
    {     
        static void Main(string[] args)
        {
            // Önce zincire dahil olacak nesne örnekleri oluşturulur
            KisilerHandler handlerDanisman = new DanismanHandler();
            KisilerHandler handlerBolumBaskan = new BolumBaskanHandler();
            KisilerHandler handlerDekan = new Dekan();

            // Zincirde yer alan her bir nesne kendisinden sonra gelecek olan nesneyi belirler. 
            // Bu belirleme işlemi için Successor özelliği kullanılır.
            handlerDanisman.Successor = handlerDanisman;
            handlerBolumBaskan.Successor = handlerBolumBaskan;

            // Zincir halkasındaki nesneler tarafından kullanılacak olan nesne örneği oluşturulur.
            Soru info = new Soru { detay = "Düsük Seviyeli soru", derece = SoruDerece.Düsük };

            // Zincirin ilk halkasındaki nesneye, talep gönderilir.
            handlerDanisman.SurecTalebi(info);

            Console.ReadLine();
        }
    }

        //Zincirin içindeki nesnelerde dolasabilecek olan tip
        class Soru
        {
            public string detay { get; set; }
            public SoruDerece derece { get; set; }
        }
    //Handler
    abstract class KisilerHandler
    {
        protected KisilerHandler _successor;

        public abstract void SurecTalebi(Soru sbilgi);
        public KisilerHandler Successor
        {
            set
            {
                _successor = value;
            }
        }

        
    }
    // ConcreteHandler
    // Sorunun Dekan üzerinden olduğu durumu ele alır.
    // Sorumluluk zincirinin son sırasındaki tip
    class Dekan : KisilerHandler
    {
        public override void SurecTalebi(Soru sbilgi)
        {
            // Eğer Sorunun derecesi Yüksek ise bu tipe ait nesnenin sorumluluğundadır Eğer Yüksek değilse artık sernin son halkası olduğundan gidecek başka bir yer kalmamıştır. Buna uygun şekilde bir hareket yapılmalıdır.
            if (sbilgi.derece == SoruDerece.Yüksek)
                Console.WriteLine("Dekan hocası üzerinde olan bir soru.\n\t{0} için gerekli başlatma işlemleri yapılıyor.", sbilgi.detay);
            else
                Console.WriteLine("Uzaydan gelen bir servis mi bu yauv?");
        }
    }
    class BolumBaskanHandler : KisilerHandler
    {
        public override void SurecTalebi(Soru sbilgi)
        {
            // Eğer Sorunun derecesi Orta ise sorumluluk BolumBaskanHandler nesne örneğine aittir. Ancak değilse, zincirde bir sonraki tip olan DekanHandler' a ait SüreçTalebi metodu çağırılır.
            if (sbilgi.derece == SoruDerece.Orta)
                Console.WriteLine("Bolum Baskani hocası üzerinde olan bir soru.\n\t{0} için gerekli başlatma işlemleri yapılıyor.", sbilgi.detay);
            else if (_successor != null)
                _successor.SurecTalebi(sbilgi);
        }
    }
    class DanismanHandler : KisilerHandler
    {
        public override void SurecTalebi(Soru sbilgi)
        {
            // Eğer Sorunun derecesi Düşük ise sorumluluk DanismanHandler nesne örneğine aittir. Ancak değilse, zincirde bir sonraki tip olan BolumBaskanHandler' a ait SüreçTalebi metodu çağırılır.
            if (sbilgi.derece == SoruDerece.Düsük)
                Console.WriteLine("Danışman hocası üzerinde olan bir soru.\n\t{0} için gerekli başlatma işlemleri yapılıyor.", sbilgi.detay);
            else if (_successor != null)
                _successor.SurecTalebi(sbilgi);
        }
    }

}
