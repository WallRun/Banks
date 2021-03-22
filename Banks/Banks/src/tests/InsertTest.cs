using System;
using Banks.application.dataSource;
using Banks.application.infra;
using Banks.application.service;
using Banks.dataSource;
using Banks.model.bank;
using NUnit.Framework;

namespace Banks.tests
{
    public class InsertTest
    {
        [Test]
        public void insertSuccess()
        {
            SQLiteDataSource dataSource = new SQLiteDataSource();
            ErrorMessage errorMessage = dataSource.Connect();
            if (!errorMessage.HasError())
            {
                ServiceFactory.Initialize(dataSource);
            }
            else
            {
                Console.WriteLine("An error occured");
            }   

            
            /*string queryText = SQLiteQueryTextFactory.InsertQueryText(MetaDataFactory.CreateBankDataMap());
            Console.WriteLine(queryText);*/
            IBankService bankService = ServiceFactory.CreateBankService();
            for (int i = 0; i < 2; i++)
            {
                Bank bank = bankService.Create();
                bank.SetName("i.ToString()");
                bankService.Save(bank);
            }
            Assert.True(true);
        }
    }
}