using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBankTest
{
    [TestFixture]
    public class FileTests
    {
        public class RepositoryTests
        {
            private const string _filePath = @"C:\Users\welfl\OneDrive\Documents\SoftwareGuild\repository\online-net-2021-Triton22830\Summatives\SGBank\AccountsData\AccountsForTests.txt";
            private const string _originalData = @"C:\Users\welfl\OneDrive\Documents\SoftwareGuild\repository\online-net-2021-Triton22830\Summatives\SGBank\AccountsData\Accounts.txt";

            [SetUp]
            public void Setup()
            {
                if (File.Exists(_filePath))
                {
                    File.Delete(_filePath);
                }
                File.Copy(_originalData, _filePath);
            }
            //[Test]
            //public void CanReadDataFromFile()
            //{
            //    FileAccountRepository repo = new FileAccountRepository(_filePath);
            //    List<Account> data = repo.LoadAccount(AccountNumber);
            //    Assert.AreEqual(3, data.Count());
            //    Account check = data[1];
            //    Assert.AreEqual("11111", check.AccountNumber);
            //    Assert.AreEqual("Free Customer", check.Name);
            //}
        } 
    }
}
