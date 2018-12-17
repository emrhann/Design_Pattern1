using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Iphone iphone = new Iphone("Iphone 6S", "Apple");
            Samsung samsung = new Samsung("Samsung Note3", "Samsung");

            iphone.Kabul(new WifiVisitor());
            samsung.Kabul(new WifiVisitor());

            iphone.Kabul(new ThreeGVisitor());
            samsung.Kabul(new ThreeGVisitor());

            //bunun gibi baska visitor sınıfları yazarak sınıfımızı değiştirmeden
            //yeni metotlar çalıştırabilir hale getirebiliriz. 

            Console.ReadLine();
        }
    }

    //Telefon Abstract class
    public abstract class Telefon
    {
        public string Model { get; set; }
        public string Marka { get; set; }

        public Telefon(string model, string marka)
        {
            Model = model; 
            Marka = marka;
        }

        public abstract void Kabul(IVisitor visitor);
    }

    //Concreate Class
    public class Iphone : Telefon
    {
        public Iphone(string model, string marka)
            : base(model, marka)
        {
        }

        public override void Kabul(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    //Concreate class
    public class Samsung : Telefon
    {
        public Samsung(string model, string marka)
            : base(model, marka)
        {
        }

        public override void Kabul(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    //Visitor Interface
    public interface IVisitor
    {
        void Visit(Telefon telefon);
    }

    //Concreate Visitor Class
    public class WifiVisitor : IVisitor
    {
        public void Visit(Telefon telefon)
        {
            if (telefon is Iphone)
                Console.WriteLine("Iphone wifi Açık.");
            else if (telefon is Samsung)
                Console.WriteLine("Samsung Wifi Seçeneği Yok.");
            else
                Console.WriteLine("Bu nesne bir Telefon değil.");
        }
    }
    //Concreate Visitor Class
    public class ThreeGVisitor : IVisitor
    {
        public void Visit(Telefon telefon)
        {
            if (telefon is Iphone)
                Console.WriteLine("Iphone Wifi 3G Seçeneği yok.");
            else if (telefon is Samsung)
                Console.WriteLine("GalaxyTab 3G Açık.");
            else
                Console.WriteLine("Bu nesne bir Telefon değil..");
        }
    }


}
