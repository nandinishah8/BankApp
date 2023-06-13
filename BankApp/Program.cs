namespace BankApp
{

    public abstract class BankAccount
    {
        public int AccountNumber 
        { 
            get; 
            set; 
        }
        public double Balance
        { 
            get; 
            set; 
        }
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
    }
    
    public class SavingsAccount : BankAccount
    {
        public double InterestRate
        { 
            get; 
            set; 
        }
        public override void Deposit(double amount)
        {
            Balance += amount + (amount * InterestRate);
        }
        public override void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new Exception("Insufficient Balance");
            }
        }
    }
    public class CheckingAccount : BankAccount
    {
        public double OverdraftLimit
        { 
            get; 
            set; 
        }
        public override void Deposit(double amount)
        {
            Balance += amount;
        }
        public override void Withdraw(double amount)
        {
            if (Balance + OverdraftLimit >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new Exception("Insufficient balance");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount savingsAccount = new SavingsAccount { AccountNumber = 11, Balance = 15000, InterestRate = 0.03 };
            CheckingAccount checkingAccount = new CheckingAccount { AccountNumber = 12, Balance = 52000, OverdraftLimit = 650 };
            Console.WriteLine($"Savings Account Balance: {savingsAccount.Balance}");
            Console.WriteLine($"Checking Account Balance: {checkingAccount.Balance}");
            savingsAccount.Deposit(500);
            checkingAccount.Deposit(1000);
            Console.WriteLine($"After Deposit - Savings Account Balance: {savingsAccount.Balance}");
            Console.WriteLine($"After Deposit - Checking Account Balance: {checkingAccount.Balance}");
            try
            {
                savingsAccount.Withdraw(2000);
                Console.WriteLine($"After Withdrawal - Savings Account Balance: {savingsAccount.Balance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Savings Account Withdrawal Failed - {ex.Message}");
            }
            try
            {
                checkingAccount.Withdraw(3000);
                Console.WriteLine($"After Withdrawal - Checking Account Balance: {checkingAccount.Balance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Checking Account Withdrawal Failed - {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}







