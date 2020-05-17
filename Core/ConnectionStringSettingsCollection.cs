using System;
using System.Collections;
using System.Collections.Generic;

namespace EY.CabinCrew.Core
{
    public class ConnectionStringSettingsCollection : IDictionary<string, ConnectionStringSettings>
    {
        private readonly Dictionary<String, ConnectionStringSettings> m_ConnectionStrings;

        public ConnectionStringSettingsCollection()
        {
            m_ConnectionStrings = new Dictionary<String, ConnectionStringSettings>();
        }

        public ConnectionStringSettingsCollection(int capacity)
        {
            m_ConnectionStrings = new Dictionary<String, ConnectionStringSettings>(capacity);
        }

        #region IEnumerable methods
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)m_ConnectionStrings).GetEnumerator();
        }
        #endregion

        #region IEnumerable<> methods
        IEnumerator<KeyValuePair<string, ConnectionStringSettings>> IEnumerable<KeyValuePair<string, ConnectionStringSettings>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, ConnectionStringSettings>>)m_ConnectionStrings).GetEnumerator();
        }
        #endregion

        #region ICollection<> methods
        void ICollection<KeyValuePair<string, ConnectionStringSettings>>.Add(KeyValuePair<String, ConnectionStringSettings> item)
        {
            ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)m_ConnectionStrings).Add(item);
        }

        void ICollection<KeyValuePair<string, ConnectionStringSettings>>.Clear()
        {
            ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)m_ConnectionStrings).Clear();
        }

        Boolean ICollection<KeyValuePair<string, ConnectionStringSettings>>.Contains(KeyValuePair<String, ConnectionStringSettings> item)
        {
            return ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)m_ConnectionStrings).Contains(item);
        }

        void ICollection<KeyValuePair<string, ConnectionStringSettings>>.CopyTo(KeyValuePair<String, ConnectionStringSettings>[] array, Int32 arrayIndex)
        {
            ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)m_ConnectionStrings).CopyTo(array, arrayIndex);
        }

        Boolean ICollection<KeyValuePair<string, ConnectionStringSettings>>.Remove(KeyValuePair<String, ConnectionStringSettings> item)
        {
            return ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)m_ConnectionStrings).Remove(item);
        }

        public Int32 Count => ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)m_ConnectionStrings).Count;
        public Boolean IsReadOnly => ((ICollection<KeyValuePair<string, ConnectionStringSettings>>)m_ConnectionStrings).IsReadOnly;
        #endregion

        #region IDictionary<> methods
        public void Add(String key, ConnectionStringSettings value)
        {
            // NOTE only slight modification, we add back in the Name of connectionString here (since it is the key)
            value.Name = key;
            m_ConnectionStrings.Add(key, value);
        }

        public Boolean ContainsKey(String key)
        {
            return m_ConnectionStrings.ContainsKey(key);
        }

        public Boolean Remove(String key)
        {
            return m_ConnectionStrings.Remove(key);
        }

        public Boolean TryGetValue(String key, out ConnectionStringSettings value)
        {
            return m_ConnectionStrings.TryGetValue(key, out value);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public ConnectionStringSettings this[String key]
        {
            get => m_ConnectionStrings[key];
            set => Add(key, value);
        }

        public ICollection<string> Keys => m_ConnectionStrings.Keys;
        public ICollection<ConnectionStringSettings> Values => m_ConnectionStrings.Values;
        #endregion
    }
}
