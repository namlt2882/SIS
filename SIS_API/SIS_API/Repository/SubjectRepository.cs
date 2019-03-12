﻿using SIS_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_API.Repository
{
    public class SubjectRepository : BaseRepository<Subject>
    {
        public IEnumerable<Subject> GetAll()
        {
            var subjects = DbContext.Subjects
                .Where(x => x.Status == (int)SubjectEnums.STATUS_ACTIVE);
            return subjects;
        }

        public Subject Get(int id)
        {
            var subject = DbContext.Subjects
                .Where(x => x.Id == id && x.Status == (int)SubjectEnums.STATUS_ACTIVE).FirstOrDefault();
            return subject;
        }
    }
}