using Lab4.Models;
using Lab4.Services;
using Lab4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProducerDataStore))]
namespace Lab4.Services
{
    public class ProducerDataStore : AbstractCrudDbDataStore<Producer>, IProducerDataStore
    {

        public ProducerDataStore() : base(new ApplicationContext())
        {

        }

        public ProducerDataStore(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
