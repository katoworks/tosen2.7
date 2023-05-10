using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace tosen2
{
    
    class famiAddrDAO
    {
        public List<famiInfoBeen> fm { set; get; }
        public string ipaddr { set; get; }
        public string userid { set; get; }
        public string pasword { set; get; }
        public string database { set; get; }
        public string cnnStr;
        public MySqlConnection cn;
        public int famiNo { set; get; }
        private string listFileName = @".\conf\tosen.txt";

        public famiAddrDAO()
        {
            //this.ipaddr = "153.127.10.253";
            this.ipaddr = "localhost";
            this.database = "tosen";
            this.userid = "db_user";
            this.pasword = "jiji1215";
            this.famiNo = 0;

            // 設定ファイル読み込み
            confInit();

            cnnStr = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Charset=utf8;",
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

        public int setaiNo { set; get; }
        public int famiryNo { set; get; }

        public void export(string fullPath)
        {
            //FamiInfo
            string famiInfoCsv = exportFami();
            File.WriteAllText(fullPath + @"\famiInfo.csv", famiInfoCsv);
        }
        public string exportFami()
        {
            string mCsvDat = "";

            string sql = string.Format("select * from {0}.famiAddr order by setaiNo,famiNo", this.database);
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
                            mCsvDat += int.Parse(reader[1].ToString()) + ",";
                            mCsvDat += "'" + reader[2].ToString() + "',";
                            mCsvDat += "'" + reader[3].ToString() + "',";
                            mCsvDat += "'" + reader[4].ToString() + "',";
                            mCsvDat += int.Parse(reader[5].ToString()) + "\r\n";
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
        public void Add(List<famiInfoBeen> line)
        {
            if (line is null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            int mCnt = 0;
            int mMax = line.Count();

            for (mCnt = 0; mCnt < mMax; mCnt++)
            {
                string sql = string.Format("insert into {0}.famiAddr (setaiNo,famiNo,name,nameRubi,tel,kind) values({1},{2},'{3}','{4}','{5}',{6})",
                    this.database,
                    line[mCnt].setaiNo,
                    line[mCnt].famiNo,
                    line[mCnt].name,
                    line[mCnt].nameRubi,
                    line[mCnt].tel,
                    line[mCnt].kind);
                try
                {
                    this.cn = new MySqlConnection(this.cnnStr);
                    this.cn.Open();
                    using(var cmd = this.cn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

        }
        public void Del(int setaiNo)
        {
            if (Chk(setaiNo))
            {
                // クエリの生成
                string sql = string.Format("delete from {0}.famiAddr where setaiNo={1}", database, setaiNo);

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
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    this.cn.Close();
                }
            }
        }
        public Boolean Chk(int setaiNo)
        {
            Boolean retVal = false;
            string sql = string.Format("select count(*) from {0}.famiAddr where setaiNo={1}", this.database, setaiNo);
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                using(var cmd = this.cn.CreateCommand()){
                    this.cn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        if(int.Parse(reader[0].ToString()) > 0)
                        {
                            retVal = true;
                        }
                        else
                        {
                            retVal = false;
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

        public void update(famiInfoBeen line)
        {
            string sql = string.Format("insert into {0}.famiAddr (setaiNo,famiNo,name,nameRubi,tel,kind) values({1},{2},'{3}','{4}','{5}',{6})",
                this.database,
                this.setaiNo,
                this.famiryNo,
                line.name,
                line.nameRubi,
                line.tel,
                line.kind);

            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using(var cmd = this.cn.CreateCommand())
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

        public void update(List<famiInfoBeen> line)
        {

            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    for (int mCnt = 0; mCnt < line.Count(); mCnt++)
                    {
                        string sql = string.Format("insert into {0}.famiAddr (setaiNo,famiNo,name,nameRubi,tel,kind) values({1},{2},'{3}','{4}','{5}',{6})",
                            this.database,
                            line[mCnt].setaiNo,
                            line[mCnt].famiNo,
                            line[mCnt].name,
                            line[mCnt].nameRubi,
                            line[mCnt].tel,
                            line[mCnt].kind);

                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
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
        }

        public int getFamiNo(int setaiNo)
        {
            int retVal = 0;

            string sql = string.Format("select max(famiNo)+1 from {0}.famiAddr where setaiNo={1}", this.database, setaiNo);
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using(var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using(var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
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
        public void set(List<famiInfoDTO> mInfo)
        {
            int maxFamiry = mInfo.Count();
            int cnt = 0;
            famiInfoDTO mTmpFami = new famiInfoDTO();

            try
            {
                for (cnt = 0; cnt < maxFamiry; cnt++)
                {
                    mTmpFami.setaiNo = this.setaiNo;
                    mTmpFami.famiNo = cnt;
                    mTmpFami.name = mInfo[cnt].name;
                    mTmpFami.nameRubi = mInfo[cnt].nameRubi;
                    mTmpFami.tel = mInfo[cnt].tel;
                    mTmpFami.syozoku = mInfo[cnt].syozoku;
                    addFamiryInfo(mTmpFami);

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public void del(int setai,int fami)
        {
            string sql = string.Format("delete from {0}.famiAddr where setaiNo={1} AND famiNo={2}",this.database, setai, fami);
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();

                using(var cmd = this.cn.CreateCommand())
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
        public void add(famiInfoBeen line)
        {
            string sql = string.Format("update {0}.famiAddr set name = '{1}' , nameRubi = '{2}' , tel = '{3}' AND kind = {4} where setaiNo = {5} AND famiNo = {6}",
                this.database,
                line.name,
                line.nameRubi,
                line.tel,
                line.kind,
                line.setaiNo,
                line.famiNo
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

        public famiInfoBeen getInfo(int mSetaiNo, int mFamiNo)
        {
            famiInfoBeen retVal=new famiInfoBeen();
            string sql = string.Format("select * from {0}.famiAddr where setaiNo = {1} AND famiNo = {2}",this.database, mSetaiNo,mFamiNo);

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
                            retVal.famiNo = int.Parse(reader[1].ToString());
                            retVal.name = reader[2].ToString();
                            retVal.nameRubi = reader[3].ToString();
                            retVal.tel = reader[4].ToString();
                 //           retVal.company = reader[5].ToString();
                            retVal.kind = int.Parse(reader[5].ToString());

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

        private void addFamiryInfo(famiInfoDTO line)
        {
            string sql = string.Format("insert into {0}.famiAddr (setaiNo, famiNo, name, nameRubi, tel, kind) values({1}, {2}, '{3}', '{4}', '{5}', {6})",
                                this.database,
                                line.setaiNo,
                                line.famiNo,
                                line.name,
                                line.nameRubi,
                                line.tel,
                                line.syozoku);

            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using(var cmd = this.cn.CreateCommand())
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
