using System;
using System.Linq;

namespace Domain.Model
{
    public abstract class Entity<TEntity> where TEntity : Entity<TEntity>
    {
        public Entity()
        {

        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<TEntity>;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (ReferenceEquals(null, compareTo))
                return false;

            return false;
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 654) + Guid.NewGuid().GetHashCode();
        }

        public static bool operator ==(Entity<TEntity> a, Entity<TEntity> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TEntity> a, Entity<TEntity> b)
        {
            return !(a == b);
        }

        public static void CopyProertiesTo<T>(T source, T dest)
        {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(T).GetProperties().Where(x => x.CanWrite).ToList();

            foreach (var sourceProp in sourceProps)
            {
                if(destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite)
                    {
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }
            }
        }
    }
}
