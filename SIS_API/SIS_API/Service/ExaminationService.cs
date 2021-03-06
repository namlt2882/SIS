﻿using SIS_API.Repository;
using SIS_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_API.Service
{
    public class ExaminationService
    {
        ExaminationRepository repository = new ExaminationRepository();
        TranscriptRepository transcriptRepository = new TranscriptRepository();
        public Examination Add(Examination exam)
        {
            exam.Id = 0;
            exam.Status = (int)ExaminationEnums.STATUS_ACTIVE;
            var rs = repository.Insert(exam);
            // add transcript
            TranscriptService transcriptService = new TranscriptService();
            transcriptService.AddExamToTranscript(rs);
            return rs;
        }

        public IEnumerable<Examination> GetAll()
        {
            return repository.GetAll();
        }

        public Examination Get(int id)
        {
            var rs = repository.Get(id);
            if (rs != null && rs.Status == (int)ExaminationEnums.STATUS_DISABLE)
            {
                rs = null;
            }
            return rs;
        }

        public void Update(Examination exam)
        {
            var origin = repository.Get(exam.Id);
            origin.Name = exam.Name;
            origin.PercentRate = exam.PercentRate;
            repository.Update(origin);
            // update active transcripts
            var trans = transcriptRepository.GetAllActiveTranscriptOfExam(exam.Id);
            trans.ForEach(t =>
            {
                t.ExamName = exam.Name;
                t.PercentRate = exam.PercentRate;
            });
            transcriptRepository.UpdateTranscripts(trans);
        }

        public void Delete(int id)
        {
            var origin = repository.Get(id);
            origin.Status = (int)ExaminationEnums.STATUS_DISABLE;
            repository.Update(origin);
        }
    }
}