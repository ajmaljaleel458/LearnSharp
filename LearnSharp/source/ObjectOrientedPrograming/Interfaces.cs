namespace LearnSharp.ObjectOrientedPrograming
{
    using Logger;
    using Windows.Services.Maps;

    public class Interfaces
    {
        private interface IAccount
        {
            bool Deposite(decimal depositAmount);

            bool Withdraw(decimal amount);

            void ShowBalance();

        }

        private class Savings : IAccount
        {
            private decimal _balance = 0;

            private readonly decimal PER_DAY_WITHDRAW_LIMIT = 10000;

            private decimal _todayTotalWithdrawal = 0;
            public bool Deposite(decimal depositAmount)
            {
                this._balance += depositAmount;
                return true;
            }

            public void ShowBalance()
            {
                Logger.Info($"Balance : {_balance}");
            }

            public bool Withdraw(decimal amount)
            {
                if (_balance < amount)
                {
                    Logger.Error("Insificient Balance!");
                    return false;
                }
                else if (_todayTotalWithdrawal + amount > PER_DAY_WITHDRAW_LIMIT)
                {
                    Logger.Error("Twodays limit is reached!");
                    return false;
                }
                else
                {
                    _balance -= amount;
                    _todayTotalWithdrawal += amount;
                    Logger.Info("Amount Successfully Withdrawed.");
                    return true;
                }
            }
        }

        private class Current : IAccount
        {
            private decimal _balance = 0;

            public bool Deposite(decimal depositAmount)
            {
                this._balance += depositAmount;
                return true;
            }

            public void ShowBalance()
            {
                Logger.Info($"Balance : {_balance}");
            }

            public bool Withdraw(decimal amount)
            {
                if (_balance < amount)
                {
                    Logger.Error("Insificient Balance!");
                    return false;
                }
                else
                {
                    _balance -= amount;
                    Logger.Info("Amount Successfully Withdrawed.");
                    return true;
                }
            }
        }

        public static void SandBpx()
        {
            IAccount savingsAccount = new Savings();
            savingsAccount.Deposite(1000);
            savingsAccount.Deposite(1000);
            savingsAccount.Withdraw(2000);
            savingsAccount.Withdraw(100);

            IAccount currentAccount = new Current();
            currentAccount.Deposite(500);
            currentAccount.Deposite(1500);
            currentAccount.Withdraw(2600);
            currentAccount.Withdraw(1000);
        }
    }
}
