using NUnit.Framework;
using SGBank.BLL;
using SGBank.Data;
using SGBank.Models;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBankTest
{
    [TestFixture]
    public class BasicAccountTests
    {
        [Test]
        public void CanLoadBasicAccountData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("56789");
            Assert.IsNotNull(response.Account);
            Assert.AreEqual("56789", response.Account.AccountNumber);
        }
        [TestCase("56789", "2000.00", true)]
        [TestCase("12345", "20.00", false)]
        [TestCase("56789", "-20.00", false)]
        public void BasicAccountDepositRuleTest(string accountNumber, string depositAmount, bool isValid)
        {
            AccountManager manager = new AccountManager(new BasicAccountTestRepository());
            AccountDepositResponse response = manager.Deposit(accountNumber, decimal.Parse(depositAmount));

            decimal expectedBalance = response.OldBalance + response.Amount;
            Assert.AreEqual(isValid, response.Success);
            if (response.Success)
            {
                AccountLookupResponse lookupResponse = manager.LookupAccount("56789");
                Assert.AreEqual(expectedBalance, lookupResponse.Account.Balance);
            }
        }
        [TestCase("56789", "-550.00", false)]
        [TestCase("12345", "25.00", false)]
        [TestCase("56789", "-450.00", true)]
        public void BasicAccountWithdrawRuleTest(string accountNumber, string withdrawAmount, bool isValid)
        {
            AccountManager manager = new AccountManager(new BasicAccountTestRepository());
            AccountWithdrawResponse response = manager.Withdraw(accountNumber, decimal.Parse(withdrawAmount));
            decimal expectedBalance = response.OldBalance + response.Amount;
            Assert.AreEqual(isValid, response.Success);
            if (response.Success)
            {
                AccountLookupResponse lookupResponse = manager.LookupAccount("56789");
                Assert.AreEqual(expectedBalance, lookupResponse.Account.Balance);
            }
        }
    }
}
