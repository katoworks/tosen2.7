using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tosen2
{
    public class setaiInfoBeen
    {
        public int setaiNo { set; get; }
        public string zipCode { set; get; }
        public string address { set; get; }
        public string name { set; get; }
        public string nameRubi { set; get; }

    }
    public class famiInfoBeen
    {
        public int setaiNo { set; get; }
        public int famiNo { set; get; }
        public string name { set; get; }
        public string nameRubi { set; get; }
        public string tel { set; get; }
        public string company { set; get; }
        public int kind { set; get; }
    }

    public class companyInfoBeen
    {
        public int setaiNo { set; get; }
        public int famiNo { set; get; }
        public string comanyName { set; get; }
        public string comTel { set; get; }
        public string comSimei { set; get; }
        public string comSimeiRubi { set; get; }
        public string comKata { set; get; }
        public string comZip { set; get; }
        public string comAddr { set; get; }
    } 

    public class famiryEditBean
    {
        public int setaiNo { set; get; }
        public int famiNo { set; get; }
        public string name { set; get; }
        public string nameRubi { set; get; }
        public string zip { set; get; }
        public string addr { set; get; }
        public string tel { set; get; }
        public string comName { set; get; }
        public string comKata { set; get; }
        public string kind { set; get; }
    }

    public class setMember
    {
        private setaiInfoBeen mSetai;
        private List<famiInfoBeen> mFami=new List<famiInfoBeen>();
        private companyInfoBeen mCom;
        private int setaiNo;
        private int famiNo;

        public setMember()
        {
            dbClass db = new dbClass();
            this.setaiNo = db.getSetaiNo();
            this.famiNo = 0;
        }

        public void setMain(setaiInfoBeen dat)
        {
            this.mSetai = dat;
        }
        public void setFami(List<famiInfoBeen> dat)
        {
            this.mFami = dat;
        }

        public void setCom(companyInfoBeen dat)
        {
            this.mCom = dat;
        }
        public setaiInfoBeen getMain()
        {
            this.mSetai.setaiNo = this.setaiNo;
            return this.mSetai;
        }
        public List<famiInfoBeen> getFami()
        {
            for (int i = 0; i <= this.famiNo; i++)
            {
                this.mFami[i].setaiNo = this.setaiNo;
            }  
            return this.mFami;
        }
        public companyInfoBeen getCom()
        {
            this.mCom.setaiNo = this.setaiNo;
            return this.mCom;
        }
    }
}
