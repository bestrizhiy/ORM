namespace Demo
{
    using System;
    using System.Linq;
    using DataAccess;
    using DataAccess.Repositories;
    using Domain;

    internal class Program
    {
        private static void Main()
        {
            var client = new Client(1, "Игнатов", "Александр", "25.03.1976", "4718 190567", "Андреевич", "8708691914100201");
            var client1 = new Client(2, "Карасев", "Платон", "14.10.1988", "4716 757066", "Игнатович");
            var client2 = new Client(3, "Трофимов", "Тимофей", "10.05.1990", "4515 478367", "8788691514100356");
            var client3 = new Client(4, "Аксенова", "Вера", "31.07.1957", "4633 274569", "Тимуровна");

            var tour = new Tour(1, "Египет", "Каир", "80.000 руб.", client);
            var tour1 = new Tour(2, "Беларусь", "Минск", "60.000 руб.", client1);
            var tour2 = new Tour(3, "Великобритания", "Лондон", "90.000 руб.", client2);
            var tour3 = new Tour(4, "Казахстан", "Алматы", "50.000 руб.", client3);

            Console.WriteLine($"{tour} {client}");

            var settings = new Settings();

            settings.AddDatabaseServer(@"DESKTOP-PRO8BR9\SQLEXPRESS");

            settings.AddDatabaseName("TravelAgency");

            using var sessionFactory = Configurator.GetSessionFactory(settings, showSql: true);

            using (var session = sessionFactory.OpenSession())
            {
                session.Save(tour);
                session.Save(tour1);
                session.Save(tour2);
                session.Save(tour3);

                session.Save(client);
                session.Save(client1);
                session.Save(client2);
                session.Save(client3);
                session.Flush();
            }

            using (var session = sessionFactory.OpenSession())
            {
                var repoTour = new TourRepository();
                Console.WriteLine("All tours:");
                repoTour.GetAll(session)
                    .ToList().ForEach(Console.WriteLine);
                Console.WriteLine(new string('-', 25));

                var repoClient = new ClientRepository();
                Console.WriteLine("All clients:");
                repoClient.GetAll(session)
                    .ToList().ForEach(Console.WriteLine);
                Console.WriteLine(new string('-', 25));
            }
        }
    }
}
