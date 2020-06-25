using BigSchool.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<Following> Followings { get; set; }
        public bool ShowAction { get; set; }
    }
}