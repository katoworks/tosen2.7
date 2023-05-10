using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tosen2
{
    public class cominfo
    {
        public int setaiNo { set; get; }
        public int famiNo { set; get; }
        public string comName { set; get; }
        public string comTel { set; get; }
        public string comSimei { set; get; }
        public string comSimeiRubi { set; get; }
        public string comKata { set; get; }
        public string comZip { set; get; }
        public string comAddr { set; get; }
        private dbClass db { set; get; }

        public cominfo()
        {
            this.db = new dbClass();
        }
        public List<string> getName(string srchName)
        {
            List<string> retVal = new List<string>();
            string mSql = "";

            this.db.cn = new MySql.Data.MySqlClient.MySqlConnection(this.db.cnnStr);
            mSql = string.Format("select distinct comName from {0}.comTable where comName Like '%{1}%' ", this.db.database, srchName);

            using(var cmd = this.db.cn.CreateCommand())
            {
                try
                {
                    this.db.cn.Open();
                    cmd.CommandText = mSql;
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(reader[0].ToString());
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

    
            return retVal;
        }
        public cominfo getInfo(string srchName)
        {
            cominfo retVal = new cominfo();
            cominfo mDat = new cominfo();
            string mSql = "";

            this.db.cn = new MySql.Data.MySqlClient.MySqlConnection(this.db.cnnStr);
            mSql = string.Format("select setaiNo, famiNo, comName, comTel, comSimei, comSimeiRubi, comKata, comZip, comAddr from {0}.comTable where comName = '{1}' AND famiNo=0 ", this.db.database, srchName);

            using(var cmd = this.db.cn.CreateCommand())
            {
                try
                {
                    this.db.cn.Open();
                    cmd.CommandText = mSql;
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();

                        mDat.setaiNo = int.Parse(reader[0].ToString());
                        mDat.famiNo = int.Parse(reader[1].ToString());
                        mDat.comName = reader[2].ToString();
                        mDat.comTel = reader[3].ToString();
                        mDat.comSimei = reader[4].ToString();
                        mDat.comSimeiRubi = reader[5].ToString();
                        mDat.comKata = reader[6].ToString();
                        mDat.comZip = reader[7].ToString();
                        mDat.comAddr = reader[8].ToString();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }

            }
            return mDat;
        }
    }
}
