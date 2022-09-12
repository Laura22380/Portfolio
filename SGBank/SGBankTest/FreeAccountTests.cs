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
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = new AccountManager(new FreeAccountTestRepository());
            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }

        [TestCase("12345", "20.00", "120.00", true)]
        [TestCase("56789", "20.00", "120.00", false)]
        [TestCase("12345", "200.00", "300.00", false)]
        [TestCase("12345", "-10", "90.00", false)]
        public void FreeAccountDepositRuleTest(string accountNumber, string depositAmount, string expectedBalance, bool isValid)
        {
            AccountManager manager = new AccountManager(new FreeAccountTestRepository());
            AccountDepositResponse response = manager.Deposit(accountNumber, Decimal.Parse(depositAmount));

            Assert.AreEqual(isValid, response.Success);
            if (response.Success)
            {
                AccountLookupResponse lookupResponse = manager.LookupAccount("12345");
                Assert.AreEqual(Decimal.Parse(expectedBalance), lookupResponse.Account.Balance);
            }
        }
        [TestCase("12345", "-550.00", false)]
        [TestCase("12345", "25.00", false)]
        [TestCase("12345", "-50.00", true)]
        public void FreeAccountWithdrawRuleTest(string accountNumber, string withdrawAmount, bool isValid)
        {
            AccountManager manager = new AccountManager(new BasicAccountTestRepository());
            AccountWithdrawResponse response = manager.Withdraw(accountNumber, decimal.Parse(withdrawAmount));
            decimal expectedBalance = response.OldBalance + response.Amount;
            Assert.AreEqual(isValid, response.Success);
            if (response.Success)
            {
                AccountLookupResponse lookupResponse = manager.LookupAccount("1234");
                Assert.AreEqual(expectedBalance, lookupResponse.Account.Balance);
            }
        }

    }
}
