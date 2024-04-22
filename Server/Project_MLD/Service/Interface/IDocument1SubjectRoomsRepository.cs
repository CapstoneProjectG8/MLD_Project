using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument1SubjectRoomsRepository
    {
        Task<IEnumerable<Document1SubjectRoom>> GetSubjectRoomsByDocument1Id(int id);
        Task UpdateDocument1SubjectRoom(List<Document1SubjectRoom> dc);
        Task DeleteDocument1SubjectRoom(List<Document1SubjectRoom> dc);
        Task DeleteDocument1SubjectRoomByDoc1Id(int id);
    }
}
