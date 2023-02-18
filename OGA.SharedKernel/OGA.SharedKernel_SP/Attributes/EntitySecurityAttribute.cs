using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.SharedKernel.Attributes
{
    /* Entity Security Marker
     * Used to decorate all security actions possible for an entity.
     * Each entity type should include a set of static strings that list the possible actions for that entity type.
     * These should be included in the entity or its base.
     * Each action declaration should be decorated with this attribute, so they can be cataloged on app startup.
     * 
     * The following is an example of how to decorate action declarations for an entity type, in this case, a MObject.
     
        public class MObject : SharedKernel.Models.Base.DomainObject
        {
            static public int Latest_Version = 1;

            [EntitySecurityAttribute]
            static public string CONSTANT_MObject_Query_Read = "read";
            [EntitySecurityAttribute]
            static public string CONSTANT_MObject_Action_Add = "add";
            [EntitySecurityAttribute]
            static public string CONSTANT_MObject_Action_Update = "update";
            [EntitySecurityAttribute]
            static public string CONSTANT_MObject_Action_Delete = "delete";
        }
    
     */

    /// <summary>
    /// Marker attribute that allows us to flag entity or node level security actions, so they can be queried.
    /// All actions and query name definitions should be flagged with this for easy location.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EntitySecurityAttribute : Attribute
    {
    }
}
