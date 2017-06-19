using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginDAL 
    {
       
        public static bool validateCredentials(string Name, string Password)
        {
            try
            {
                using (NewCommerceEntities obj = new NewCommerceEntities())
                {
                    var record = (from c in obj.Users
                                  where c.Name == Name && c.Password == Password
                                  select c).ToList<User>();

                    if (record.Count() == 0)
                        return false;
                    else
                        return true;
                }
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool AddUser(User obj)
        {
            try
            {
                using (NewCommerceEntities db = new NewCommerceEntities())
                {
                    var nameParam = new SqlParameter
                    {
                        ParameterName = "Name",
                        Value = obj.Name,
                    };
                    var addressParam = new SqlParameter
                    {
                        ParameterName = "Address",
                        Value = obj.Address,
                    };
                  
                    var emailParam = new SqlParameter
                    {
                        ParameterName = "email",
                        Value = obj.Email,
                    };
                    var passwordParam = new SqlParameter
                    {
                        ParameterName = "Password",
                        Value = obj.Password,
                    };
                    var query = db.Users.SqlQuery("EXEC AddToUsers  @Name,@Address,@Email,@Password", nameParam, addressParam, emailParam, passwordParam).ToList<User>();
                    if (query.Count > 0)
                        return true;
                    else
                        return false;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
