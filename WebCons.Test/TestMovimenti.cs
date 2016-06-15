using System;
using System.Data;
using System.Data.OleDb;
using FluentNHibernate.Testing;
using NUnit.Framework;
using WebCons.Data;
using WebCons.WebUI;

namespace WebCons.Test
{
    [TestFixture]
    public class TestMovimenti
    {
        [Test]
        public void TestIfOleDbDvriverExists()
        {
            OleDbEnumerator enumerator = new OleDbEnumerator();
            DataTable table = enumerator.GetElements();

            DisplayData(table);
            var HasOledbProvider = false;
            foreach (DataRow row in table.Rows)
            {
                string source = row["SOURCES_NAME"].ToString();
                if (source == "Microsoft.ACE.OLEDB.12.0")
                {
                    HasOledbProvider = true;
                 
                }

            }
            Assert.IsTrue(HasOledbProvider);
         
        }

        static void DisplayData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                }
                Console.WriteLine("==================================");
            }
        }

        [Test]
        public void Check_Properties()
        {

            var session  =  NhibernateConfiguration.CreateSessionFactory().OpenSession();
            
            new PersistenceSpecification<Movimenti>(session)

                .CheckProperty(x=>x.Nota, "note")
                .CheckProperty(x=>x.OreAssenza,10.5m)
                .CheckProperty(x=>x.OreConsuntivate,20.5m)
                .CheckProperty(x => x.Jira,"nere")
                .CheckProperty(x=>x.DataCompetenza, DateTime.Now.Date)
                .VerifyTheMappings();
         
        }

          [Test]
        public void Check_References()
        {

            var session = NhibernateConfiguration.CreateSessionFactory().OpenSession();
            new PersistenceSpecification<Movimenti>(session)
                .CheckReference(x=>x.Fase, new Fase{Descrizione = "Fase"})
                .CheckReference(x=>x.Progetto, new Progetto{Descrizione = "Progetto"})
                .CheckReference(x => x.Presidio, new Presidio{Descrizione = "Presidio"})
                .CheckReference(x=>x.Risorsa, new Risorsa{Descrizione = "Risorsa"})
                .CheckReference(x=>x.Unita, new Unita{Descrizione = "Descrizione"})
                .VerifyTheMappings();


        }  
    }
}
