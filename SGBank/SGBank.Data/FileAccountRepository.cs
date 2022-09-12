using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        //@"C:\Repos\online-net-2021-Triton22830\Summatives\SGBank\AccountsData\Accounts.txt";
        private static string _filePath = "";
        List<Account> data;

        public FileAccountRepository(string filePath)
        {
            _filePath = filePath;
            data = new List<Account>();
        }

        public Account LoadAccount(string AccountNumber)
        {
            ReadAllFromFile();
            //Do Stuff To Find Account based on parameter


            return data != null
                ? data.FirstOrDefault(x => x.AccountNumber == AccountNumber)
                : new Account();
        }

        public void SaveAccount(Account account)
        {
            //ReadAllFromFile();
            //Do stuff to Find Account and Update
            WriteToFile();
        }

        //LoadAllFromFile
        public void ReadAllFromFile()
        {
            //Reads All From Text File, Assigns To data list
            using (StreamReader sr = new StreamReader(_filePath))
            
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Account newAccount = new Account();
                    string[] columns = line.Split(',');
                    newAccount.AccountNumber = columns[0];
                    newAccount.Name = columns[1];
                    newAccount.Balance = Decimal.Parse(columns[2]);
                    switch (columns[3])
                    {
                        case "F":
                            newAccount.Type = AccountType.Free;
                            break;
                        case "B":
                            newAccount.Type = AccountType.Basic;
                            break;
                        case "P":
                            newAccount.Type = AccountType.Premium;
                            break;
                        default:
                            throw new InvalidDataException();
                    }
                    data.Add(newAccount);
                }
            }
        }

            private Account ConvertLineToObject(string line)
            {
                //take line, convert into object
                return new Account();
            }

            private string ConvertObjectToLine(Account item)
            {
            //take item, convert into string to be written to file
            return string.Format("{0},{1},{2},{3}", item.AccountNumber, item.Name, item.Balance, item.Type.ToString().ToArray().ElementAt(0));
            }

        private void WriteToFile()
        {
            if (File.Exists(_filePath))
            { 
                File.Delete(_filePath);
            }

            using(StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.WriteLine("AccountNumber,Name,Balance,Type");
                foreach(var account in data)
                {
                    sw.WriteLine(ConvertObjectToLine(account));
                }
            }
        }

        //WriteAllToFile
        //Unmarshall from File to Object
        //Marshall from Object to File



        /*public Account LoadAccountHelp(string account)
        {
            using(StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string lineInFile;
                if (account.StartsWith("11111"))
                {
                    Account accountFromFile = new Account();

                    return accountFromFile;
                }
                else if (account.StartsWith("22222"))
                {
                    Account accountFromFile = new Account();

                    return accountFromFile;
                }
                else if(account.StartsWith("33333"))
                {
                    Account accountFromFile = new Account();

                    return accountFromFile;
                }
                return null;
            }
        }*/
        //string[] lines = File.ReadAllLines(_filePath);
        //private static Account _account = new Account();
        //public Account LoadAccount(string AccountNumber)
        //{
        //    List<string> lines = File.ReadAllLines(_filePath).ToList();

        //    for (int i = 1; i < lines.Count; i++)
        //    {
        //        Account newAccount = new Account();
        //        string[] columns = lines[i].Split(',');
        //        newAccount.AccountNumber = columns[0];
        //        newAccount.Name = columns[1];
        //        newAccount.Balance = Decimal.Parse(columns[2]);
        //        if (columns[3] == "F")
        //        {
        //            _account.Type = AccountType.Free;
        //        }
        //        if (columns[3] == "B")
        //        {
        //            _account.Type = AccountType.Basic;
        //        }
        //        if (columns[3] == "P")
        //        {
        //            _account.Type = AccountType.Premium;
        //        }

        //        if (AccountNumber.Equals(_account.AccountNumber))
        //        {
        //            return _account;
        //        }
        //        return null;

        //    } return _account;
        //}

        //public Account LoadAccounts()
        //{
        //    var specificAccount = Lines.Where(n => n.StartsWith(_account.AccountNumber));
        //    return (Account)specificAccount;
        //}
        /*  public void Edit(Account account, string accountNumber)
      {
          var accounts = List();
          account.AccountNumber = account.ToString();
          CreateAccountForFile(accounts);
      }
      public string CreateLineForAccount(Account updatedAccount)
      {
          return string.Format("{0},{1},{2},{3}", updatedAccount.AccountNumber, updatedAccount.Name, updatedAccount.Balance, updatedAccount.Type);
      }*/
        //public void SaveAccount(Account account)
        //{
        //    _account = account;
        //}


    }
}
