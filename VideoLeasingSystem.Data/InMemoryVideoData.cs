using System;
using System.Collections.Generic;
using System.Text;
using VideoLeasingSystem.Core;
using System.Linq;

namespace VideoLeasingSystem.Data
{
    public class InMemoryVideoData : IVideoData
    {
        private readonly VideoSystemDbContext db;

        public InMemoryVideoData(VideoSystemDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Video> GetAll()
        {
            return from vid in db.Videos
                   orderby vid.VideoId
                   select vid;
        }

        public IEnumerable<Video> GetVideoByName(string videoName)
        {
            var vname = from v in db.Videos
                        where v.VideoName.StartsWith(videoName) || string.IsNullOrEmpty(videoName)
                        orderby v.VideoName
                        select v;
            return vname;
        }

        public Video GetVideoById(int VideoId)
        {
            return db.Videos.Find(VideoId);
        }

        public Video Delete(int VideoId)
        {
            db.Videos.Remove(GetVideoById(VideoId));
            return GetVideoById(VideoId);
        }
    }
}
