using FluentNHibernate.Testing;
using NUnit.Framework;
using WebCons.Data;
using WebCons.WebUI;

namespace WebCons.Test
{
    [TestFixture]
    public class TestProgetto 
    {
        

        [Test]
        public void Check_Properties()
        {

            var session  =  NhibernateConfiguration.CreateSessionFactory().OpenSession();
            new PersistenceSpecification<Progetto>(session)
                .CheckProperty(x=>x.Id, 1)
                .CheckProperty(x=>x.Descrizione, "10")
                
                .VerifyTheMappings();
           

        }

         
    }
}
