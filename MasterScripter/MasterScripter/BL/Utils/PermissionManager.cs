using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterScripter.DAL.Models;

namespace MasterScripter.BL.Utils
{
    public static class PermissionManager
    {
       private static readonly List<Actions> AdminActions = new List<Actions>()
       {
           new Actions(ModelType.Comment, read: true, create:true, delete:true),
           new Actions(ModelType.Company, read: true, update:true, create:true),
           new Actions(ModelType.Execution, read: true, update:true, create:true),
           new Actions(ModelType.FileType, read: true, update:true, create:true),
           new Actions(ModelType.Machine, read: true, update:true, create:true),
           new Actions(ModelType.Reason, read: true, update:true, create:true),
           new Actions(ModelType.Script, read: true, update:true, create:true),
           new Actions(ModelType.User, read: true, update:true, create:true),
       };

        private static readonly List<Actions> ManagerActions = new List<Actions>()
        {
            new Actions(ModelType.Comment, read: true, create:true, delete:true),
            new Actions(ModelType.Company, read: true, update:true, create:true),
            new Actions(ModelType.Execution, read: true, update:true, create:true),
            new Actions(ModelType.FileType, read: true, update:true, create:true),
            new Actions(ModelType.Machine, read: true, update:true, create:true),
            new Actions(ModelType.Reason, read: true, update:true, create:true),
            new Actions(ModelType.Script, read: true, update:true, create:true),
            new Actions(ModelType.User, read: true, update:true, create:true),
        };

        private static readonly List<Actions> ViewerActions = new List<Actions>()
        {
            new Actions(ModelType.Comment, read: true, create:true, delete:true),
            new Actions(ModelType.Company, read: true),
            new Actions(ModelType.Execution, read: true, create:true),
            new Actions(ModelType.Machine, read: true),
            new Actions(ModelType.Script, read: true),
        };

        private static readonly Dictionary<Role, List<Actions>> UsersPermissionMapper = new Dictionary<Role, List<Actions>>()
        {
            {Role.Admin, AdminActions},
            {Role.Manager, ManagerActions},
            {Role.Viewer, ViewerActions}
        };

        public static bool IsMethodAllow(User user, Actions action)
        {
            return UsersPermissionMapper[user.Role].Any(action.Equals);
        }
    }

}