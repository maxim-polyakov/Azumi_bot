using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP_package
{
    public class Maps
    {
        public readonly Dictionary<bool, string> himap = new Dictionary<bool, string>()
        {
            { true, "Приветствие"},
            { false, "Не приветствие"}
        };
        public readonly Dictionary<bool, string> thmap = new Dictionary<bool, string>()
        {
            { true, "Благодарность"},
            { false, "Не благодарность"}
        };
        public readonly Dictionary<bool, string> businessmap = new Dictionary<bool, string>()
        {
            { true, "Дело"},
            { false, "Не дело"}
        };
        public readonly Dictionary<bool, string> trashmap = new Dictionary<bool, string>()
        {
            { true, "Треш"},
            { false, "Не треш"}
        };
        public readonly Dictionary<bool, string> weathermap = new Dictionary<bool, string>()
        {
            { true, "Погода"},
            { false, "Не погода"}
        };
    }
}

