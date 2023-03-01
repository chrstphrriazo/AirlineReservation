using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservation.DL
{
    public interface IDataRepository
    {
        void WriteData(string data);

        List<string> ReadData();
    }
}
