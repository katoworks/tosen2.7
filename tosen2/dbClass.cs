using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace tosen2
{

    class dbClass
    {
        public string ipaddr { set; get; }
        public string userid { set; get; }
        public string pasword { set; get; }
        public string database { set; get; }
        public string host { get; set; }

        public string cnnStr;
        public MySqlConnection cn;
        private string listFileName = @".\conf\tosen.txt";

        public dbClass()
        {

            //this.ipaddr = "asa-internet.co.jp";
            //this.ipaddr = "153.127.10.253";
            this.ipaddr = "localhost";
            //this.database = "tosen";
            this.database = "tosen";
            this.userid = "db_user";
            this.pasword = "jiji1215";

            // 設定ファイル読み込み
            confInit();

            cnnStr = string.Format("Server={0};Database={1};Uid={2};Pwd={3}",
                this.ipaddr,
                this.database,
                this.userid,
                this.pasword);
        }
        private void confInit()
        {
            char[] sep = { '=' };
            string mLineBuff;

            // ファイルの読み込み
            System.IO.StreamReader sr = new System.IO.StreamReader(listFileName,Encoding.GetEncoding("shift_jis"));

            while ((mLineBuff = sr.ReadLine()) != null)
            {
                var mTmpSpl = mLineBuff.Split(sep);
                switch (mTmpSpl[0])
                {
                    case "host":
                        this.ipaddr = mTmpSpl[1];
                        break;
                    case "user":
                        this.userid = mTmpSpl[1];
                        break;
                    case "pass":
                        this.pasword = mTmpSpl[1];
                        break;
                    case "db":
                        this.database = mTmpSpl[1];
                        break;
                }
            }
            sr.Close();
        }

        public List<string> getKindList()
        {
            string tb = this.database;
            string sql = string.Format("select kindName from {0}.kind where kind!=99 order by kind", tb);
            this.cn = new MySqlConnection(cnnStr);

            List<string> tmpDat = new List<string>();
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tmpDat.Add(reader[0].ToString());
                        }
                    }
                    this.cn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return tmpDat;
        }

        public int getcomMemberCnt(string lWord)
        {
            int retVal = 0;
            string sc = this.database;
            string sql = string.Format("select count(setaiNo) from {0}.comTable where comSimei Like '%{1}%' order by setaiNo,famiNo ", sc, lWord);
            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.cn.Close();

            return retVal;
        }
        public int getCntGrp(string lWord)
        {

            int retVal = 0;
            string sc = this.database;
            string sql = string.Format("select count(a.setaiNo) from {0}.famiAddr a left join {0}.kind b on a.kind=b.kind where b.kindName='{1}' order by setaiNo, famiNo", sc, lWord);
            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.cn.Close();

            return retVal;
        }
        public int getCntGrp2(string lWord,string sWord1, string sWord2)
        {

            int retVal = 0;
            string sc = this.database;
            string srWord1 = "";
            string srWord2 = "";

            // 検索ワード生成
            if (sWord1.Length > 0)
            {
                srWord1 = " AND b.address like '%" + sWord1 + "%'";
            }

            if (sWord2.Length > 0)
            {
                srWord2 = " AND a.nameRubi Like '%" + sWord2 + "%'";
            }
            string sql = string.Format("select count(a.setaiNo) from {0}.famiAddr a left join {0}.kind b on a.kind=b.kind where b.kindName='{1}' {2} {3} order by setaiNo, famiNo", sc, lWord, srWord1, srWord2);
            sql = string.Format("select count(a.setaiNo) from tosen.baseAddr a left join tosen.famiAddr b on a.setaiNo=b.setaiNo left join tosen.comTable c on a.setaiNo=c.setaiNo left join tosen.kind d on a.kind=d.kind where d.kindName='{1}' {2} {3}  order by b.setaiNo,b.famiNo", sc, lWord, srWord1, srWord2);
            if (lWord == "全て")
            {
//                sql = string.Format("select count(*) from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.kind c on b.kind=c.kind where a.name!=''", sc);
                sql = string.Format("select count(*) from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join tosen.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) left join {0}.kind d on a.kind=d.kind where a.name!=''", sc);
                if (srWord1.Length!=0 && srWord2.Length != 0) 
                {
                    //sql = string.Format("select count(*) from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.kind d on b.kind=d.kind where a.name!='' {1} {2}", sc, srWord1, srWord2);
                    sql = string.Format("select count(*) from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join tosen.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) left join {0}.kind d on a.kind=d.kind where a.name!='' {1} {2}", sc, srWord1, srWord2);
                }
                if (srWord1.Length!=0 && srWord2.Length == 0) 
                {
                    //sql = string.Format("select count(*) from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.kind c on b.kind=c.kind where a.name!='' {1}", sc, srWord1);
                    sql = string.Format("select count(*) from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join tosen.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) left join {0}.kind d on a.kind=d.kind where a.name!='' {1}", sc, srWord1);
                }
                if (srWord1.Length ==0 && srWord2.Length != 0) 
                {
                    //sql = string.Format("select count(*) from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.kind c on b.kind=c.kind where a.name!='' {1}", sc, srWord2);
                    sql = string.Format("select count(*) from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join tosen.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) left join {0}.kind d on a.kind=d.kind where a.name!='' {1}", sc, srWord2);
                }
                if(srWord1.Length==0 && srWord2.Length == 0)
                {
                    sql = string.Format("select count(*) from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.kind c on b.kind=c.kind where a.name!='' ", sc);
                }

            }
            else
            {
               // sql = string.Format("select count(*) from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.kind c on b.kind=c.kind where c.kindName='{1}' {2} {3}", sc, lWord, srWord1, srWord2);
                sql = string.Format("select count(*) from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join tosen.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) left join {0}.kind d on a.kind=d.kind where d.kindName='{1}' {2}", sc, lWord, srWord1, srWord2);

            }
            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.cn.Close();

            return retVal;
        }
        public int getCntGrp3(string lWord,string sWord1, string sWord2)
        {

            int retVal = 0;
            string sc = this.database;

            string srWord1 = "";
            string srWord2 = "";
            string sql;

            // 検索ワード生成
            if (sWord1.Length > 0)
            {
                srWord1 = " a.address like '%" + sWord1 + "%'";
            }

            if (sWord2.Length > 0)
            {
                srWord2 = "  a.nameRubi Like '%" + sWord2 + "%'";
                if (sWord1.Length != 0)
                {
                    srWord2 = " AND " + srWord2;
                }
            }
            //string sql = string.Format("select count(a.setaiNo) from {0}.famiAddr a left join {0}.kind b on a.kind=b.kind where b.kindName='{1}' {2} {3} order by setaiNo, famiNo", sc, lWord, srWord1, srWord2);
            //sql = string.Format("select count(a.setaiNo) from tosen.baseAddr a left join tosen.famiAddr b on a.setaiNo=b.setaiNo left join tosen.comTable c on a.setaiNo=c.setaiNo left join tosen.kind d on b.kind=d.kind where d.kindName='{1}' {2} {3}  order by b.setaiNo,b.famiNo", sc, lWord, srWord1, srWord2);
            if (lWord == "全て")
            {
                sql = string.Format("select count(*) from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.kind c on b.kind=c.kind where {1} {2}", sc, srWord1, srWord2);
                sql = string.Format("select count(*) from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) left join {0}.kind d on a.kind=d.kind", sc);
            }
            else
            {
                sql = string.Format("select count(*) from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.kind c on b.kind=c.kind where c.kindName='{1}' {2} {3}", sc, lWord, srWord1, srWord2);
            }
            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.cn.Close();

            return retVal;
        }
        public int getcomMemberRubiCnt(string lWord)
        {
            int retVal = 0;
            string sc = this.database;
            string sql = string.Format("select count(setaiNo) from {0}.comTable where comSimeiRubi Like '%{1}%' order by setaiNo,famiNo ", sc, lWord);
            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.cn.Close();

            return retVal;
        }

        public int getcomNameCnt(string lWord)
        {
            int retVal = 0;
            string sc = this.database;
            string sql = string.Format("select count(setaiNo) from {0}.comTable where comName Like '%{1}%' order by setaiNo,famiNo ", sc, lWord);
            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.cn.Close();

            return retVal;
        }
        public int getSetaiNo()
        {
            int retVal = 0;
            string sc = this.database;
            string sql = string.Format("select max(setaiNo) from {0}.baseAddr", sc);
            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.cn.Close();

            return retVal;
        }
        public int getSetaiKana(string lWord)
        {
            int retVal = 0;
            string sc = this.database;
            string sql = string.Format("select count(setaiNo) from {0}.famiAddr where nameRubi Like '%{1}%'", sc, lWord);
            //sql = string.Format("select a.setaiNo,b.famiNo,d.kindName,b.name,b.nameRubi,c.comName, a.zipCode,a.address,c.comKata from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName having b.nameRubi='%{1}%' order by b.setaiNo,b.famiNo", sc, lWord);
            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.cn.Close();

            return retVal;
        }
        public int getSetaiKan(string lWord)
        {
            int retVal = 0;
            string sc = "tosen";
            sc = this.database;
            string sql = string.Format("select count(setaiNo) from {0}.famiAddr where name Like '%{1}%'", sc, lWord);
            //sql = string.Format("select a.setaiNo,b.famiNo,d.kindName,b.name,b.nameRubi,c.comName, a.zipCode,a.address,c.comKata from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName having b.name='%{1}%' order by b.setaiNo,b.famiNo", sc, lWord);
            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.cn.Close();

            return retVal;
        }

        public int getGrpOut(ref DataGridView outDT,string mWord)
        {
            int retVal = 0;
            int recCnt = 0;
            int ct = 0;
            string mSql = "";
            string mTable = "tosen";
            mTable = this.database;

            // DataGridView 初期化
            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            outDT.Columns.Add(clm);
            outDT.Columns.Add("", "世帯番号");
            outDT.Columns.Add("", "氏名");
            outDT.Columns.Add("", "郵便番号");
            outDT.Columns.Add("", "住所");
            outDT.Columns.Add("", "会社名");
            outDT.Columns.Add("", "肩書");
            outDT.Columns.Add("", "世帯人数");
            outDT.ColumnCount = 8;
            outDT.Columns[0].Width = 50;
            outDT.Columns[1].Width = 70;
            outDT.Columns[2].Width = 200;
            outDT.Columns[3].Width = 100;
            outDT.Columns[4].Width = 400;
            outDT.Columns[5].Width = 200;
            outDT.Columns[6].Width = 100;
            outDT.Columns[7].Width = 70;
            outDT.AutoGenerateColumns = true;
            outDT.AllowUserToAddRows = false;

            mSql = string.Format("select a.setaiNo,b.famiNo, a.name, a.zipCode, a.address,d.comName,d.comKata,count(distinct b.famiNo) from {0}.baseAddr a inner join {0}.famiAddr b on a.setaiNo = b.setaiNo inner join {0}.kind c on b.kind = c.kind left join {0}.comTable d on (b.setaiNo=d.setaiNo AND b.famiNo=d.famiNo) where c.kindName = '{1}' group by a.setaiNo,a.name,a.address order by setaiNo", mTable, mWord);
            ct = this.getCntGrp2(mWord);
            if (ct > 0)
            {
                outDT.Rows.Add(ct);
                retVal = ct;

                this.cn = new MySqlConnection(cnnStr);
                using (var cmd = this.cn.CreateCommand())
                {
                    try
                    {
                        this.cn.Open();
                        cmd.CommandText = mSql;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                outDT.Rows[recCnt].Cells[0].Value = true;
                                outDT.Rows[recCnt].Cells[1].Value = reader[0].ToString();
                                outDT.Rows[recCnt].Cells[2].Value = reader[2].ToString();
                                outDT.Rows[recCnt].Cells[3].Value = reader[3].ToString();
                                outDT.Rows[recCnt].Cells[4].Value = reader[4].ToString();
                                outDT.Rows[recCnt].Cells[5].Value = reader[5].ToString();
                                outDT.Rows[recCnt].Cells[6].Value = reader[6].ToString();
                                outDT.Rows[recCnt].Cells[7].Value = reader[7].ToString();
                                recCnt++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                MessageBox.Show("データが存在しませんでした。");
            }

            return retVal;  
        }
        public int getCntGrp2(string lWord)
        {

            int retVal = 0;
            string sc = this.database;
            string sql = string.Format("select count(distinct b.setaiNo) from {0}.baseAddr a inner join {0}.famiAddr b on a.setaiNo=b.setaiNo inner join {0}.kind c on b.kind=c.kind where c.kindName='{1}'", sc, lWord);
            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.cn.Close();

            return retVal;
        }
        public int getGrpOut( ref DataGridView outDT,int srchMode,string mWord)
        {
            int recCnt = 0;
            int ct = 0;
            string mSql = "";
            string mTable = "tosen";

            // DataGridView 初期化
            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            outDT.Columns.Add(clm);
            outDT.Columns.Add("", "世帯番号");
            outDT.Columns.Add("", "家族番号");
            outDT.Columns.Add("", "グループ名");
            outDT.Columns.Add("", "氏名");
            outDT.Columns.Add("", "氏名カナ");
            outDT.Columns.Add("", "会社名");
            outDT.Columns.Add("", "会社郵便番号");
            outDT.Columns.Add("", "会社住所");
            outDT.Columns.Add("", "肩書");
            outDT.ColumnCount = 10;
            outDT.Columns[0].Width = 50;
            outDT.Columns[1].Width = 70;
            outDT.Columns[2].Width = 70;
            outDT.Columns[3].Width = 200;
            outDT.Columns[4].Width = 130;
            outDT.Columns[5].Width = 130;
            outDT.Columns[6].Width = 130;
            outDT.Columns[7].Width = 130;
            outDT.Columns[8].Width = 480;
            outDT.Columns[9].Width = 100;
            outDT.AutoGenerateColumns = true;
            outDT.AllowUserToAddRows = false;

            ct = this.getCntGrp(mWord);
            mSql = string.Format("select a.setaiNo,b.famiNo,c.kindName,b.name,b.nameRubi,d.comName, a.zipCode,a.address,d.comKata from {0}.baseAddr a inner join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable d on a.setaiNo=d.setaiNo inner join {0}.kind c on b.kind = c.kind group by a.setaiNo,b.famiNo,c.kindName,a.name,a.nameRubi,d.comName, a.zipCode,a.address having c.kindName = '{1}' order by a.setaiNo,b.famiNo", mTable, mWord);
            mSql = string.Format("select a.setaiNo,b.famiNo,d.kindName,b.name,b.nameRubi,c.comName, a.zipCode,a.address,c.comKata from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName having d.kindName='{1}' order by b.setaiNo,b.famiNo", mTable, mWord);
            if (ct > 0)
            {
                outDT.Rows.Add(ct);

                this.cn = new MySqlConnection(cnnStr);
                using (var cmd = this.cn.CreateCommand())
                {
                    try
                    {
                        this.cn.Open();
                        cmd.CommandText = mSql;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                outDT.Rows[recCnt].Cells[0].Value = true;
                                outDT.Rows[recCnt].Cells[1].Value = reader[0].ToString();
                                outDT.Rows[recCnt].Cells[2].Value = reader[1].ToString();
                                outDT.Rows[recCnt].Cells[3].Value = reader[2].ToString();
                                outDT.Rows[recCnt].Cells[4].Value = reader[3].ToString();
                                outDT.Rows[recCnt].Cells[5].Value = reader[4].ToString();
                                outDT.Rows[recCnt].Cells[6].Value = reader[5].ToString();
                                outDT.Rows[recCnt].Cells[7].Value = reader[6].ToString();
                                outDT.Rows[recCnt].Cells[8].Value = reader[7].ToString();
                                outDT.Rows[recCnt].Cells[9].Value = reader[8].ToString();
                                recCnt++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                MessageBox.Show("データが存在しませんでした。");
            }

            return ct;
        }
        public int getGrpOut2(ref DataGridView outDT, int srchMode, string mWord,string sWord1,string sWord2) 
        {
            int recCnt = 0;
            int ct = 0;
            string mSql = "";
            string mTable = this.database;
            string srWord1 = "";
            string srWord2 = "";

            // DataGridView 初期化
            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            outDT.Columns.Add(clm);
            outDT.Columns.Add("", "世帯番号");
            outDT.Columns.Add("", "家族番号");
         //   outDT.Columns.Add("", "グループ名");
            outDT.Columns.Add("", "氏名");
            outDT.Columns.Add("", "氏名カナ");
            outDT.Columns.Add("", "電話番号");
            outDT.Columns.Add("", "郵便番号");
            outDT.Columns.Add("", "住所");
            outDT.Columns.Add("", "会社名");
            outDT.Columns.Add("", "肩書");
            outDT.ColumnCount = 10;
            outDT.Columns[0].Width = 50;
            outDT.Columns[1].Width = 70;
            outDT.Columns[2].Width = 70;
            outDT.Columns[3].Width = 200;
            outDT.Columns[3].Width = 130;
            outDT.Columns[4].Width = 130;
            outDT.Columns[5].Width = 130;
            outDT.Columns[6].Width = 130;
            outDT.Columns[7].Width = 480;
            outDT.Columns[8].Width = 300;
         //   outDT.Columns[9].Width = 120;
            outDT.AutoGenerateColumns = true;
            outDT.AllowUserToAddRows = false;

            ct = this.getCntGrp2(mWord, sWord1, sWord2);

            // 検索ワード生成
            if (sWord1.Length > 0)
            {
                srWord1 = " where b.address like '%" + sWord1 + "%'";
            }

            if (sWord2.Length > 0)
            {
                if (sWord1.Length > 0)
                {
                    srWord2 = " AND b.nameRubi Like '%" + sWord2 + "%'";
                }
                else
                {
                    srWord2 = " Where b.nameRubi Like '%" + sWord2 + "%'";
                }
            }

            string mWhere = srWord1 + srWord2;
            string aaa = " AND ";

            if (mWord == "全て")
            {
                //ct = this.getCntGrp3(mWord, sWord1, sWord2);
                if (sWord1.Length > 0)
                {
                    srWord1 = " a.address like '%" + sWord1 + "%'";
                }

                if (sWord2.Length > 0)
                {
                    srWord2 = " b.nameRubi Like '%" + sWord2 + "%'";
                    if (sWord1.Length != 0)
                    {
                        srWord2 = aaa + srWord2;
                    }
                }

//                mSql = string.Format("select a.setaiNo,b.famiNo,d.kindName,b.name,b.nameRubi,c.comName, a.zipCode,a.address,c.comKata from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName having {1} {2} order by b.setaiNo,b.famiNo", mTable, srWord1,srWord2);
//                mSql = string.Format("select a.setaiNo,b.famiNo,d.kindName,b.name,b.nameRubi,c.comName, a.zipCode,a.address,c.comKata from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo ,b.name,b.nameRubi,d.kindName,a.zipCode,a.address having b.name!='' order by b.setaiNo,b.famiNo", mTable);
//                mSql = string.Format("select a.setaiNo,a.famiNo,d.kindName,a.name,a.nameRubi,a.tel,b.zipCode, b.address,c.comName,c.comKata from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) left join {0}.kind d on a.kind=d.kind order by a.setaiNo, a.famiNo", mTable);
                mSql = string.Format("select a.setaiNo,a.famiNo,a.name,a.nameRubi,a.tel,b.zipCode, b.address,c.comName,c.comKata from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) left join {0}.kind d on a.kind=d.kind {1} group by a.setaiNo,a.famiNo, a.name,a.nameRubi,a.tel,b.zipCode, b.address,c.comName,c.comKata order by a.setaiNo, a.famiNo", mTable, mWhere);
            }
            else {
                //mSql = string.Format("select a.setaiNo,b.famiNo,d.kindName,b.name,b.nameRubi,c.comName, a.zipCode,a.address,c.comKata from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName having d.kindName='{1}' {2} {3} order by b.setaiNo,b.famiNo", mTable, mWord,srWord1,srWord2);
               srWord1 = " AND b.address like '%" + sWord1 + "%'";
               mSql = string.Format("select a.setaiNo,a.famiNo,a.name,a.nameRubi,a.tel,b.zipCode, b.address,c.comName,c.comKata from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) left join {0}.kind d on a.kind=d.kind where d.kindName='{1}' {2} {3} group by a.setaiNo,a.famiNo, a.name,a.nameRubi,a.tel,b.zipCode, b.address,c.comName,c.comKata order by a.setaiNo, a.famiNo", mTable, mWord,srWord1,srWord2);
            }
            if (ct > 0)
            {
                outDT.Rows.Add(ct);

                this.cn = new MySqlConnection(cnnStr);
                using (var cmd = this.cn.CreateCommand())
                {
                    try
                    {
                        this.cn.Open();
                        cmd.CommandText = mSql;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                outDT.Rows[recCnt].Cells[0].Value = true;
                                outDT.Rows[recCnt].Cells[1].Value = reader[0].ToString();
                                outDT.Rows[recCnt].Cells[2].Value = reader[1].ToString();
                                outDT.Rows[recCnt].Cells[3].Value = reader[2].ToString();
                                outDT.Rows[recCnt].Cells[4].Value = reader[3].ToString();
                                outDT.Rows[recCnt].Cells[5].Value = reader[4].ToString();
                                outDT.Rows[recCnt].Cells[6].Value = reader[5].ToString();
                                outDT.Rows[recCnt].Cells[7].Value = reader[6].ToString();
                                outDT.Rows[recCnt].Cells[8].Value = reader[7].ToString();
                                outDT.Rows[recCnt].Cells[9].Value = reader[8].ToString();
         //                       outDT.Rows[recCnt].Cells[10].Value = reader[9].ToString();
                                recCnt++;
                            }
                        }
                        outDT.RowCount = recCnt;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                MessageBox.Show("データが存在しませんでした。");
            }

            return ct;
        }
        public int getGrpOut2(ref DataGridView outDT, int srchMode, string mWord)
        {
            int recCnt = 0;
            int ct = 0;
            string mSql = "";
            string mTable = this.database;

            // DataGridView 初期化
            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            outDT.Columns.Add(clm);
            outDT.Columns.Add("", "世帯番号");
            outDT.Columns.Add("", "家族番号");
            outDT.Columns.Add("", "グループ名");
            outDT.Columns.Add("", "氏名");
            outDT.Columns.Add("", "氏名カナ");
            outDT.Columns.Add("", "会社名");
            outDT.Columns.Add("", "会社郵便番号");
            outDT.Columns.Add("", "会社住所");
            outDT.Columns.Add("", "肩書");
            outDT.ColumnCount = 10;
            outDT.Columns[0].Width = 50;
            outDT.Columns[1].Width = 70;
            outDT.Columns[2].Width = 70;
            outDT.Columns[3].Width = 200;
            outDT.Columns[4].Width = 130;
            outDT.Columns[5].Width = 130;
            outDT.Columns[6].Width = 130;
            outDT.Columns[7].Width = 130;
            outDT.Columns[8].Width = 480;
            outDT.Columns[9].Width = 100;
            outDT.AutoGenerateColumns = true;
            outDT.AllowUserToAddRows = false;

            ct = this.getCntGrp(mWord);
            if (srchMode == 0)
            {
                mSql = string.Format("select a.setaiNo,b.famiNo,d.kindName,b.name,b.nameRubi,c.comName, a.zipCode,a.address,c.comKata from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName having d.kindName='{1}' order by b.setaiNo,b.famiNo", mTable, mWord);
            }
            else if (srchMode == 1)
            {
                mSql = string.Format("select a.setaiNo,b.famiNo,d.kindName,b.name,b.nameRubi,c.comName, a.zipCode,a.address,c.comKata from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName order by b.setaiNo,b.famiNo", mTable);
            }
            if (ct > 0)
            {
                outDT.Rows.Add(ct);

                this.cn = new MySqlConnection(cnnStr);
                using (var cmd = this.cn.CreateCommand())
                {
                    try
                    {
                        this.cn.Open();
                        cmd.CommandText = mSql;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                outDT.Rows[recCnt].Cells[0].Value = true;
                                outDT.Rows[recCnt].Cells[1].Value = reader[0].ToString();
                                outDT.Rows[recCnt].Cells[2].Value = reader[1].ToString();
                                outDT.Rows[recCnt].Cells[3].Value = reader[2].ToString();
                                outDT.Rows[recCnt].Cells[4].Value = reader[3].ToString();
                                outDT.Rows[recCnt].Cells[5].Value = reader[4].ToString();
                                outDT.Rows[recCnt].Cells[6].Value = reader[5].ToString();
                                outDT.Rows[recCnt].Cells[7].Value = reader[6].ToString();
                                outDT.Rows[recCnt].Cells[8].Value = reader[7].ToString();
                                outDT.Rows[recCnt].Cells[9].Value = reader[8].ToString();
                                recCnt++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                MessageBox.Show("データが存在しませんでした。");
            }

            return ct;
        }

        public int getComOut( ref DataGridView outDT , int srchMode,string mWord)
        {
            int retCnt = 0;
            int recCnt = 0;
            int ct = 0;
            string mSql = "";
            string mTable = this.database;

            // DataGridView 初期化
            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            outDT.Columns.Add(clm);
            outDT.Columns.Add("", "世帯番号");
            outDT.Columns.Add("", "家族番号");
            outDT.Columns.Add("", "会社名");
            outDT.Columns.Add("", "担当者氏名");
            outDT.Columns.Add("", "担当者氏名カナ");
            outDT.Columns.Add("", "会社郵便番号");
            outDT.Columns.Add("", "会社住所");
            outDT.Columns.Add("", "肩書");
            outDT.ColumnCount = 9;
            outDT.Columns[0].Width = 50;
            outDT.Columns[1].Width = 70;
            outDT.Columns[2].Width = 70;
            outDT.Columns[3].Width = 200;
            outDT.Columns[4].Width = 130;
            outDT.Columns[5].Width = 130;
            outDT.Columns[6].Width = 130;
            outDT.Columns[7].Width = 480;
            outDT.Columns[8].Width = 130;
            outDT.AutoGenerateColumns = true;
            outDT.AllowUserToAddRows = false;

            switch (srchMode)
            {
                case 1:
                    ct = this.getcomMemberCnt(mWord);
                    mSql = string.Format("select setaiNo,famiNo, comName, comSimei, comSimeiRubi, comZip, comAddr , comKata from {0}.comTable where comSimei Like '%{1}%' order by setaiNo,famiNo;", mTable, mWord);
                    break;
                case 0:
                    ct = this.getcomMemberRubiCnt(mWord);
                    mSql = string.Format("select setaiNo,famiNo, comName, comSimei, comSimeiRubi, comZip, comAddr , comKata from {0}.comTable where comSimeiRubi Like '%{1}%' order by setaiNo,famiNo;", mTable, mWord);
                    break;
                case 2:
                    ct = this.getcomNameCnt(mWord);
                    mSql = string.Format("select setaiNo,famiNo, comName, comSimei, comSimeiRubi, comZip, comAddr , comKata from {0}.comTable where comName Like '%{1}%' order by setaiNo,famiNo;", mTable, mWord);
                    break;
            }

            if (ct > 0)
            {
                outDT.Rows.Add(ct);

                this.cn = new MySqlConnection(cnnStr);
                using (var cmd = this.cn.CreateCommand())
                {
                    try
                    {
                        this.cn.Open();
                        cmd.CommandText = mSql;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                outDT.Rows[recCnt].Cells[0].Value = false;
                                outDT.Rows[recCnt].Cells[1].Value = reader[0].ToString();
                                outDT.Rows[recCnt].Cells[2].Value = reader[1].ToString();
                                outDT.Rows[recCnt].Cells[3].Value = reader[2].ToString();
                                outDT.Rows[recCnt].Cells[4].Value = reader[3].ToString();
                                outDT.Rows[recCnt].Cells[5].Value = reader[4].ToString();
                                outDT.Rows[recCnt].Cells[6].Value = reader[5].ToString();
                                outDT.Rows[recCnt].Cells[7].Value = reader[6].ToString();
                                outDT.Rows[recCnt].Cells[8].Value = reader[7].ToString();
                                recCnt++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                MessageBox.Show("データが存在しませんでした。");
            }

            return retCnt;
        }

        public int getSetaiOut(ref DataGridView outDT, int kanaMode, string mWord)
        {
            int recCnt = 0;
            int ct = 0;
            string mSql;
            //string mTable = "";
            string schime = this.database;

            // DataGridView 初期化
            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            outDT.Columns.Add(clm);
            outDT.Columns.Add("", "世帯番号");
            outDT.Columns.Add("", "家族番号");
            outDT.Columns.Add("", "氏　　名");
            outDT.Columns.Add("", "氏名カナ");
            outDT.Columns.Add("", "郵便番号");
            outDT.Columns.Add("", "住　　所");
            outDT.Columns.Add("", "会 社 名");
            outDT.Columns.Add("", "肩　　書");
            outDT.ColumnCount = 9;
            outDT.Columns[0].Width = 50;
            outDT.Columns[1].Width = 110;
            outDT.Columns[2].Width = 110;
            outDT.Columns[3].Width = 110;
            outDT.Columns[4].Width = 150;
            outDT.Columns[5].Width = 150;
            outDT.Columns[6].Width = 550;
            outDT.Columns[7].Width = 150;
            outDT.Columns[8].Width = 150;
            outDT.AutoGenerateColumns = true;
            outDT.AllowUserToAddRows = false;

            if (kanaMode == 0)
            {
                ct = this.getSetaiKana(mWord);
                //mTable = "nameRubi";
                mSql = string.Format("select a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName having b.nameRubi like '%{1}%' order by b.setaiNo,b.famiNo", schime,  mWord);
                mSql = string.Format("select a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) group by a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName having a.nameRubi like '%{1}%' order by a.setaiNo,a.famiNo", schime, mWord);
                mSql = string.Format("select a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) where a.nameRubi like '%{1}%' order by a.setaiNo,a.famiNo", schime, mWord);
                mSql = string.Format("select a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName,c.comKata from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) group by a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName,c.comKata having a.nameRubi like '%{1}%' order by a.setaiNo,a.famiNo", schime, mWord);
                mSql = string.Format(@"select a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName,c.comKata from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) group by a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName,c.comKata having a.nameRubi Like '%{1}%' order by a.setaiNo,a.famiNo", schime, mWord);
            }
            else
            {
                //mTable = "name";
                ct = this.getSetaiKan(mWord);
                mSql = string.Format("select a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo ,b.name,b.nameRubi,a.zipCode,a.address,d.kindName having b.name like '%{1}%' order by b.setaiNo,b.famiNo", schime, mWord);
                mSql = string.Format("select a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) group by a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName having a.name like '%{1}%' order by a.setaiNo,a.famiNo", schime, mWord);
                mSql = string.Format("select a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) where a.name like '%{1}%' order by a.setaiNo,a.famiNo", schime, mWord);
                mSql = string.Format(@"select a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName,c.comKata from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) group by a.setaiNo,a.famiNo,a.name,a.nameRubi, b.zipCode,b.address,c.comName,c.comKata having a.name like '%{1}%' order by a.setaiNo,a.famiNo", schime, mWord);
            }
            if (ct > 0)
            {

                outDT.Rows.Add(ct);

                //データ読み込み
                this.cn = new MySqlConnection(cnnStr);
                using (var cmd = this.cn.CreateCommand())
                {
                    try
                    {
                        this.cn.Open();
                        cmd.CommandText = mSql;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                outDT.Rows[recCnt].Cells[0].Value = false;
                                outDT.Rows[recCnt].Cells[1].Value = reader[0].ToString();
                                outDT.Rows[recCnt].Cells[2].Value = reader[1].ToString();
                                outDT.Rows[recCnt].Cells[3].Value = reader[2].ToString();
                                outDT.Rows[recCnt].Cells[4].Value = reader[3].ToString();
                                outDT.Rows[recCnt].Cells[5].Value = reader[4].ToString();
                                outDT.Rows[recCnt].Cells[6].Value = reader[5].ToString();
                                outDT.Rows[recCnt].Cells[7].Value = reader[6].ToString();

                                outDT.Rows[recCnt].Cells[8].Value = reader[7].ToString();
                                recCnt++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                MessageBox.Show("データが存在しませんでした。");
            }
            return ct;
        }
        public List<setaiInfoBeen> getSetaiInfo(string sql)
        {
            List<setaiInfoBeen> retVal = new List<setaiInfoBeen>();
            setaiInfoBeen st = new setaiInfoBeen();
            List<string> stt = new List<string>();
            //            int cnt = 0;
            string mmt;

            this.cn = new MySqlConnection(cnnStr);
            using (var cmd = this.cn.CreateCommand())
            {
                try
                {
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mmt = reader[0].ToString() + "," ;
                            mmt += reader[1].ToString() + ",";
                            mmt += reader[2].ToString() + ",";
                            mmt += reader[3].ToString() + ",";
                            mmt += reader[4].ToString();
                            stt.Add(mmt);

                        }
                        setaiInfoBeen[] gt = chgCsv(stt);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return retVal;
        }

        private setaiInfoBeen[] chgCsv(List<string> line)
        {
            int cnt = line.Count;
            char[] sp = new char[] { ',' };
            List<setaiInfoBeen> retVal = new List<setaiInfoBeen>();
            setaiInfoBeen mTmp = new setaiInfoBeen();

            foreach(string st in line)
            {
                var mmsp = st.Split(sp);
                mTmp.setaiNo = int.Parse(mmsp[0]);
                mTmp.zipCode = mmsp[1];
                mTmp.address = mmsp[2];
                mTmp.name = mmsp[3];
                mTmp.nameRubi = mmsp[4];
                retVal.Add(mTmp);
            }

            DataTable dt = new DataTable();

            setaiInfoBeen[] stt = new setaiInfoBeen[cnt];
            int mCnt = 0;

            foreach (string mLine in line)
            {
                string[] mSp = mLine.Split(sp);
                stt[mCnt].setaiNo = int.Parse(mSp[0]);
                stt[mCnt].zipCode = mSp[1];
                stt[mCnt].address = mSp[2];
                stt[mCnt].name = mSp[3];
                stt[mCnt].nameRubi = mSp[4];
                mCnt++;
            }


            return stt;
        }
    }
}