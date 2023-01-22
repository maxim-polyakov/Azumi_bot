using Microsoft.Data.Analysis;
namespace DB_Bridge
{
    public interface IDB_Communication
    {
        void insert_to(string insert, string tablename);
        DataFrame get_data();
        Dictionary<int, string> get_data(string select);
        bool checkcommands(string input_string);
    }
}
