using System;
using System.Collections.Generic;
using System.Text;
using VideoLeasingSystem.Core;
using System.Linq;
using VideoLeasingSystem.Data.Model;

namespace VideoLeasingSystem.Data
{
    public interface IUserData
    {
        IEnumerable<User> GetAllUsers();

        User GetByUserName(string username);

        string Add(User newUser);

        string CheckUser(Login Logindata);

        IEnumerable<UserMovieRecord> GetRecordsByName(string Username);
        bool AddRecord(UserMovieRecord newRecord);
        UserMovieRecord GetRecordsById(int rId);
        bool DeleteRecord(int rId);

        int commit();
    }   
}
