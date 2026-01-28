using ExpenseTracker.Models;
using System.Collections.Generic;

namespace ExpenseTracker.Services
{
    public interface IExpenseService
    {
        List<Expense> GetAll();
        Expense GetById(int id);
        void Add(Expense expense);
        void Update(Expense expense);
        void Delete(int id);
    }
}
