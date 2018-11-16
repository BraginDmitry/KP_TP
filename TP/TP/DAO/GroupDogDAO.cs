using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP.Models;

namespace TP.DAO
{
    public class GroupDogDAO
    {
        private tpEntities1 _entities = new tpEntities1();
        public IEnumerable<GroupDog> GetAllGroups()
        {
            return (from c in _entities.GroupDog
                    select c);
        }
    }
}