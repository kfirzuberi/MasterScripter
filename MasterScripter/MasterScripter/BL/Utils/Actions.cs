using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterScripter.BL.Utils
{
    public enum ModelType
    {
        Comment = 0,
        Company = 1,
        Country = 2,
        Execution = 3,
        FileType = 4,
        Machine = 5,
        Reason = 6,
        Script = 7,
        User = 8
    }


    public class Actions
    {
        public ModelType ModelType { get; set; }
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }

        public Actions(ModelType modelType, bool create = false, bool read = false, bool update = false,
            bool delete = false)
        {
            ModelType = modelType;
            Create = create;
            Read = read;
            Update = update;
            Delete = delete;
        }

        public override bool Equals(object obj)
        {
            Actions actions = obj as Actions;

            return actions != null &&
                   this.Create == actions.Create &&
                   this.Read == actions.Read &&
                   this.Update == actions.Update &&
                   this.Delete == actions.Delete &&
                   this.ModelType == actions.ModelType;
        }
    }
}