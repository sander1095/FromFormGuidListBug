using System;
using System.Collections.Generic;

namespace FromFormListGuidBug.Controllers
{
    public class BugModel
    {
        /// <summary>
        /// If you send a GUID it will not appear in this list
        /// </summary>
        public IEnumerable<Guid> Ids { get; set; }
        
        
        /// <summary>
        /// If you send 3 strings, the list will contain 1 entry with the 3 string comma separated.
        /// </summary>
        public IEnumerable<string> IdsAsStringList { get; set; }
    }
}