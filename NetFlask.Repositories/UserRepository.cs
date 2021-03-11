using NetFlask.DAL.Repositories;
using NetFlask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace NetFlask.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IConcreteRepository<UserEntity>
    {

        public UserRepository(string ConnectionString):base(ConnectionString)
        {

        }

       

        public List<UserEntity> Get()
        {
            return base.Get("Select * from User");
        }

        public UserEntity GetOne(int PK)
        {
            return base.GetOne(PK,"Select * from User where IdUser=@id");
        }

        public bool Insert(UserEntity toInsert)
        {
            SecurityHelper securityHelper = new SecurityHelper();
            byte[] salt = securityHelper.GenerateLongRandomSalt();
            toInsert.Salt = Convert.ToBase64String(salt);
            toInsert.Password = securityHelper.createHash(toInsert.Password, salt);
            string requete = @"INSERT INTO [dbo].[User]
           ([FirstName]
           ,[LastName]
           ,[Login]
           ,[Password]
           ,[Salt])
            VALUES
           (@FirstName
           ,@LastName 
           ,@Login 
           ,@Password 
           ,@Salt)";

           return base.Insert(toInsert, requete);
        }

        public bool Update(UserEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetFromLogin(string login )
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("login", login); 
            return base.Get( "Select * from [User] where Login=@login",p).FirstOrDefault();
        }
    }
}
