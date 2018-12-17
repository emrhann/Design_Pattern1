using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            invoker.AddCommand(new DigitalKale());
            invoker.AddCommand(new DigitalKale());
            invoker.AddCommand(new GörünmeyeniSatmak());

            invoker.ExecuteAll();

            Console.ReadLine();
        }
    }
    //Command Interface
    public interface ICommand
    {
        void Execute();
    }
    //Concreate Command Class
    public class DigitalKale : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Digital Kale kitabı istemciye Verildi.");
        }
    }
    //Concreate Command Class
    public class GörünmeyeniSatmak : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Görünmeyeni Satmak kitabı istemciye Verildi.");
        }
    }
    public class Invoker
    {
        private Stack<ICommand> commandList = new Stack<ICommand>();

        public void ExecuteAll()
        {
            while (commandList.Count > 0)
                commandList.Pop().Execute();
        }

        public void AddCommand(ICommand c)
        {
            commandList.Push(c);
        }
    }
}
