using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using DTO;
using DAL;

namespace BLL
{
    public class TableInfoBLL : ITableInfoRepository

    {
        string DTOFileName;
        string DTOParserFileName;
        string DALFileName;
        string BLLFileName;
        List<TableInfoDTO> columns;
        string Name;


        public TableInfoBLL()
        {
        }

        public TableInfoBLL(string name)
        {
            CreationDesFichier(name);
        }

        public void CreationDesFichier(string name)
        {
            Name = name;
            DirectoryInfo directoryDTO = Directory.CreateDirectory(ConfigurationManager.AppSettings["FileCreationDTO"]);
            DirectoryInfo directoryBLL = Directory.CreateDirectory(ConfigurationManager.AppSettings["FileCreationBLL"]);
            DirectoryInfo directoryDAL = Directory.CreateDirectory(ConfigurationManager.AppSettings["FileCreationDAL"]);

            DTOFileName = $"{directoryDTO.FullName}{Name}DTO.cs";
            DTOParserFileName = $"{directoryDTO.FullName}DTOParser_{Name}.cs";
            DALFileName = $"{directoryDAL.FullName}{Name}Db.cs";
            BLLFileName = $"{directoryBLL.FullName}{Name}BLL.cs";
            
            columns = TableInfoDb.GetTableInfoByName(Name);
            foreach (TableInfoDTO column in columns)
            {

                if (column.Type.Contains("varchar") || column.Type.Contains("nvarchar")
                    || column.Type.Contains("char") || column.Type.Contains("nchar")
                    || column.Type.Contains("text") || column.Type.Contains("ntext")
                    )
                {
                    column.Type = "String";
                }
                if (column.Type.Contains("int") || column.Type.Contains("smallint")
                    || column.Type.Contains("tinyint") || column.Type.Contains("bigint")
                    )
                {
                    column.Type = "Int32";
                }
                if (column.Type.Contains("date") || column.Type.Contains("datetime2")
                    || column.Type.Contains("datetime") || column.Type.Contains("time")
                    || column.Type.Contains("smalldatetime") || column.Type.Contains("time")
                    )
                {
                    column.Type = "DateTime";
                }

                if (column.Type.Contains("real") || column.Type.Contains("float")
                    || column.Type.Contains("decimal") || column.Type.Contains("numeric")
                    || column.Type.Contains("smalldatetime") || column.Type.Contains("time")
                    )
                {
                    column.Type = "Decimal";
                }

                else if (column.Type.Contains("bit"))
                {
                    column.Type = "Boolean";
                }

            }
            CreateDTO();
            CreateParserDTO();
            CreateDAL();
            CreateBLL();

        }

        public void CreateDTO()
        {
            string defaultValue;
            if (!File.Exists(DTOFileName))
            {


                using (StreamWriter tw = new StreamWriter(DTOFileName))
                {
                    tw.WriteLine("using System;");
                    tw.WriteLine("using System.Collections.Generic;");
                    tw.WriteLine("using System.Text;");
                    tw.WriteLine("namespace DTO");
                    tw.WriteLine("    {");
                    tw.WriteLine($"        public class {Name}DTO : DTOBase");
                    tw.WriteLine("        {");

                    for (int i = 0; i < columns.Count(); i++)
                    {
                        tw.WriteLine($"            public {columns[i].Type} {columns[i].Name}  {{get; set;}} ");
                    }

                    tw.WriteLine($"        public {Name}DTO()");
                    tw.WriteLine("            {");

                    for (int i = 0; i < columns.Count(); i++)
                    {
                        defaultValue = columns[i].Type == "Boolean" ? "true" : columns[i].Type.ToUpper()[0] + columns[i].Type.Substring(1) + "_NullValue";
                        tw.WriteLine($"                {columns[i].Name} = {defaultValue};");
                    }
                    tw.WriteLine("            }");
                    tw.WriteLine("        }");
                    tw.WriteLine("    }");
                }
            }
        }

