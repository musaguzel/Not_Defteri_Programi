using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Not_Defteri
{
    class Sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-I0KDOLK\SQLEXPRESS;Initial Catalog=DbNotDefteri;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
        
    }
}
