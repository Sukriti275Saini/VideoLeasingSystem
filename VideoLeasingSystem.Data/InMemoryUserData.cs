using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoLeasingSystem.Core;
using VideoLeasingSystem.Data.Model;

namespace VideoLeasingSystem.Data
{
    public class InMemoryUserData : IUserData
    {
        private readonly VideoSystemDbContext db;
        public InMemoryUserData(VideoSystemDbContext db) {
            this.db = db;
        }

        //Users
        public string Add(User newUser)
        {
            var checkusername = from usr in db.Users
                                where usr.UserName.Equals(newUser.UserName)
                                select usr;
            if (checkusername.Count()>0)
            {
                return "User Name Already Exists";
            }
            db.Add(newUser);
            return "Added";
        }

        public IEnumerable<User> GetAllUsers()
            {
                return from usr in db.Users
                       orderby usr.UserName
                       select usr;
            }

        public string CheckUser(Login Logindata)
        {
            var ulogincheck = from u in db.Users
                        where u.UserName.Equals(Logindata.UserName)
                        select u;
            if (ulogincheck.Count() > 0)
            {
                var checkpass = ulogincheck.Where(u => u.Password.Equals(Logindata.Password)).Select(u => u);
                if (checkpass.Count() < 0)
                {
                    return "incorrect Password";
                }
            }
            return "found";
        }
        
        public User GetByUserName(string username)
        {
            var usernamecheck = from usr in db.Users
                                where usr.UserName.Equals(username)
                                orderby usr.FullName
                                select usr;
            return usernamecheck.SingleOrDefault();
        }


        //Records
        public IEnumerable<UserMovieRecord> GetRecordsByName(string Username)
        {
            return from rec in db.Records.Include("Video").Include("User")
                   where rec.User.UserName.Equals(Username)
                   select rec;
        }
        public bool AddRecord(UserMovieRecord newRecord)
        {
            db.Records.Add(newRecord);
            return true;
        }

        public UserMovieRecord GetRecordsById(int rId)
        {
            var query = from r in db.Records.Include("Video").Include("User") where r.RecordId.Equals(rId) select r;
            return query.FirstOrDefault();
        }

        public int commit()
        {
            return db.SaveChanges();
        }

        public bool DeleteRecord(int rId)
        {
            db.Records.Remove(GetRecordsById(rId));
            return true;
        }
    }
}
