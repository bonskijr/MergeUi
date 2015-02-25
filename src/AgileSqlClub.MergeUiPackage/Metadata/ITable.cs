﻿using System;
using System.Collections.Generic;
using System.Data;
using AgileSqlClub.MergeUi.Extensions;
using AgileSqlClub.MergeUi.Merge;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace AgileSqlClub.MergeUi.Metadata
{
    public interface ITable
    {
        string SchemaName { get; set; }
        string Name { get; set; }
        List<ColumnDescriptor> Columns { get; set; }
        List<string> KeyColumns { get; set; }

        DataTable Data { get; set; }
        Merge Merge { get; set; }

        void Save(string scriptFile);
    }

    public class Merge
    {
        public MergeStatement MergeStatement { get; set; }
        public string File { get; set; }
        public int ScriptOffset { get; set; }
        public int ScriptLength { get; set; }
    }


    public class Table : ITable
    {
        public Table()
        {
            Merge = new Merge();

        }

        public Table(string name, List<ColumnDescriptor> columns)
        {
            Merge = new Merge();
            Name = name;
            Columns = columns;
            Data = new DataTableBuilder(Name, Columns).Get();
        }

        public string SchemaName { get; set; }

        public string Name { get; set; }

        public List<ColumnDescriptor> Columns { get; set; }

        public List<string> KeyColumns { get; set; }

        public DataTable Data { get; set; }

        public Merge Merge { get; set; }

        public void Save(string scriptFile)
        {
            if (Data.IsDirty())
            {
                //if detils of Merge.Blah are filled in then update the current Merge.MergeStatement with the new datatable and then get the script and overwrite the existing script..
                //if it is not filled in, we need to create a new one and build a new merge 
                Console.WriteLine();       
            }
        }
    }

}