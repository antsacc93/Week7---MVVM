using System;
using Week7.WPF.DemoEventi.Pub_Sub;

namespace Week7.WPF.DemoEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creazione dei publisher
            Publisher youtube = new Publisher("YouTube.com");
            Publisher instagram = new Publisher("Instagram");

            //Creazione Subscribers
            Subscriber sub1 = new Subscriber("Antonia");
            Subscriber sub2 = new Subscriber("Renata");
            Subscriber sub3 = new Subscriber("Alessandra");

            sub1.Subscribe(youtube);
            sub2.Subscribe(youtube);

            sub3.Subscribe(instagram);
            sub1.Subscribe(instagram);

            //in una applicazione WPF questo corrisponde al click del mouse per es.
            youtube.Publish();

            Console.WriteLine("____________________");

            instagram.Publish();

            Console.WriteLine("___________________");

            sub1.UnSubscribe(youtube);

            youtube.Publish();
        }
    }
}
