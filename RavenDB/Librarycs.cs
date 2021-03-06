﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB
{
    class Librarycs
    {
        const String DATABASE = "RavenDBFirstSteps";
        const String DATABASEURL = "http://localhost:8080";
        public class Student
        {
            public String Id { get; set; }

            public String Imie { get; set; }

            public String Nazwisko { get; set; }
        }
        public class Przedmiot
        {
            public String Id { get; set; }

            public String NazwaPrzedmiotu{ get; set; }

            public String ImieProwadzącego { get; set; }

            public String NazwiskoProwadzącego { get; set; }
        }
        public class Oceny
        {
            public String Id { get; set; }

            public String NazwaPrzedmiotu { get; set; }

            public String Imie { get; set; }

            public String Nazwisko { get; set; }

            public Int32 Ocena { get; set; }

            public String ImieProwadzącego { get; set; }

            public String NazwiskoProwadzącego { get; set; }
        }

        Student student = new Student() {Imie="Adam", Nazwisko="Adamiak" };
        Przedmiot przedmiot = new Przedmiot { NazwaPrzedmiotu = "Programowanie", ImieProwadzącego = "Wojciech", NazwiskoProwadzącego = "Waleński" };
        Oceny ocena = new Oceny { Imie = "Adam", Nazwisko = "Adamiak", NazwaPrzedmiotu = "Programowanie", ImieProwadzącego = "Wojciech", NazwiskoProwadzącego = "Waleński" , Ocena=3};

        public static void ZapiszStudent(Student student)
        {
            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    session.Store(student);
                    session.SaveChanges();
                }
            }
        }
        public static void ZapiszPrzedmiot(Przedmiot przedmiot)
        {

            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    session.Store(przedmiot);
                    session.SaveChanges();
                }
            }
        }
        public static void ZapiszOceny(Oceny ocena)
        {

            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    session.Store(ocena);
                    session.SaveChanges();
                }
            }
        }

        public static Student WczytajStudent(String id)
        {
            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    return session.Load<Student>(id);
                }
            }
        }
        public static Przedmiot WczytajPrzedmiot(String id)
        {
            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    return session.Load<Przedmiot>(id);
                }
            }
        }
        public static Oceny WczytajOceny(String id)
        {
            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    return session.Load<Oceny>(id);
                }
            }
        }
        public static void UsunStudent(String id)
        {
            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    Student tmp = session.Load<Student>(id);
                    session.Delete(tmp);
                    session.SaveChanges();
                }
            }
        }
        public static void UsunPrzedmiot(String id)
        {
            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    Przedmiot tmp = session.Load<Przedmiot>(id);
                    session.Delete(tmp);
                    session.SaveChanges();
                }
            }
        }
        public static void UsunOceny(String id)
        {
            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    Oceny tmp = session.Load<Oceny>(id);
                    session.Delete(tmp);
                    session.SaveChanges();
                }
            }
        }

        public static List<Student> ListaStudent()
        {
            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    List<Student> dbStudent = (from teas in session.Query<Student>()
                                        select teas).ToList<Student>();

                    return dbStudent;
                }
            }
        }
        public static List<Przedmiot> ListaPrzedmiot()
        {
            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    List<Przedmiot> dbPrzedmiot = (from teas in session.Query<Przedmiot>()
                                               select teas).ToList<Przedmiot>();

                    return dbPrzedmiot;
                }
            }
        }
        public static List<Oceny> ListaOceny()
        {
            using (var ds = new Raven.Client.Document.DocumentStore { Url = DATABASEURL }.Initialize())
            {
                using (var session = ds.OpenSession(DATABASE))
                {
                    List<Oceny> dbOceny = (from teas in session.Query<Oceny>()
                                               select teas).ToList<Oceny>();

                    return dbOceny;
                }
            }
        }


    }

}
