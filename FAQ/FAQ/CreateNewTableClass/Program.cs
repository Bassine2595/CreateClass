using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CreateNewTableClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] listTable = { "Answer" };

            foreach (string table in listTable)
            {
                TableInfoBLL tableInfo = new TableInfoBLL(table);
                tableInfo.CreationDesFichier(table);
            }
        }
    }
}
