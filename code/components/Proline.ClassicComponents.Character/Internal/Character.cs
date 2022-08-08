using CitizenFX.Core;
using Proline.ClassicOnline.CGameLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proline.ClassicOnline.CGameLogic.Internal
{
    internal static class Character
    {
        internal static Entity PersonalVehicle { get; set; }
        internal static PlayerCharacter PlayerCharacter { get; set; }
        internal static long BankBalance { get; set; }
        internal static long WalletBalance { get; set; }
    }
}
