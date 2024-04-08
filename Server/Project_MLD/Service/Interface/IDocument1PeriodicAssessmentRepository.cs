﻿using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument1PeriodicAssessmentRepository
    {
        Task<IEnumerable<PeriodicAssessment>> GetAllPeriodicAssessment();
        Task<IEnumerable<PeriodicAssessment>> GetPeriodicAssessmentByDocument1Id(int id);
        Task UpdateDocument1PeriodicAssessment(List<PeriodicAssessment> dc);
        Task DeleteDocument1PeriodicAssessment(List<PeriodicAssessment> dc);
    }
}
