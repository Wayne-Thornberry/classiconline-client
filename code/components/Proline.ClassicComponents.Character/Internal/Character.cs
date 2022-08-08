using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CGameLogic.Internal
{
    internal static class Character
    {
        public static Entity PersonalVehicle { get; internal set; }
        internal static long BankBalance { get; set; }
        internal static long WalletBalance { get; set; }
    }
}
