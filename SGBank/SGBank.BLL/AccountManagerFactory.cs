﻿using SGBank.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class AccountManagerFactory
    {
        private static string _filePath = @"C:\Repos\online-net-2021-Triton22830\Summatives\SGBank\AccountsData\Accounts.txt";

        public static AccountManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch(mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                case "BasicTest":
                    return new AccountManager(new BasicAccountTestRepository());
                case "PremiumTest":
                    return new AccountManager(new PremiumAccountTestRepository());
                case "FileTest":
                    return new AccountManager(new FileAccountRepository(_filePath));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
