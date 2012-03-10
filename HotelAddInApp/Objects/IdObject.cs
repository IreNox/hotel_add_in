using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelAddInApp
{
    [Serializable]
    public abstract class IdObject
    {
        #region Fields
        public abstract string Id { get; }
        #endregion

        #region Operators
        public override bool Equals(object obj)
        {
            IdObject idObject = obj as IdObject;

            if (idObject != null)
            {
                return (this == idObject);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(IdObject a, IdObject b)
        {
            if (((object)a == null) && ((object)b == null))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Id == b.Id && a.GetType() == b.GetType();
        }

        public static bool operator !=(IdObject a, IdObject b)
        {
            return !(a == b);
        }
        #endregion
    }
}
