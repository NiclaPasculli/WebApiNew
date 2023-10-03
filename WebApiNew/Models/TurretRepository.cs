using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiNew.Models
{
    public class TurretRepository : IRepository<Turret>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Turret GetById(string id)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                var turret = myDb.Turrets.Where(t => t.TurretCode == id).FirstOrDefault();
                return turret;
            }
        }

        public void Insert(Turret item)
        {
            throw new NotImplementedException();
        }

        public List<Turret> ReadAll()
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                var turret = myDb.Turrets.ToList();
                return turret;
            }
        }

        public List<string> GetAllTurretIds()
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                var turrets = myDb.Turrets.ToList();
                List<string> turretIds = turrets.Select(t => t.TurretCode).ToList();
                return turretIds;
            }
        }

        public void Update(Turret item)
        {
            throw new NotImplementedException();
        }
    }
}