        public void CreateParserDTO()
        {
            if (!File.Exists(DTOParserFileName))
            {


                using (StreamWriter tw = new StreamWriter(DTOParserFileName))
                {
                    tw.WriteLine("using System;");
                    tw.WriteLine("using System.Collections.Generic;");
                    tw.WriteLine("using System.Data.SqlClient;");
                    tw.WriteLine("using System.Text;");
                    tw.WriteLine("using System.Threading.Tasks;");
                    tw.WriteLine(" ");
                    tw.WriteLine("namespace DTO");
                    tw.WriteLine("    {");
                    tw.WriteLine($"        public class DTOParser_{Name} : DTOParser");
                    tw.WriteLine("        {");

                    for (int i = 0; i < columns.Count(); i++)
                    {
                        tw.WriteLine($"            public int ord_{columns[i].Name}  {{get; set;}} ");
                    }

                    tw.WriteLine($"        public override void PopulateOrdinals(SqlDataReader reader)");
                    tw.WriteLine("            {");

                    for (int i = 0; i < columns.Count(); i++)
                    {
                        tw.WriteLine($"                ord_{columns[i].Name} = reader.GetOrdinal(\"{columns[i].Name}\");");
                    }
                    tw.WriteLine("            }");

                    tw.WriteLine("        public override DTOBase PopulateDTO(SqlDataReader reader)");
                    tw.WriteLine("        {");

                    tw.WriteLine($"            {Name}DTO theTDO = new {Name}DTO();");

                    for (int i = 0; i < columns.Count(); i++)
                    {
                        tw.WriteLine($"            // {columns[i].Name}");
                        tw.WriteLine($"            if (!reader.IsDBNull(ord_{columns[i].Name})) {{ theTDO.{columns[i].Name} = reader.Get{columns[i].Type}(ord_{columns[i].Name}); }}");
                    }
                    tw.WriteLine("            // IsNew");


                    tw.WriteLine($"            theTDO.IsNew = false;");
                    tw.WriteLine("            return theTDO;");
                    tw.WriteLine("        }");
                    tw.WriteLine("    }");
                    tw.WriteLine("}");

                }
            }
        }

        public void CreateDAL()
        {
            if (!File.Exists(DALFileName))
            {


                using (StreamWriter tw = new StreamWriter(DALFileName))
                {
                    tw.WriteLine("using System;");
                    tw.WriteLine("using System.Collections.Generic;");
                    tw.WriteLine("using System.Data.SqlClient;");
                    tw.WriteLine("using System.Linq;");
                    tw.WriteLine("using System.Text;");
                    tw.WriteLine("using System.Threading.Tasks;");
                    tw.WriteLine("using DTO;");
                    tw.WriteLine(" ");
                    tw.WriteLine("namespace DAL");
                    tw.WriteLine("{");
                    tw.WriteLine($"    public class {Name}Db : DALBase");
                    tw.WriteLine("    {");
                    tw.WriteLine("        static string allField = @\"");

                    string entete = Name.ToLower()[0] + ".";
                    for (int i = 0; i < columns.Count() - 1; i++)
                    {
                        tw.WriteLine($"            {entete}{columns[i].Name},");
                    }
                    tw.WriteLine($"            {entete}{columns[columns.Count() - 1].Name}\";");



                    tw.Write("        static string allFieldSaveWithoutId = @\"");

                    for (int i = 1; i < columns.Count() - 1; i++)
                    {
                        tw.Write($"{columns[i].Name},");
                    }
                    tw.WriteLine($"{columns[columns.Count() - 1].Name}\";");

                    tw.Write("        static string allFieldSaveWithId = \"Id,\" + allFieldSaveWithoutId;");



                    tw.WriteLine("    }");
                    tw.WriteLine("}");

                }
            }
        }

        public void CreateBLL()
        {
            if (!File.Exists(BLLFileName))
            {


                using (StreamWriter tw = new StreamWriter(BLLFileName))
                {
                    tw.WriteLine("using System;");
                    tw.WriteLine("using System.Collections.Generic;");
                    tw.WriteLine("using System.Linq;");
                    tw.WriteLine("using System.Text;");
                    tw.WriteLine("using System.Threading.Tasks;");
                    tw.WriteLine("using DTO;");
                    tw.WriteLine("using DAL;");
                    tw.WriteLine(" ");
                    tw.WriteLine(" ");
                    tw.WriteLine("namespace BLL");
                    tw.WriteLine("{");
                    tw.WriteLine($"    public class {Name}BLL");
                    tw.WriteLine("    {");
                    tw.WriteLine("    }");
                    tw.WriteLine("}");

                }
            }
        }
    }
}


