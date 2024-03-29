using System.Collections.Generic;

namespace NLP_package {
    public class Maps {
        public readonly Dictionary<bool, string> himap = new Dictionary<bool, string>() {
            { true, "Приветствие"},
            { false, "Не приветствие"}
        };
        public readonly Dictionary<bool, string> thmap = new Dictionary<bool, string>() {
            { true, "Благодарность"},
            { false, "Не благодарность"}
        };
        public readonly Dictionary<bool, string> businessmap = new Dictionary<bool, string>() {
            { true, "Дело"},
            { false, "Не дело"}
        };
        public readonly Dictionary<bool, string> trashmap = new Dictionary<bool, string>() {
            { true, "Треш"},
            { false, "Не треш"}
        };
        public readonly Dictionary<bool, string> weathermap = new Dictionary<bool, string>() {
            { true, "Погода"},
            { false, "Не погода"}
        };
        public readonly Dictionary<bool, string> moodmap = new Dictionary<bool, string>() {
            { true, "Настроение"},
            { false, "Не настроение"}
        };
        public readonly Dictionary<bool, string> healthmap = new Dictionary<bool, string>() {
            { true, "Здоровье"},
            { false, "Не здоровье"}
        };
    }

    public class ListMaps : Maps {
        public List<Dictionary<bool, string>> GetListMaps() {
            List<Dictionary<bool, string>> lmaps = new List<Dictionary<bool, string>>();
            lmaps.Add(this.himap);
            lmaps.Add(this.thmap);
            lmaps.Add(this.businessmap);
            lmaps.Add(this.weathermap);
            lmaps.Add(this.trashmap);
            lmaps.Add(this.moodmap);
            lmaps.Add(this.healthmap);
            return lmaps;
        }
    }
}