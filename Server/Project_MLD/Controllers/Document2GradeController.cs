﻿using Amazon.S3.Model;
using Amazon.S3.Model.Internal.MarshallTransformations;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;
using System.ComponentModel;
using System.Reflection.Metadata;
using static Project_MLD.Controllers.Document2Controller;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Document2GradeController : ControllerBase
    {
        private readonly IDocument2GradeRepository _repository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IDocument2Repository _doc2Repository;
        private readonly IUserRepository _userRepository;
        private readonly ISpecializedDepartmentRepository _specialDepartmentRepository;
        private readonly IMapper _mapper;

        public Document2GradeController(IDocument2GradeRepository document2GradeRepository,
            IGradeRepository gradeRepository, IDocument2Repository document2Repository,
            IUserRepository userRepository, ISpecializedDepartmentRepository specializedDepartmentRepository, IMapper mapper)
        {
            _repository = document2GradeRepository;
            _gradeRepository = gradeRepository;
            _userRepository = userRepository;
            _specialDepartmentRepository = specializedDepartmentRepository;
            _mapper = mapper;
            _doc2Repository = document2Repository;
        }
        public class GroupedDocument2GradeDTO
        {
            public int? Document2Id { get; set; }
            public int? GradeId { get; set; }
            public string? TitleName { get; set; }
            public string? Description { get; set; }
            public int? Slot { get; set; }
            public DateOnly? Time { get; set; }
            public string? Place { get; set; }
            public string? CollaborateWith { get; set; }
            public string? Condition { get; set; }
            public List<int> HostBy { get; set; } = new List<int>();
        }

        [HttpGet("GetAllDoc2sGrade")]
        public async Task<ActionResult<IEnumerable<Document2Grade>>> GetAllDocument2sGrade()
        {
            var pl2 = await _repository.GetAllDocuemnt2Grades();
            if (pl2 == null)
            {
                return NotFound("No Document 2 Grade Found");
            }
            var mapDocumemt = _mapper.Map<List<Document2GradeDTO>>(pl2);

            // Group tất cả trùng nhau trừ HostBy
            var groupedData = mapDocumemt
                .GroupBy(d => new
                {
                    d.Document2Id,
                    d.GradeId,
                    d.TitleName,
                    d.Description,
                    d.Slot,
                    d.Time,
                    d.Place,
                    d.CollaborateWith,
                    d.Condition
                })
                .Select(g => new GroupedDocument2GradeDTO
                {
                    Document2Id = g.Key.Document2Id,
                    GradeId = g.Key.GradeId,
                    TitleName = g.Key.TitleName,
                    Description = g.Key.Description,
                    Slot = g.Key.Slot,
                    Time = g.Key.Time,
                    Place = g.Key.Place,
                    CollaborateWith = g.Key.CollaborateWith,
                    Condition = g.Key.Condition,
                    HostBy = g.Select(d => d.HostBy ?? 0).Where(h => h != 0).Distinct().ToList()
                })
                .ToList();
            return Ok(groupedData);
        }
        private List<int> GetHostBy(List<int> a, Task<List<int>> b)
        {

            if (a.Count == b.Result.Count)
            {
                return new List<int> { 0 };
            }
            else
            {
                return a;
            }
        }

        [HttpGet("GetDoc2GradeById/{id}")]
        public async Task<ActionResult<IEnumerable<GroupedDocument2GradeDTO>>> GetDocument2GradeById(int id)
        {
            var existDocument2 = await _repository.GetDocument2GradeByDocument2Id(id);

            if (existDocument2 == null)
            {
                return NotFound("No Document 2 Grade Found");
            }

            var mapDocument = _mapper.Map<List<Document2Grade>>(existDocument2);


            // Group tất cả trùng nhau trừ HostBy
            var groupedData = mapDocument
                .GroupBy(d => new
                {
                    d.Document2Id,
                    d.GradeId,
                    d.TitleName,
                    d.Description,
                    d.Slot,
                    d.Time,
                    d.Place,
                    d.CollaborateWith,
                    d.Condition
                })
                .Select(async g => new GroupedDocument2GradeDTO
                {
                    Document2Id = g.Key.Document2Id,
                    GradeId = g.Key.GradeId,
                    TitleName = g.Key.TitleName,
                    Description = g.Key.Description,
                    Slot = g.Key.Slot,
                    Time = g.Key.Time,
                    Place = g.Key.Place,
                    CollaborateWith = g.Key.CollaborateWith,
                    Condition = g.Key.Condition,
                    HostBy = GetHostBy(
                        g.Select(d => d.HostBy ?? 0).Where(h => h != 0).Distinct().ToList(),
                        (GetUserIDByDocId(id)))
                })
                .ToList();


            var result = await Task.WhenAll(groupedData);

            return Ok(result);
        }

        public class Doc2GradeRequestBody
        {
            public int Document2Id { get; set; }
            public int? GradeId { get; set; }
            public string? TitleName { get; set; }
            public string? Description { get; set; }
            public int? Slot { get; set; }
            public DateOnly? Time { get; set; }
            public string? Place { get; set; }
            public List<int>? HostBy { get; set; }
            public string? CollaborateWith { get; set; }
            public string? Condition { get; set; }
        }

        [HttpPost("AddDoc2Grade")]
        public async Task<IActionResult> AddDocument2Grade(List<Doc2GradeRequestBody> listRequest)
        {
            try
            {


                foreach (var itemRequest in listRequest)
                {
                    if (itemRequest.HostBy != null)
                    {
                        for (int i = 0; i < itemRequest.HostBy.Count; i++)
                        {
                            var item = itemRequest.HostBy[i];
                            if (item == 0)
                            {
                                var listId = GetUserIDByDocId(itemRequest.Document2Id);
                                itemRequest.HostBy.RemoveAt(i);
                                i--;

                                foreach (var item2 in listId.Result)
                                {
                                    itemRequest.HostBy.Add(item2);
                                }
                            }
                        }

                        foreach (var hostby in itemRequest.HostBy)
                        {
                            var document2 = new Document2GradeDTO
                            {
                                Document2Id = itemRequest.Document2Id,
                                GradeId = itemRequest.GradeId,
                                TitleName = itemRequest.TitleName,
                                Description = itemRequest.Description,
                                Slot = itemRequest.Slot,
                                Time = itemRequest.Time,
                                Place = itemRequest.Place,
                                HostBy = hostby,
                                CollaborateWith = itemRequest.CollaborateWith,
                                Condition = itemRequest.Condition
                            };

                            var mapper = _mapper.Map<Document2Grade>(document2);

                            var doc = await _repository.AddDocument2Grade(mapper);
                        }
                    }
                    else
                    {
                        var document2 = new Document2GradeDTO
                        {
                            Document2Id = itemRequest.Document2Id,
                            GradeId = itemRequest.GradeId,
                            TitleName = itemRequest.TitleName,
                            Description = itemRequest.Description,
                            Slot = itemRequest.Slot,
                            Time = itemRequest.Time,
                            Place = itemRequest.Place,
                            HostBy = null,
                            CollaborateWith = itemRequest.CollaborateWith,
                            Condition = itemRequest.Condition
                        };

                        var mapper = _mapper.Map<Document2Grade>(document2);

                        var doc = await _repository.AddDocument2Grade(mapper);
                    }
                }
                return Ok("ADD");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while adding Document2 Grade: {ex.Message}");
            }
        }

        [HttpDelete("DeleteDoc2Grade")]
        public async Task<IActionResult> DeleteDocument2Grade(List<Document2GradeDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document2Grade>>(requests);
                await _repository.DeleteDocument2Grade(mapRequests);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while delete Document1 CurriculumDistribution: {ex.Message}");
            }
        }

        [HttpGet("GetTotalStudentByGradeId/{gradeId}")]
        public async Task<IActionResult> GetTotalStudentByGradeId(int gradeId)
        {
            if (gradeId == 0)
            {
                return BadRequest("Grade Id is null");
            }
            var totalStudent = await _gradeRepository.GetTotalStudentByGradeId(gradeId);

            return Ok(new
            {
                totalStudent = totalStudent
            });
        }

        [HttpDelete("DeleteDoc2GradeByDoc2Id")]
        public async Task<IActionResult> DeleteDocument2GradeByDocument2Id(int id)
        {
            try
            {
                await _repository.DeleteDocument2GradeByDoc2Id(id);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while delete Document2 Grade: {ex.Message}");
            }
        }

        private async Task<List<int>> GetUserIDByDocId(int doc2Id)
        {
            var doc2 = await _doc2Repository.GetDocument2ById(doc2Id);

            var user = await _userRepository.GetUserById(doc2.UserId);
            var department = new SpecializedDepartment();
            if (user.DepartmentId != null)
            {
                department = await _specialDepartmentRepository.GetSpecializedDepartmentById((int)user.DepartmentId);

            }

            var users = await _userRepository.GetAllUsersByDepartmentId(department.Id);

            var listId = new List<int>();
            foreach (var u in users)
            {
                listId.Add(u.Id);
            }

            return listId;
        }
    }
}
