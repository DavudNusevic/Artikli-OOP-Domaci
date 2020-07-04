using System;
using System.Collections.Generic;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Artikl> listaArtikala = new List<Artikl>();
            char unos = ' ';

            while (unos != '7')
            {
                Console.Clear();
                Console.WriteLine("[MENI]\n");

                Console.WriteLine("---------------------");
                Console.WriteLine("1 - Dodaj artikal");
                Console.WriteLine("2 - Lista artikala");
                Console.WriteLine("3 - Promena cene artikla");
                Console.WriteLine("4 - Promena kolicine artikla");
                Console.WriteLine("5 - Pretraga");
                Console.WriteLine("6 - Brisanje artikla");
                Console.WriteLine("7 - Izlaz");
                Console.WriteLine("---------------------");

                Console.Write("Izaberite :");
                unos = Console.ReadKey().KeyChar;
                Console.Write("\n");

                switch (unos)
                {
                    case '1':
                        UnosArtikala(listaArtikala);
                        break;

                    case '2':
                        IspisArtikala(listaArtikala);
                        break;

                    case '3':
                        PromenaCeneArtikla(listaArtikala);
                        break;

                    case '4':
                        PromenaKolicineArtikala(listaArtikala);
                        break;

                    case '5':
                        PretragaArtikala(listaArtikala);
                        break;

                    case '6':
                        BrisanjeArtikala(listaArtikala);
                        break;

                    case '7':
                        Console.WriteLine("Bye :)");
                        break;

                }
            }

            Console.ReadKey();
        }


        static void PromenaKolicineArtikala(List<Artikl> lista)
        {
            Console.Clear();
            Console.WriteLine("[PROMENAKOLICINE]\n");

            string zaPromenu = "";
            UnosStringa(ref zaPromenu, "Unesite naziv ili sifru artikla :");
            int promena = 0;
            char unos;

            foreach (Artikl l in lista)
                if (l.naziv.ToLower().Contains(zaPromenu.ToLower()) || l.sifra.ToLower().Contains(zaPromenu.ToLower()))
                {
                    Console.Write($"Da li zelite da promenite artikl {l.naziv} -- {l.sifra} (d/n) :");
                    unos = Console.ReadKey().KeyChar;
                    Console.Write("\n");

                    if (unos == 'd')
                    {
                        Console.Clear();
                        Console.WriteLine("[PROMENACENE]\n");

                        Console.WriteLine("Menjate artikl :");
                        Console.Write("\n");
                        l.Ispis();
                        Console.Write("\n");

                        UnosInta(ref promena, "Unesite promenu u kolicini :", l.kolicina);

                        l.kolicina += promena;

                        break;
                    }
                }

            Console.Write("\nPritisnete bilo koji taster za povratak na meni ");
            Console.ReadKey();

        }

        static void PromenaCeneArtikla(List<Artikl> lista)
        {

            Console.Clear();
            Console.WriteLine("[PROMENACENE]\n");

            string zaPromenu = "";
            UnosStringa(ref zaPromenu, "Unesite naziv ili sifru artikla :");
            char unos;

            foreach(Artikl l in lista)
                if (l.naziv.ToLower().Contains(zaPromenu.ToLower()) || l.sifra.ToLower().Contains(zaPromenu.ToLower()))
                {
                    Console.Write($"Da li zelite da promenite artikl {l.naziv} -- {l.sifra} (d/n) :");
                    unos = Console.ReadKey().KeyChar;
                    Console.Write("\n");

                    if(unos == 'd')
                    {
                        Console.Clear();
                        Console.WriteLine("[PROMENACENE]\n");

                        Console.WriteLine("Menjate artikl :");
                        Console.Write("\n");
                        l.Ispis();
                        Console.Write("\n");

                        Console.Write("Unesite 1 za promenu nabavne cene, 2 za promenu marze, 3 za oboje :");
                        unos = Console.ReadKey().KeyChar;
                        Console.Write("\n");

                        if (unos == '1')
                        {
                            UnosDecimala(ref l.nabavnaCena, "Unesite novu nabavnu cenu :" );

                            l.PostaviProdajnuCenu();
                        }
                        if (unos == '2')
                        { 
                            UnosDecimala(ref l.marza, "Unesite novu marzu( % ) :");

                            l.PostaviProdajnuCenu();
                        }
                        if (unos == '3')
                        {
                            UnosDecimala(ref l.nabavnaCena, "Unesite novu nabavnu cenu :");
                            UnosDecimala(ref l.marza, "Unesite novu marzu( % ) :");

                            l.PostaviProdajnuCenu();

                        }
                        break;
                    }
                }

            Console.Write("\nPritisnete bilo koji taster za povratak na meni ");
            Console.ReadKey();

        }

        static void BrisanjeArtikala(List<Artikl> lista)
        {
            Console.Clear();
            Console.WriteLine("[BRISANJE]\n");

            string zaPretragu = "";
            UnosStringa(ref zaPretragu, "Unesite naziv ili sifru artikla :");
            char unos;

            for (int i = 0; i < lista.Count; ++i)
                if (lista[i].naziv.ToLower().Contains(zaPretragu.ToLower()) || lista[i].sifra.ToLower().Contains(zaPretragu.ToLower()))
                {
                    Console.Write($"Da li zelite da izbrisete artikl {lista[i].naziv} -- {lista[i].sifra} (d/n):");
                    unos = Console.ReadKey().KeyChar;
                    Console.Write("\n");

                    if (unos == 'd')
                    {
                        lista.RemoveAt(i);
                        break;
                    }

                }
            Console.Write("\nPritisnete bilo koji taster za povratak na meni ");
            Console.ReadKey();

        }

        static void PretragaArtikala(List<Artikl> lista)
        {
            Console.Clear();
            Console.WriteLine("[PRETRAGA]\n");
            string zaPretragu = "";
            UnosStringa(ref zaPretragu, "Unesite naziv ili sifru artikla :");
            Console.Write("\n");


            foreach (Artikl l in lista)
                if (l.naziv.ToLower().Contains(zaPretragu.ToLower()) || l.sifra.ToLower().Contains(zaPretragu.ToLower()))
                    l.Ispis();

            Console.Write("\nPritisnete bilo koji taster za povratak na meni ");
            Console.ReadKey();
        }

        static void UnosArtikala(List<Artikl> lista)
        {
            Console.Clear();
            Console.WriteLine("[UNOS]\n");

            Artikl zaDodavanje = new Artikl();

            UnosStringa(ref zaDodavanje.naziv, "Unesite naziv artikla :");

            UnosStringa(ref zaDodavanje.sifra, "Unesite sifru artikla :");

            UnosDecimala(ref zaDodavanje.nabavnaCena, "Unesite nabavnu cenu artikla :");

            UnosDecimala(ref zaDodavanje.marza, "Unesite marzu( % ) :");

            UnosInta(ref zaDodavanje.kolicina, "Unesite kolicinu artikla :", 0);

            zaDodavanje.PostaviProdajnuCenu();

            lista.Add(zaDodavanje);

            Console.Write("\nPritisnete bilo koji taster za povratak na meni ");
            Console.ReadKey();

        }

        static void IspisArtikala(List<Artikl> lista)
        {
            Console.Clear();
            Console.WriteLine("[Lista]\n");

            foreach (Artikl l in lista)
                l.Ispis();

            Console.Write("\nPritisnete bilo koji taster za povratak na meni ");
            Console.ReadKey();

        }

        static void UnosStringa(ref string unos, string tekst)
        {
            do
            {
                Console.Write(tekst);
                unos = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(unos));

        }
        static void UnosDecimala(ref decimal unos, string tekst)
        {
            bool a;

            do
            {
                Console.Write(tekst);
                a = decimal.TryParse(Console.ReadLine(), out unos);
            } while (!a || unos < 0);
        }

        static void UnosInta(ref int unos, string tekst, int dodatak)
        {
            bool a;

            do
            {
                Console.Write(tekst);
                a = int.TryParse(Console.ReadLine(), out unos);
            } while (!a || (unos + dodatak) < 0);
        }

    }

    
    class Artikl
    {
        public string naziv;
        public string sifra;
        public decimal nabavnaCena;
        public decimal prodajnaCena;
        public decimal marza;
        public int kolicina;

        public void Ispis()
        {
            Console.WriteLine($"{naziv} -- {sifra} -- Nabavna cena : {nabavnaCena} rsd -- Marza( % ) : {marza} -- Prodajna cena :{prodajnaCena} rsd -- {kolicina} komada");
        }

        public void PostaviProdajnuCenu()
        {
            prodajnaCena = nabavnaCena * (1 + marza / 100);
        }

    }

}

