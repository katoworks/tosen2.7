using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace tosen2
{
    public class baseAddrDAO
    {
        public string ipaddr { set; get; }
        public string userid { set; get; }
        public string pasword { set; get; }
        public string database { set; get; }
        public string cnnStr;
        public MySqlConnection cn;
        private memberInfoDTO member;
        private string listFileName = @".\conf\tosen.txt";
        private string expPath = @".\data\";

        public baseAddrDAO()
        {
            //this.ipaddr = "153.127.10.253";
            this.ipaddr = "localhost";
            this.database = "tosen";
            this.userid = "db_user";
            this.pasword = "jiji1215";

            // 設定ファイル読み込み
            confInit();

            cnnStr = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Charset=utf8;",
                this.ipaddr,
                this.database,
                this.userid,
                this.pasword);

            // Beanの初期化
            member = new memberInfoDTO();

        }

        public setaiInfoBeen getInfo(int setaiNo)
        {
            setaiInfoBeen retVal = new setaiInfoBeen();

            string sql = string.Format("select * from {0}.baseAddr where setaiNo = {1}",this.database, setaiNo);
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.setaiNo = setaiNo;
                            retVal.zipCode = reader[1].ToString();
                            retVal.address = reader[2].ToString();
                            retVal.name = reader[3].ToString();
                            retVal.nameRubi = reader[4].ToString();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }

            return retVal;
        }

        public string export()
        {
            DateTime dt = DateTime.Now;
            string folderName = "backup_" + dt.ToString("yyyyMMdd_HHmmss");
            string fullPath = this.expPath + folderName;
            // 出力用フォルダのチェック
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            //BaseInfo
            string baseInfoCsv = exportBase();
            File.WriteAllText(fullPath + @"\baseInfo.csv", baseInfoCsv);

            return fullPath;
        }
        public string exportBase()
        {
            string mCsvDat = "";
            List<setaiInfoBeen> expBase = new List<setaiInfoBeen>();

            string sql = string.Format("select * from {0}.baseAddr order by setaiNo", this.database);
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mCsvDat += int.Parse(reader[0].ToString()) + ",";
                            mCsvDat += "'" + reader[1].ToString() + "',";
                            mCsvDat += "'" + reader[2].ToString() + "',";
                            mCsvDat += "'" + reader[3].ToString() + "',";
                            mCsvDat += "'" + reader[4].ToString() + "'\r\n";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }

            return mCsvDat;

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

        public void set(memberInfoDTO line)
        {
            this.member = line;
        }

        public void add(setaiInfoBeen line)
        {
            string sql = string.Format("update {0}.baseAddr set zipCode = '{1}' , address = '{2}' , name='{3}' , nameRubi='{4}' where setaiNo = {5}",
                this.database,
                line.zipCode,
                line.address,
                line.name,
                line.nameRubi,
                line.setaiNo
                );

            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }
        }

        public List<famiryEditBean> getEditList(string name,string nameRubi,string comName,int kind)
        {
            var flg = 0;
            List<famiryEditBean> retVal = new List<famiryEditBean>();

            string sql1 = string.Format("select a.setaiNo,b.famiNo,b.name,b.nameRubi,a.zipCode,a.address,b.tel,c.comName,c.comKata,d.kindName from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on a.setaiNo=c.setaiNo left join kind d on b.kind=d.kind group by a.setaiNo,b.famiNo,b.name,b.nameRubi,a.zipCode,a.address,b.tel,c.comName,c.comKata,d.kind,d.kindName", this.database);
            sql1 = string.Format("select a.setaiNo,b.famiNo,b.name,b.nameRubi,a.zipCode,a.address,b.tel from {0}.baseAddr a left join {0}.famiAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on b.setaiNo=c.setaiNo left join {0}.kind d on b.kind=d.kind group by a.setaiNo,b.famiNo,b.name,b.nameRubi,a.zipCode,a.address,b.tel ", this.database);
            sql1 = string.Format("select a.setaiNo,a.famiNo,a.name,a.nameRubi,b.zipCode,b.address,a.tel,c.comName,c.comKata,d.kindName from {0}.famiAddr a left join {0}.baseAddr b on a.setaiNo=b.setaiNo left join {0}.comTable c on (a.setaiNo=c.setaiNo AND a.famiNo=c.famiNo) left join {0}.kind d on a.kind=d.kind group by a.setaiNo,a.famiNo,a.name,a.nameRubi,b.zipCode,b.address,a.tel,c.comName,c.comKata,d.kind,d.kindName", this.database);
            string sql2 = "";
            string sql3 = "";
            string sql4 = "";
            string sql5 = "";
            string sql = "";
            string sqlTmp = "";

            // 名前漢字検索
            if (name.Length != 0)
            {
                sql2 = string.Format(" a.name like '%{0}%' ", name);
                flg = 1;
            }

            if (nameRubi.Length != 0)
            {
                sql3 = string.Format(" a.nameRubi like '%{0}%' ", nameRubi);
                flg = flg | 0x02;  
            }

            if (comName.Length != 0)
            {
                sql4 = string.Format(" c.comName like '%{0}%' ", comName);
                flg = flg | 0x04;
            }

            if (kind != -1)
            {
                sql5 = string.Format(" d.kind = {0}", kind);
                flg = flg | 0x08; 
            }

            if (flg == 0)
            {
                sql = sql1;
            }
            else
            {
                // 氏名が入力されている場合
                switch (flg)
                {
                    case 1:
                        sqlTmp = sql2;
                        break;
                    case 2:
                        sqlTmp = sql3;
                        break;
                    case 3:
                        sqlTmp = sql2 + " AND " + sql3;
                        break;
                    case 4:
                        sqlTmp = sql4;
                        break;
                    case 5:
                        sqlTmp = sql2 + " AND " + sql4;
                        break;
                    case 6:
                        sqlTmp = sql3 + " AND " + sql4;
                        break;
                    case 7:
                        sqlTmp = sql2 + " AND " + sql3 + " AND " + sql4;
                        break;
                    case 8:
                        sqlTmp = sql5;
                        break;
                    case 9:
                        sqlTmp = sql2 + " AND " + sql5;
                        break;
                    case 10:
                        sqlTmp = sql3 + " AND " + sql5;
                        break;
                    case 11:
                        sqlTmp = sql3 + " AND " + sql4 + " AND " + sql5;
                        break;
                    case 12:
                        sqlTmp = sql4 + " AND " + sql5;
                        break;
                    case 13:
                        sqlTmp = sql2 + " AND " + sql4 + " AND " + sql5;
                        break;
                    case 14:
                        sqlTmp = sql3 + " AND " + sql4 + " AND " + sql5;
                        break;
                    case 15:
                        sqlTmp = sql2 + " AND " + sql3 + " AND " + sql4 + " AND " + sql5;
                        break;
                }
                sql = sql1 + " having " + sqlTmp;
            }
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using(var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            famiryEditBean tmpDat = new famiryEditBean();

                            tmpDat.setaiNo = int.Parse(reader[0].ToString());
                            tmpDat.famiNo = int.Parse(reader[1].ToString());
                            tmpDat.name = reader[2].ToString();
                            tmpDat.nameRubi = reader[3].ToString();
                            tmpDat.zip = reader[4].ToString();
                            tmpDat.addr = reader[5].ToString();
                            tmpDat.tel = reader[6].ToString();
                            tmpDat.comName = reader[7].ToString();
                            tmpDat.comKata = reader[8].ToString();
                            tmpDat.kind = reader[9].ToString();
                            retVal.Add(tmpDat);
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }
            return retVal;
        }
        public int saveData()
        {
            // 世帯番号の取得
            this.member.setaiNo = getSetaiNo();

            // クエリの生成
            string sql = string.Format("insert into {0}.baseAddr values({1},'{2}','{3}','{4}','{5}')", 
                this.database,
                this.member.setaiNo,
                this.member.zip1 + "-" + this.member.zip2,
                this.member.address,
                this.member.name,
                this.member.nameRubi);

            // execsql main
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }

            return this.member.setaiNo;
        }
        public void saveData(int setaiNo)
        {
            // クエリの生成
            string sql = string.Format("insert into {0}.baseAddr values({1},'{2}','{3}','{4}','{5}')", 
                this.database,
                setaiNo,
                this.member.zip1 + "-" + this.member.zip2,
                this.member.address,
                this.member.name,
                this.member.nameRubi);

            // execsql main
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }
        }

        
        public int getKanaCnt(string line)
        {
            int retVal = 0;
            string sql = string.Format("select count(*) from {0}.baseAddr where nameRubi Like '%{1}%' order by setaiNo", this.database, line);

            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using(var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = reader.GetUInt16(0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }
            return retVal;
        }

        public  int getKanCnt(string line)
        {
            int retVal = 0;
            string sql = string.Format("select count(*) from {0}.baseAddr where name Like '%{1}%' order by setaiNo", this.database, line);

            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using(var reader = cmd.ExecuteReader())
                    {
                        retVal = reader.GetUInt16(0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }
            return retVal;
        }
        public int getSetaiNo()
        {
            int retVal = 0;
            string sql = string.Format("select max(setaiNo)+1 from {0}.baseAddr", this.database);

            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using(var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }
            return retVal;
        }
        public void Del(int setaiNo)
        {
            // クエリの生成
            string sql = string.Format("delete from {0}.baseAddr where setaiNo={1}", database, setaiNo);

            // execsql main
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }
        }
    }
}
