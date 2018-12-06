using Agentstvo.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Agentstvo.DAO
{
    public class StrSlDAO : DAO
    {
        private Entities _entities = new Entities();
        public IEnumerable<StrSl> GetAllStrSl()
        {
            return (from c in _entities.StrSl.Include("GroupStr") select c);
        }
        public GroupStr GetGroupStr(int? id)
        {
            if (id != null) //возращает запись по её Id
                return (from c in _entities.GroupStr
                        where c.Id == id
                        select c).FirstOrDefault();
            else // возращает первую запись в таблице
                return (from c in _entities.GroupStr
                        select c).FirstOrDefault();
        }
        public StrSl getStrSl(int id)
        {
            return (from c in _entities.StrSl.Include("GroupStr")
                    where c.Id == id
                    select c).FirstOrDefault();
        }
        public bool addSrtSl(int GroupId, StrSl Str)
        {
            try
            {
                Str.GroupStr = GetGroupStr(GroupId);
                _entities.StrSl.Add(Str);
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateStrSl(int GroupId, StrSl Str)
        {
            StrSl originalRecords = getStrSl(Str.Id);
            originalRecords.GroupStr = GetGroupStr(GroupId);
            try
            {
                originalRecords.IDKl = Str.IDKl;
                originalRecords.IDDogv = Str.IDDogv;
                originalRecords.Date = Str.Date;
                originalRecords.Described = Str.Described;
                originalRecords.IDGroup = Str.IDGroup;
                //       originalRecords.IDGroup = Dogov.IDGroup;

                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteStrSl(int Id)
        {
            StrSl originalStrSl = getStrSl(Id);
            try
            {
                _entities.StrSl.Remove(originalStrSl);
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