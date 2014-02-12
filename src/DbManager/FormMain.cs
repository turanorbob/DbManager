using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using DbManager.setting;

using ICSharpCode.TextEditor.Document;
using System.Data.SqlClient;
using DbManager.classes;
namespace DbManager
{
    enum MARK { FOLDER, DATABASE, TABLE, COL, VIEW, PROCEDURE, PARAMETER};
    public partial class FormMain : Form
    {
        private SqlConnection sqlCon;
        private string connectionString;
        
        public FormMain()
        {
            InitializeComponent();
            AppSetting app = new AppSetting();
            propertyGrid1.SelectedObject = app;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlContent.Document.HighlightingStrategy =
HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            sqlContent.Encoding = System.Text.Encoding.UTF8;
        }

        private void Connect() {
            FormConnect formConnect = new FormConnect();
            formConnect.ShowDialog();
            if (formConnect.IsConnect)
            {
                connectionString = "Data Source=" + formConnect.Host + "," + formConnect.Port +
                    ";Initial Catalog=" + formConnect.Database + ";User Id=" + formConnect.Username + ";Password=" + formConnect.Password + ";";
                sqlCon = new SqlConnection(connectionString);
                try
                {
                    sqlCon.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (sqlCon.State != ConnectionState.Closed || sqlCon.State != ConnectionState.Broken)
                {
                    FillDbs();
                    sqlCon.InfoMessage -= new SqlInfoMessageEventHandler(HandleSqlInfo);
                }
            }
            formConnect.Dispose();
        }

        private string[] systemDatabase = { "master", "model", "msdb", "tempdb" };
        private void FillDbs() {
            string sql = "use master;select name,dbid from sysdatabases order by name;";
            sqlCon.InfoMessage += new SqlInfoMessageEventHandler(HandleSqlInfo);
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = sqlCommand;
            DataSet fill = new DataSet();
            myDataAdapter.Fill(fill);
            ArrayList dbs = new ArrayList();
            foreach (DataRow row in fill.Tables[0].Rows)
            {
                TDatabase temp;
                string name = row["name"].ToString();
                int dbid = Convert.ToInt32(row["dbid"]);
                if (systemDatabase.Contains(name))
                {
                    temp = new TDatabase(name, true, dbid);
                }
                else {
                    temp = new TDatabase(name, false, dbid);
                }
                dbs.Add(temp);
            }
            treeViewDatabases.ImageList = imageList1;
            TreeNode root = treeViewDatabases.Nodes.Add("", "databases", (int)MARK.FOLDER);
            root.Tag = new NodeType(ENodeType.DATABASE, "", "", -1);
            TreeNode sysNode = root.Nodes.Add("", "系统数据库", (int)MARK.FOLDER);
            sysNode.Tag = new NodeType(ENodeType.DATABASE, "", "", -1);
            foreach (TDatabase tdatabase in dbs) {
                TreeNode db;
                if (tdatabase.IsSystem)
                {
                    db = sysNode.Nodes.Add("", tdatabase.Name, (int)MARK.DATABASE);
                }
                else {
                    db = root.Nodes.Add("", tdatabase.Name, (int)MARK.DATABASE);
                }
                db.SelectedImageIndex = 1;
                db.Tag = new NodeType(ENodeType.DATABASE, tdatabase.Name, "", tdatabase.Dbid);


                TreeNode table = db.Nodes.Add("", "表", (int)MARK.FOLDER);
                table.SelectedImageIndex = 0;
                table.Tag = new NodeType(ENodeType.TABLE, "", tdatabase.Name, -1);
                TreeNode view = db.Nodes.Add("", "视图", (int)MARK.FOLDER);
                view.SelectedImageIndex = 0;
                view.Tag = new NodeType(ENodeType.VIEW, "", tdatabase.Name, -1);
                view.Nodes.Add("");
                TreeNode canprograme = db.Nodes.Add("", "可编程性", (int)MARK.FOLDER);
                canprograme.SelectedImageIndex = 0;
                canprograme.Tag = new NodeType(ENodeType.PROGRAME, "", tdatabase.Name, -1);
                TreeNode procedure = canprograme.Nodes.Add("", "存储过程", (int)MARK.FOLDER);
                procedure.SelectedImageIndex = 0;
                procedure.Tag = new NodeType(ENodeType.PROCEDURE, "", tdatabase.Name, -1);
                procedure.Nodes.Add("");
                FillTables(table, tdatabase.Name);
            }
        }

        private void FillTables(TreeNode parent, string dbName) {
            string sql = "select name,category,uid from "+dbName+"..sysobjects where xtype='U' order by name";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = sqlCommand;
            DataSet fill = new DataSet();
            myDataAdapter.Fill(fill);
            ArrayList tables = new ArrayList();
            foreach (DataRow row in fill.Tables[0].Rows)
            {
                string name = row["name"].ToString();
                int uid = Convert.ToInt32(row["uid"]);
                TTable temp = null;
                   
                if (name == "sysdiagrams")
                {
                    temp = new TTable(name, true, uid);
                }
                else {
                    int category = Convert.ToInt32(row["category"]);
                    switch (category)
                    {
                        case 0:
                            temp = new TTable(name, false, uid);
                            break;
                        case 2:
                            temp = new TTable(name, true, uid);
                            break;
                        default:
                            break;
                    }
                }
                
                if (temp != null) {
                    tables.Add(temp);
                }
            }
            TreeNode sysNode = parent.Nodes.Add("", "系统表", 0);
            sysNode.Tag = new NodeType(ENodeType.TABLE, "", dbName, -1);
            foreach (TTable ttable in tables) {
                TreeNode table;
                if (ttable.IsSystem)
                {
                    table = sysNode.Nodes.Add("", ttable.Name, 2);
                }
                else {
                    table = parent.Nodes.Add("", ttable.Name, 2);
                }
                table.SelectedImageIndex = 2;
                table.Tag = new NodeType(ENodeType.TABLE, ttable.Name, dbName, ttable.Uid);
                table.Nodes.Add("");
            }
        }

        public void FillSystemViews(TreeNode parent) {
            string sql = "select [name],[uid] from master..sysobjects where xtype='V' and category=2 order by uid,name";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = sqlCommand;
            DataSet fill = new DataSet();
            myDataAdapter.Fill(fill);
            ArrayList views = new ArrayList();
            foreach (DataRow row in fill.Tables[0].Rows)
            {
                string name = row["name"].ToString();
                int uid = Convert.ToInt32(row["uid"]);
                TView temp = new TView(uid, name, true);
                views.Add(temp);
            }
            foreach (TView tview in views)
            {
                TreeNode temp = parent.Nodes.Add("", tview.Label, 4);
                if (temp != null)
                {
                    temp.SelectedImageIndex = 4;
                    temp.Tag = new NodeType(ENodeType.VIEW, tview.Name, "master", tview.Uid);
                    temp.Nodes.Add("");
                }

            }
        }

        public void FillViews(TreeNode parent, string dbName) {
            TreeNode viewNode = parent.Nodes.Add("", "系统视图", 0);
            viewNode.Tag = new NodeType(ENodeType.VIEW, "", dbName, -1);
            FillSystemViews(viewNode);
            string sql = "select [name],[uid],category from "+dbName+"..sysobjects where xtype='V' and category = 0 order by uid,name";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = sqlCommand;
            DataSet fill = new DataSet();
            myDataAdapter.Fill(fill);
            ArrayList views = new ArrayList();
            foreach (DataRow row in fill.Tables[0].Rows) {
                string name = row["name"].ToString();
                int uid = Convert.ToInt32(row["uid"]);
                TView temp = new TView(uid, name, false);
                if (temp != null) {
                    views.Add(temp);
                }
                
            }
            
            foreach (TView tview in views) {
                TreeNode temp = temp = parent.Nodes.Add("", tview.Name, 4);
                if (temp != null) {
                    temp.SelectedImageIndex = 4;
                    temp.Tag = new NodeType(ENodeType.VIEW, tview.Name, dbName, tview.Uid);
                    temp.Nodes.Add("");
                }
                
            }
        }

        public void FillSystemProcedure(TreeNode parent) {
            string sql = "select name, uid from master..sysobjects where xtype='P' and category > 0";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = sqlCommand;
            DataSet fill = new DataSet();
            myDataAdapter.Fill(fill);
            ArrayList procedures = new ArrayList();
            foreach (DataRow row in fill.Tables[0].Rows)
            {
                string name = row["name"].ToString();
                int uid = Convert.ToInt32(row["uid"]);
                TProcedure temp = new TProcedure(name, uid, true);
                if (temp != null)
                {
                    procedures.Add(temp);
                }

            }

            foreach (TProcedure tprocedure in procedures)
            {
                TreeNode temp = temp = parent.Nodes.Add("", tprocedure.Name, (int)MARK.PROCEDURE);
                if (temp != null)
                {
                    temp.SelectedImageIndex = (int)MARK.PROCEDURE;
                    temp.Tag = new NodeType(ENodeType.PROCEDURE, tprocedure.Name, "master", tprocedure.Uid);
                    temp.Nodes.Add("");
                }

            }
        }


        public void FillProcedure(TreeNode parent, string dbName) {
            TreeNode systemNode = parent.Nodes.Add("", "系统存储过程", 0);
            systemNode.Tag = new NodeType(ENodeType.PROCEDURE, "", dbName, -1);
            FillSystemProcedure(systemNode);
            string sql = "select [name],[uid] from " + dbName + "..sysobjects where xtype='P' and category = 0 order by uid,name";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = sqlCommand;
            DataSet fill = new DataSet();
            myDataAdapter.Fill(fill);
            ArrayList procedures = new ArrayList();
            foreach (DataRow row in fill.Tables[0].Rows)
            {
                string name = row["name"].ToString();
                int uid = Convert.ToInt32(row["uid"]);
                TProcedure temp = new TProcedure(name, uid, false);
                if (temp != null)
                {
                    procedures.Add(temp);
                }

            }

            foreach (TProcedure tprocedure in procedures)
            {
                TreeNode temp = temp = parent.Nodes.Add("", tprocedure.Name, (int)MARK.PROCEDURE);
                if (temp != null)
                {
                    temp.SelectedImageIndex = (int)MARK.PROCEDURE;
                    temp.Tag = new NodeType(ENodeType.PROCEDURE, tprocedure.Name, dbName, tprocedure.Uid);
                    temp.Nodes.Add("");
                }

            }
        }

        public void FillParameters(TreeNode parent, string dbName) {
            NodeType nodeType = parent.Tag as NodeType;
            string name = nodeType.Name;
            TreeNode paramNode = parent.Nodes.Add("", "参数", 0);

            string sql = "select A.name as column_name, A.isoutparam, A.length as " +                           "character_maximum_length, " +
             "autoval as column_default, B.name as data_type  from  " +
             "master..syscolumns A join master..systypes B on A.xtype=B.xtype " +
             "join master..sysobjects C on A.id=C.id " +
             "where C.name='" + name + "' ";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = sqlCommand;
            DataSet fill = new DataSet();
            myDataAdapter.Fill(fill);
            ArrayList parameters = new ArrayList();
            foreach (DataRow row in fill.Tables[0].Rows)
            {
                string type = row["data_type"].ToString();
                int length = 0;
                string objLength = row["character_maximum_length"].ToString();
                if (objLength.Length > 0)
                {
                    length = Convert.ToInt32(objLength);
                }
                string defValue = row["column_default"].ToString();
                int isout = Convert.ToInt32(row["isoutparam"]);
                bool isoutparam = false;
                if (isout == 1) {
                    isoutparam = true;
                }

                object efield = JustType(type);
                TParameter temp = new TParameter(row["column_name"].ToString(), efield, length, defValue, isoutparam);
                parameters.Add(temp);
            }
            foreach (TParameter parameter in parameters)
            {
                TreeNode temp;
                string param1 = "输入";
                if (parameter.IsOutParam) {
                    param1 = "输入/输出";
                }
                string param2 = "无默认值";
                if (parameter.DefaultValue.Length > 0) {
                    param2 = parameter.DefaultValue;
                }
                if (parameter.Name.Length > 0)
                {
                    temp = paramNode.Nodes.Add("", parameter.Name + "(" + parameter.Type + "(" + parameter.Length + "), " + param1 + ", " + param2 + ")", (int)MARK.PARAMETER);
                }
                else
                {
                    temp = paramNode.Nodes.Add("", parameter.Name + "(" + parameter.Type + ", " + param1 + ", " + param2 + ")", (int)MARK.PARAMETER);
                }

                temp.SelectedImageIndex = (int)MARK.PARAMETER;
                NodeType fieldNodeType = new NodeType(ENodeType.PARAMETER, parameter.Name, dbName, -1);
                temp.Tag = fieldNodeType;
            }
            paramNode.Nodes.Add("", "返回integer", (int)MARK.PARAMETER);
        }

        private object JustType(string type) {
            object efield = 0;
            switch (type)
            {
                case "bit":
                    efield = ENumberField.BIT;
                    break;
                case "tinyint":
                    efield = ENumberField.TINYINT;
                    break;
                case "smallint":
                    efield = ENumberField.SMALLINT;
                    break;
                case "int":
                    efield = ENumberField.INT;
                    break;
                case "bigint":
                    efield = ENumberField.BIGINT;
                    break;
                case "numeric":
                    efield = ENumberField.NUMERIC;
                    break;
                case "decimal":
                    efield = ENumberField.DECIMAL;
                    break;
                case "smallmoney":
                    efield = ENumberField.SMALLMONEY;
                    break;
                case "money":
                    efield = ENumberField.MONEY;
                    break;

                case "float":
                    efield = EFloatNumberField.FLOAT;
                    break;
                case "real":
                    efield = EFloatNumberField.REAL;
                    break;

                case "datetime":
                    efield = EDatetimeField.DATETIME;
                    break;
                case "smalldatetime":
                    efield = EDatetimeField.SMALLDATETIME;
                    break;

                case "char":
                    efield = EStringField.CHAR;
                    break;
                case "varchar":
                    efield = EStringField.VARCHAR;
                    break;
                case "text":
                    efield = EStringField.TEXT;
                    break;

                case "nchar":
                    efield = EUnicodeField.NCHAR;
                    break;
                case "nvarchar":
                    efield = EUnicodeField.NVARCHAR;
                    break;
                case "ntext":
                    efield = EUnicodeField.NTEXT;
                    break;

                case "binary":
                    efield = EBinaryField.BINARY;
                    break;
                case "varbinary":
                    efield = EBinaryField.VARBINARY;
                    break;
                case "image":
                    efield = EBinaryField.IMAGE;
                    break;

                case "sql_variant":
                    efield = EOtherField.SQL_VARIANT;
                    break;
                case "timestamp":
                    efield = EOtherField.TIMESTAMP;
                    break;
                case "uniqueidentifier":
                    efield = EOtherField.UNIQUEIDENTIFIER;
                    break;
                case "xml":
                    efield = EOtherField.XML;
                    break;
                default:
                    efield = "";
                    break;
            }
            return efield;
        }

        public void FillFields(TreeNode parent, string dbName) {
            NodeType nodeType = parent.Tag as NodeType;
            string name = nodeType.Name;
            TreeNode colNode = parent.Nodes.Add("", "列", 0);
            
            string sql = "select A.name as column_name, A.length as character_maximum_length, "+
            "autoval as column_default, B.name as data_type  from "+
            dbName+"..syscolumns A join "+dbName+"..systypes B on A.xtype=B.xtype "+
            "join "+dbName+"..sysobjects C on A.id=C.id "+
            "where C.name='" + name + "' and B.name <>'_default_' and B.name<>'sysname'" +
            " and C.uid="+nodeType.Uid;
            SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = sqlCommand;
            DataSet fill = new DataSet();
            myDataAdapter.Fill(fill);
            ArrayList fields = new ArrayList();
            foreach (DataRow row in fill.Tables[0].Rows) {
                string type = row["data_type"].ToString();
                int length = 0;
                string objLength = row["character_maximum_length"].ToString();
                if ( objLength.Length > 0)
                {
                    length = Convert.ToInt32(objLength);
                }
                string defValue = "null";
                string objectValue = row["column_default"].ToString();
                if (objectValue.Length > 0)
                {
                    defValue = objectValue.ToString();
                }

                object efield = JustType(type);
                TField temp = new TField(row["column_name"].ToString(), efield, length, defValue);
                fields.Add(temp);
            }
            foreach (TField tfield in fields) {
                TreeNode temp;
                if (tfield.Name.Length > 0)
                {
                    temp = colNode.Nodes.Add("", tfield.Name + "(" + tfield.Type + "("+tfield.Length+"), " + tfield.DefaultValue + ")", (int)MARK.COL);
                }
                else {
                    temp = colNode.Nodes.Add("", tfield.Name + "(" + tfield.Type + ", " + tfield.DefaultValue + ")", (int)MARK.COL);
                }

                temp.SelectedImageIndex = (int)MARK.COL;
                NodeType fieldNodeType = new NodeType(ENodeType.FIELD, tfield.Name, dbName, -1);
                temp.Tag = fieldNodeType;
            }
        }

        public List<string> LastSqlInfoMessages = new List<string>();
        public List<string> LastSqlErrorMessages = new List<string>();
        private void HandleSqlInfo(object o, SqlInfoMessageEventArgs e) {
            if (!LastSqlInfoMessages.Contains(e.Message)) {
                LastSqlInfoMessages.Add(e.Message);
            }
            
            foreach (SqlError err in e.Errors) {
                if (!LastSqlErrorMessages.Contains(err.Message)) {
                    LastSqlErrorMessages.Add(err.Message);
                }
            }
        }

        private void DisConnect() {
            if (sqlCon != null)
            {
                try
                {
                    sqlCon.Close();
                    treeViewDatabases.Nodes.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void execute() {
            string sql = "";
            if (sqlContent.ActiveTextAreaControl.SelectionManager.HasSomethingSelected) {
                sql = sqlContent.ActiveTextAreaControl.SelectionManager.SelectedText;
            }
            if(sql.Trim().Length == 0){
                sql = sqlContent.Text.Trim();
            }
            if (sql.Length == 0)
            {
                return;
            }
            if (sqlCon == null || sqlCon.State == ConnectionState.Closed || sqlCon.State == ConnectionState.Broken)
            {
                MessageBox.Show("连接已经关闭，请重新打开连接后再执行sql语句!");
                return;
            }
            bool isError = false;
            bool isSelect = false;
            Info.Clear();
            LastSqlErrorMessages.Clear();
            LastSqlInfoMessages.Clear();
            SqlInfoMessageEventHandler handleMessage = new SqlInfoMessageEventHandler(HandleSqlInfo);
            sqlCon.InfoMessage += handleMessage;
            int effectRows = 0;
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
                DataSet fill = null;
                if (sql.Substring(0, 6) == "select")
                {
                    isSelect = true;
                    SqlDataAdapter myDataAdapter = new SqlDataAdapter();
                    myDataAdapter.SelectCommand = sqlCommand;
                    fill = new DataSet();
                    myDataAdapter.Fill(fill);
                }
                else {
                   effectRows = sqlCommand.ExecuteNonQuery();
                }
                if (fill != null)
                {
                    dataResult.DataSource = fill.Tables[0];
                }
                else {
                    dataResult.DataSource = fill;
                }
            }
            catch (Exception ex)
            {
                isError = true;
                char[] seperates = {'\r', '\n'};
                string[] messages = ex.Message.Split(seperates);
                for (int i = messages.Length - 1; i >= 0; i--) {
                    if (messages[i].Trim().Length > 0) {
                        LastSqlErrorMessages.Add(messages[i] + "\r\n");
                    }
                }
                
            }
            sqlCon.InfoMessage -= handleMessage;

            string msg = "";
            if (isError)
            {
                foreach (string error in LastSqlErrorMessages) {
                    msg += error;
                }
            }
            else {
                if (effectRows >= 0) {
                    LastSqlInfoMessages.Add(effectRows + "行受影响");
                }
                
                foreach (string info in LastSqlInfoMessages)
                {
                    msg += info;
                }
            }
            
            msg += "\r\n";
            
            Info.Text = msg;
            if (isError || !isSelect)
            {
                tabControlResult.SelectedTab = tabInfo;
            }
            else{
                tabControlResult.SelectedTab = tabResult;
            }
        }

        private void treeViewDatabases_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            NodeType nodeType = e.Node.Tag as NodeType;

            if (nodeType != null )
            {
                
                if (nodeType.Type == ENodeType.TABLE) {
                    
                    if (nodeType.Name.Length > 0) {
                        e.Node.Nodes.Clear();
                        FillFields(e.Node, nodeType.DbName);
                    }
                }
                else if (nodeType.Type == ENodeType.VIEW) {
                    if (e.Node.Text != "系统视图") {
                        e.Node.Nodes.Clear();
                        if (nodeType.Name.Length == 0)
                        {
                            FillViews(e.Node, nodeType.DbName);
                        }
                        else
                        {
                            FillFields(e.Node, nodeType.DbName);
                        }
                    }
                }
                else if (nodeType.Type == ENodeType.PROCEDURE) {
                    if (e.Node.Text != "系统存储过程") {
                        e.Node.Nodes.Clear();
                        if (nodeType.Name.Length == 0)
                        {
                            FillProcedure(e.Node, nodeType.DbName);
                        }
                        else {
                            FillParameters(e.Node, nodeType.DbName);
                        }
                    }
                }
            }
            
        }

        private void treeViewDatabases_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NodeType nodeType = e.Node.Tag as NodeType;
            if (nodeType != null)
            {
                propertyGrid1.SelectedObject = nodeType;
            }
            else {
                propertyGrid1.SelectedObject = null;
            }
        }

        private void opendb_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void closedb_Click(object sender, EventArgs e)
        {
            DisConnect();
        }

        private void run_Click(object sender, EventArgs e)
        {
            execute();
        }
    }
}
