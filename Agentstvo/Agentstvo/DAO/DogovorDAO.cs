using Agentstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agentstvo.DAO
{
    public class DogovorDAO
    {
        private Entities _entities = new Entities();
        public IEnumerable<Dogovor> GetAllDogovor()
        {
            return (from c in _entities.Dogovor.Include("GroupDog") select c);
        }
        public GroupDog GetGroupDog(int? id)
        {
            if (id != null) //возращает запись по её Id
                return (from c in _entities.GroupDog
                        where c.Id == id
                        select c).FirstOrDefault();
            else // возращает первую запись в таблице
                return (from c in _entities.GroupDog
                        select c).FirstOrDefault();
        }
        public Dogovor getDogovor(int id)
        {
            return (from c in _entities.Dogovor.Include("GroupDog")
                    where c.Id == id
                    select c).FirstOrDefault();
        }
        public bool addDogovor(int GroupId, Dogovor Dogov)
        {
            try
            {
                Dogov.GroupDog = GetGroupDog(GroupId);
                _entities.Dogovor.Add(Dogov);
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDogovor(int GroupId, Dogovor Dogov)
        {
            Dogovor originalRecords = getDogovor(Dogov.Id);
            originalRecords.GroupDog = GetGroupDog(GroupId);
            try
            {
                originalRecords.IDKl = Dogov.IDKl;
                originalRecords.IDAg = Dogov.IDAg;
                originalRecords.IDTr = Dogov.IDTr;
                originalRecords.Date = Dogov.Date;
                //       originalRecords.IDGroup = Dogov.IDGroup;

                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDogovor(int Id)
        {
            Dogovor originalRecords = getDogovor(Id);
            try
            {
                _entities.Dogovor.Remove(originalRecords);
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}