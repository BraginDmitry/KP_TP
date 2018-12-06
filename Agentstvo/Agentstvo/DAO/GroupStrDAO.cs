using Agentstvo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agentstvo.DAO
{
    public class GroupStrDAO
    {
        private Entities _entities = new Entities();
        public IEnumerable<GroupStr> GetAllGroups()
        {
            return (from c in _entities.GroupStr
                    select c);
        }
    }
}