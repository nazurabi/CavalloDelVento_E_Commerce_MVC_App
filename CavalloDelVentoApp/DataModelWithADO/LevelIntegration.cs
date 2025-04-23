using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelWithADO
{
    internal class LevelIntegration
    {
        public int levelIntegrationID { get; set; }
        public int brandIDFK { get; set; }
        public int categoryIDFK { get; set; }
        public int productIDFK { get; set; }
        public int userIDFK { get; set; }
        public short unitsOnOrder { get; set; }
        public DateTime orderDate { get; set; }
        public short competionLevel { get; set; }
        public DateTime orderCompletionDate { get; set; }
        public string description { get; set; }
    }
}
