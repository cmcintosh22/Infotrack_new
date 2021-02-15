using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Services
{
    public interface IData
    {
        string GoogleURL();
        string GoogleURLInput(string input);
        string InfotrackURL();
        string GoogleResultSplit();
        string PaidAdSplit();

        Task getDataAsync();
    }
}
