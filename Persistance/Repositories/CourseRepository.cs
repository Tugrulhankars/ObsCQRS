using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Repositories.EfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories;

public class CourseRepository : EfRepositoryBase<Course, int, BaseDbContext>, ICourseRepository
{
    private readonly BaseDbContext _context;
    public CourseRepository(BaseDbContext context) : base(context)
    {
        _context = context; 
    }

    public async Task<Course> AssignInstructorToCourse(int courseCode, int instructorId)
    {
        // Course'u bul
        var course = await _context.Courses
            .Include(c => c.Instructors) // Instructors ilişkisini dahil et
            .FirstOrDefaultAsync(c => c.CourseCode == courseCode);

       

        // Instructor'ı bul
        var instructor = await _context.Instructors
            .FirstOrDefaultAsync(i => i.Id == instructorId);

       

        // Instructor'ı Course'a ekle
        if (!course.Instructors.Contains(instructor))
        {
            course.Instructors.Add(instructor);
        }

        // Değişiklikleri kaydet
        await _context.SaveChangesAsync();

        return course;
    }

    public async Task<Course> GetById(int id)
    {
        var course =await _context.Courses.FirstOrDefaultAsync(x=>x.Id==id);
        return course;
    }

    //public async Task<Course> GetByCourseCode(int courseCode)
    //{
    //    Course result = (Course)_context.Courses.Where(x=>x.CourseCode==courseCode);

    //    return result;
    //}
}
