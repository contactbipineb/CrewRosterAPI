using System;

namespace EY.CabinCrew.Core
{
    public class ConnectionStringSettings
    {
        public string DefaultTableName { get; set; }
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }

        public ConnectionStringSettings()
        {
        }

        public ConnectionStringSettings(String name, String connectionString)
            : this(name, connectionString, null)
        {
        }

        public ConnectionStringSettings(String name, String connectionString, String providerName)
        {
            this.DefaultTableName = name;
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
        }

        protected bool Equals(ConnectionStringSettings other)
        {
            return String.Equals(DefaultTableName, other.DefaultTableName) && String.Equals(ConnectionString, other.ConnectionString) && String.Equals(ProviderName, other.ProviderName);
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ConnectionStringSettings)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (DefaultTableName != null ? DefaultTableName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ConnectionString != null ? ConnectionString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ProviderName != null ? ProviderName.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ConnectionStringSettings left, ConnectionStringSettings right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ConnectionStringSettings left, ConnectionStringSettings right)
        {
            return !Equals(left, right);
        }
    }
}
