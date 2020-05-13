using System;
using System.Collections.Generic;
using System.Text;
using VideoLeasingSystem.Core;
using System.Linq;

namespace VideoLeasingSystem.Data
{
    public interface IVideoData
    {
        Video GetVideoById(int id);

        IEnumerable<Video> GetVideoByName(string videoName);
        Video Delete(int VideoId);
        IEnumerable<Video> GetAll();
    }

}
