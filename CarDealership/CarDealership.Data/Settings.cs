﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class Settings
    {
        private static string _connectionString;
        private static string _repositoryMode;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            return _connectionString;
        }

        public static string GetRepositoryMode()
        {
            if (string.IsNullOrEmpty(_repositoryMode))
                _repositoryMode = ConfigurationManager.AppSettings["Mode"].ToString();

            return _repositoryMode;
        }
    }
}
