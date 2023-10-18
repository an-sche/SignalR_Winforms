namespace Server;

public class ConnectionMapping<T> where T : notnull 
{
    private readonly Dictionary<T, HashSet<string>> _connections = new();
    private readonly Dictionary<string, T> _idsToKeys = new();

    public int Count
    {
        get
        {
            return _connections.Count;
        }
    }

    public void Add(T key, string connectionId)
    {
        lock (_connections)
        {
            if (!_connections.TryGetValue(key, out var connections))
            {
                connections = new HashSet<string>();
                _connections.Add(key, connections);
            }

            lock (connections)
            {
                connections.Add(connectionId);
            }

            lock (_idsToKeys)
            {
                _idsToKeys[connectionId] = key;
            }
        }
    }

    public IEnumerable<string> GetConnections(T key)
    {
        if (_connections.TryGetValue(key, out var connections))
        {
            return connections;
        }

        return Enumerable.Empty<string>();
    }

    public T? GetKey(string connectionId)
    {
        lock (_idsToKeys)
        {
            if (_idsToKeys.TryGetValue(connectionId, out var key))
            { 
                return key; 
            }
        }
        return default;
    }

    public void Remove(T key, string connectionId)
    {
        lock (_connections)
        {
            if (!_connections.TryGetValue(key, out var connections))
            {
                return;
            }

            lock (connections)
            {
                connections.Remove(connectionId);

                if (connections.Count == 0)
                {
                    _connections.Remove(key);
                }
            }

            lock (_idsToKeys)
            {
                _idsToKeys.Remove(connectionId);
            }
        }
    }
}