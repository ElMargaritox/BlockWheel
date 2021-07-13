using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace EgnBlockWheel
{
    public class Config : IRocketPluginConfiguration
    {
        public string Permiso;
        public bool Armas_Pueden_Destruir_Ruedas;
        public bool Melee_Pueden_Destruir_Ruedas;
        public void LoadDefaults()
        {
            Permiso = "egn.wheel";
            Armas_Pueden_Destruir_Ruedas = true;
            Melee_Pueden_Destruir_Ruedas = true;
        }
    }
}
