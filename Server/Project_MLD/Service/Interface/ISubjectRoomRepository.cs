using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface ISubjectRoomRepository
    {
        Task<IEnumerable<SubjectRoom>> GetAllSubjectRooms();
        Task<SubjectRoom> GetSubjectRoomById(int id);
        Task<SubjectRoom> AddSubjectRoom(SubjectRoom sr);
        Task<bool> UpdateSubjectRoom(SubjectRoom sr);
        Task<bool> DeleteSubjectRoom(int id);

    }
}
