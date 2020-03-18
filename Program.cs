using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02
{
    class Program
    {


        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        static void Main(string[] args)
        {

            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));

            var nameByG = ListeAuteurs.Where(a => a.Nom.StartsWith("G"));
            Console.WriteLine("Noms commençant par G :");
            foreach (var author in nameByG)
            {
                Console.WriteLine("- " + author.Nom +" "+ author.Prenom);

            }

            var authorMaxBook = ListeLivres.GroupBy(a => a.Auteur).OrderByDescending(g => g.Count()).FirstOrDefault().Key;

            Console.WriteLine("Auteur avec le plus de livre :");
            Console.WriteLine("- " + authorMaxBook.Nom + " " + authorMaxBook.Prenom);

            var bookByAuthor = ListeLivres.GroupBy(a => a.Auteur);

            foreach (var book in bookByAuthor)
            {
                Console.WriteLine("Auteur : " + book.Key.Nom + " " + book.Key.Prenom  + "  :");
                Console.WriteLine(" - Moyenne de page :" + book.Average(b => b.NbPages));
            }

            var bookMaxPages = ListeLivres.OrderByDescending(b => b.NbPages).First();
            Console.WriteLine("Livre avec le plus de pages : " + bookMaxPages.Titre + " Nombre de page " + bookMaxPages.NbPages);

            var factures = ListeAuteurs.SelectMany(a => a.Factures);
            var moyenneFacture = factures.Average(f => f.Montant);
            Console.WriteLine("Moyenne des Factures : " + moyenneFacture);

            Console.WriteLine("Ordre Alphabétique : ");
            var ordreAlpha = ListeLivres.OrderBy(l => l.Titre);
            foreach (var book in ordreAlpha)
            {
                Console.WriteLine(book.Titre);
            }

            

            var nombrePage = ListeLivres.Select(l => l.NbPages);
            var moyennePage = nombrePage.Average();

            Console.WriteLine("Livre NB page sup à la moyenne  " + moyennePage);


            foreach (var book in ListeLivres)
            {
                if (book.NbPages > moyennePage)
                {
                    Console.WriteLine("Titre : " + book.Titre + "Nombre de page " + book.NbPages);
                }

            }



            Console.ReadKey();
        }
    }
}
