using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiNew.Models
{
    public class ToolRepository : IRepository<Tool>
    {
        public void Delete(string id)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                var tool = myDb.Tools.Where(t => t.IdTool == id).FirstOrDefault();
                if (tool != null)
                {
                    myDb.Tools.Remove(tool);
                    myDb.SaveChanges();
                }
            }
        }

        public Tool GetById(string id)
        {
            using(MyDbContext myDb = new MyDbContext())
            {
                var tool = myDb.Tools.Where(t => t.IdTool == id).FirstOrDefault();  
                return tool;
            }
        }

        public void Insert(Tool item)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                myDb.Tools.Add(item);
                myDb.SaveChanges();
            }
        }

        public List<Tool> ReadAll()
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                var tool = myDb.Tools.ToList();
                return tool;
            }
        }

        public bool UpdateT(string id, Tool item, out string errorMessage)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                var tool = myDb.Tools.FirstOrDefault(t => t.IdTool == id);
                if (tool == null)
                {
                    errorMessage = "Id non presente";
                    return false;
                }
               
                if (string.IsNullOrEmpty(tool.BoschCode))
                {
                    errorMessage = "Il campo BoschCode non può essere nullo";
                    return false;
                }


                tool.IdTool = item.IdTool;
                tool.BoschCode = item.BoschCode;
                tool.Description = item.Description;
                tool.PrimarySupplier = item.PrimarySupplier;
                tool.SecondarySupplier = item.SecondarySupplier;
                tool.PrimarySharpener = item.PrimarySharpener;
                tool.SecondarySharpener = item.SecondarySharpener;
                tool.Quantity = item.Quantity;
                tool.TurretCode = item.TurretCode;
                myDb.SaveChanges();

                errorMessage = null;
                return true;

            }
        }

        public void Update(Tool item)
        {
            throw new NotImplementedException();
        }

        public List<Tool> Search(string id, string turretCode)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                IQueryable<Tool> query = myDb.Tools;

                if (!string.IsNullOrEmpty(id))
                {
                    query = query.Where(x => x.IdTool == id);
                }

                if (!string.IsNullOrEmpty(turretCode))
                {
                    query = query.Where(x => x.TurretCode == turretCode);
                }

                return query.ToList();
            }
        }
    }
}