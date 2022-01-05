using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class FinancyPaperS
    {
        Entities db;
        public FinancyPaperS()
        {
            db = Entities.CreateEntities();
        }
        public FinancialPaper getItem(Guid id)
        {
            return db.FinancialPapers.FirstOrDefault(x => x.KeyFinance == id);
        }
        public List<FinancialPaper> getList()
        {
            return db.FinancialPapers.ToList();
        }
       
        public List<FinancialPaper> getList(Guid id)
        {
            return db.FinancialPapers.Where(x => x.KeyFinance == id).ToList();
        }
        public List<FinancialPaper> getList(int cate, DateTime day, DateTime day2, string idDepartment)
        {
           
           
            return db.FinancialPapers.Where(x => x.Category == cate && x.Date >= day && x.CREATED_DATE <= day2 && x.IdDepartment == idDepartment).ToList();
        }


        public FinancialPaper add(FinancialPaper dept)
        {
            try
            {
                db.FinancialPapers.Add(dept);
                db.SaveChanges();
                return dept;
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public FinancialPaper update(FinancialPaper dept)
        {
            FinancialPaper _dept = db.FinancialPapers.FirstOrDefault(x => x.KeyFinance == dept.KeyFinance);
            _dept.NoFP = dept.IdCompany;
            _dept.Date = dept.Date;
            _dept.NoFP2 = dept.NoFP2;
            _dept.DAY2 = dept.DAY2;
            _dept.Discount = dept.Discount;
            _dept.Quantily = dept.Quantily;
            _dept.Sum = dept.Sum;
            _dept.Note = dept.Note;
            _dept.Category = dept.Category;
            _dept.IdCompany = dept.IdCompany;
            _dept.IdDepartment = dept.IdDepartment;
            _dept.IdDepartment2 = dept.IdDepartment2;
            _dept.CREATED_DATE = dept.CREATED_DATE;
            _dept.UPDATE_DATE = dept.UPDATE_DATE;
            _dept.DELETE_DATE = dept.DELETE_DATE;

            try
            {
                db.SaveChanges();
                return dept;
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        public void delete(Guid id, int status)
        {
            FinancialPaper _dept = db.FinancialPapers.FirstOrDefault(x => x.KeyFinance == id && x.Status == status);
            if (_dept != null)
            {
                try
                {
                    db.FinancialPapers.Remove(_dept);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error" + ex.Message);
                }
            }

        }
    }

}
