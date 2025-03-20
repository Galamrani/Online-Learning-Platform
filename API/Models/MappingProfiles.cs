using AutoMapper;

namespace OnlineLearning.API;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // If object is null it will be mapped to null
        AllowNullDestinationValues = true;

        // If a collection in null it will be mapped to []
        AllowNullCollections = false;

        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();

        CreateMap<Enrollment, EnrollmentDto>();

        CreateMap<CourseDto, Course>();
        // Course -> CourseDto (Includes Lesson -> LessonDto)
        CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons)); // Maps lessons inside course

        // Lesson -> LessonDto (Includes Progress -> ProgressesDto)
        CreateMap<Lesson, LessonDto>()
            .ForMember(dest => dest.Progresses, opt => opt.MapFrom(src => src.Progresses)); // Maps Progresses inside lesson

        CreateMap<LessonDto, Lesson>();

        CreateMap<ProgressDto, Progress>();
        CreateMap<Progress, ProgressDto>();
    }
}
