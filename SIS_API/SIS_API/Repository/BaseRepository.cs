﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SIS_API.Repository
{
    public class BaseRepository<T>
    {
        public static SchoolInformationSystemEntities DbContext = new SchoolInformationSystemEntities();
        DbSet entities;

        public BaseRepository()
        {
            Type generic = typeof(T);
            if (generic == typeof(User))
            {
                entities = DbContext.Users;
            }
            else if (generic == typeof(Student))
            {
                entities = DbContext.Students;
            }
            else if (generic == typeof(Subject))
            {
                entities = DbContext.Subjects;
            }
            else if (generic == typeof(Class))
            {
                entities = DbContext.Classes;
            }
            else if (generic == typeof(ClassSubject))
            {
                entities = DbContext.ClassSubjects;
            }
            else if (generic == typeof(AcademicTranscript))
            {
                entities = DbContext.AcademicTranscripts;
            }
            else if (generic == typeof(ClassMember))
            {
                entities = DbContext.ClassMembers;
            }
        }

        public T Insert(T t)
        {
            object result = entities.Add(t);
            DbContext.SaveChanges();
            return (T)result;
        }

        public void Update(object t)
        {
            DbContext.Entry(t).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public T Get(object id)
        {
            return (T)entities.Find(id);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            Type type = typeof(T);
            return (from r in entities.Cast<T>() select r);
        }

    }
}