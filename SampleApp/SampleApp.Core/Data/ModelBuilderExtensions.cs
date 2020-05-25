using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Entities;
using SampleApp.Core.Enums;

namespace SampleApp.Core.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    ClientId = 1,
                    Name = "TestClient1",
                    Age = 20,
                    Gender = GenderType.Male
                },
                new Client
                {
                    ClientId = 2,
                    Name = "TestClient2",
                    Age = 30
                },

                new Client
                {
                    ClientId = 3,
                    Name = "TestClient3",
                    Gender = GenderType.Female,
                    Age = 35
                },

                new Client
                {
                    ClientId = 4,
                    Name = "TestClient4",
                    Gender = GenderType.Male,
                    Age = 40
                },
                new Client
                {
                    ClientId = 5,
                    Name = "TestClient5",
                    Age = 50
                }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    AccountId = 1,
                    Sum = 1500,
                    AccountType = AccountType.Deposit,
                    ClientId = 1
                },

                new Account
                {
                    AccountId = 2,
                    Sum = 2500,
                    AccountType = AccountType.Credit,
                    ClientId = 1
                },

                new Account
                {
                    AccountId = 3,
                    Sum = 2500,
                    AccountType = AccountType.Credit,
                    ClientId = 1
                },

                new Account
                {
                    AccountId = 4,
                    Sum = 3500,
                    AccountType = AccountType.Deposit,
                    ClientId = 2
                },

                 new Account
                 {
                     AccountId = 5,
                     Sum = 2500,
                     AccountType = AccountType.Deposit,
                     ClientId = 2
                 },

                  new Account
                  {
                      AccountId = 6,
                      Sum = 1500,
                      AccountType = AccountType.Credit,
                      ClientId = 3
                  },

                  new Account
                  {
                      AccountId = 7,
                      Sum = 2000,
                      AccountType = AccountType.Credit,
                      ClientId = 4
                  }
            );
        }
    }
}
