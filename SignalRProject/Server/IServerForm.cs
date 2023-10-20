using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server;
public interface IServerForm
{
    void Log(string message);
    void AddClient(string client);
    void RemoveClient(string client);
}
