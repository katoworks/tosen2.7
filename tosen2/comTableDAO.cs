using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace tosen2
{
    class comTableDAO
    {
        public string ipaddr { set; get; }
        public string userid { set; get; }
        public string pasword { set; get; }
        public string database { set; get; }
        public string cnnStr;
        public MySqlConnection cn;
        private List<comInfoDTO> mCom;
        private string listFileName = @".\conf\tosen.txt";

        public comTableDAO()
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
        }
        public void export(string fullPath)
        {
            //FamiInfo
            string famiInfoCsv = exportCom();
            File.WriteAllText(fullPath + @"\comInfo.csv", famiInfoCsv);
        }
        public string exportCom()
        {
            string mCsvDat = "";

            string sql = string.Format("select * from {0}.comTable order by setaiNo,famiNo", this.database);
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
                            mCsvDat += "'" + reader[5].ToString() + "',";
                            mCsvDat += "'" + reader[6].ToString() + "',";
                            mCsvDat += "'" + reader[7].ToString() + "',";
                            mCsvDat += "'" + reader[8].ToString() + "'\r\n";
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


        public void set(List<comInfoDTO> com)
        {
            this.mCom = com;
        }

        public void save(int setaiNo)
        {
            int cnt = 0;
            try
            {
                for (cnt = 0; cnt < this.mCom.Count; cnt++)
                {
                    saveData(setaiNo, this.mCom[cnt]);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void del(int setai,int fami)
        {
            string sql = string.Format("delete from {0}.comTable where setaiNo={1} AND famiNo={2}",this.database, setai, fami);
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

        public Boolean chkData(int setaiNo,int famiNo)
        {
            Boolean retVal = false;
            string sql = string.Format("select count(*) from {0}.comTable where setaiNo={1} AND famiNo={2}", this.database, setaiNo, famiNo);
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
        public Boolean chkData(int setaiNo)
        {
            Boolean retVal = false;
            string sql = string.Format("select count(*) from {0}.comTable where setaiNo={1}", this.database, setaiNo);
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

        public void add(companyInfoBeen line)
        {
            string sql = string.Format("update {0}.comTable set comName = '{1}' , comTel = '{2}' , comSimei = '{3}' , comSimeiRubi = '{4}' , comKata = '{5}' , comZip = '{6}' , comAddr = '{7}' where setaiNo = {8} AND famiNo = {9}",
                this.database,
                line.comanyName,
                line.comTel,
                line.comSimei,
                line.comSimeiRubi,
                line.comKata,
                line.comZip,
                line.comAddr,
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }
        } 

        public companyInfoBeen getInfo(int setaiNo,int famiNo)
        {
            companyInfoBeen retVal = new companyInfoBeen();
            string sql = string.Format("select * from {0}.comTable where setaiNo = {1} AND famiNo = {2}", this.database, setaiNo, famiNo);
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
                            retVal.famiNo = famiNo;
                            retVal.comanyName = reader[2].ToString();
                            retVal.comTel = reader[3].ToString();
                            retVal.comSimei = reader[4].ToString();
                            retVal.comSimeiRubi = reader[5].ToString();
                            retVal.comKata = reader[6].ToString();
                            retVal.comZip = reader[7].ToString();
                            retVal.comAddr = reader[8].ToString();

                        }
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
        public void Add(List<comInfoDTO> line)
        {
            foreach(comInfoDTO mVar in line)
            {
                string sql = string.Format("insert into {0}.comTable (setaiNo, famiNo, comName, comZip, comAddr, comKata, comSimei, comSimeiRubi, comTel) values({1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                    this.database,
                    mVar.setaiNo,
                    mVar.famiNo,
                    mVar.comName,
                    mVar.comZip1 + "-" + mVar.comZip2,
                    mVar.comAddress,
                    mVar.comKata,
                    mVar.comShimei,
                    mVar.comShimeiRubi,
                    mVar.tel
                    );

                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using(var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Del(int setaiNo)
        {
            if (chkData(setaiNo))
            {
                // クエリの生成
                string sql = string.Format("delete from {0}.comTable where setaiNo={1}", database, setaiNo);

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

        private void saveData(int setaiNo, comInfoDTO tmpCom) {
            string sql = string.Format("insert into {0}.comTable (setaiNo, famiNo, comName, comZip, comAddr, comKata, comSimei, comSimeiRubi) values({1},{2},'{3}','{4}','{5}','{6}','{7}','{8}')",
                                this.database,
                                setaiNo,
                                tmpCom.famiNo,
                                tmpCom.comName,
                                tmpCom.comZip1 + "-" + tmpCom.comZip2,
                                tmpCom.comAddress,
                                tmpCom.comKata,
                                tmpCom.comShimei,
                                tmpCom.comShimeiRubi);
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
