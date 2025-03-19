export const environment = {
  isDevelopment: false,

  // Course Controller
  baseCoursesUrl: 'http://localhost:5010/api/courses/',
  userEnrolledCoursesUrl:
    'http://localhost:5010/api/courses/student/my-courses',
  userCreatedCoursesUrl:
    'http://localhost:5010/api/courses/instructor/my-courses',

  courseFullDetailsUrl: 'http://localhost:5010/api/courses/full-course/', // ==> {courseId} // courses with lessons and user progresses
  courseBasicDetailsUrl: 'http://localhost:5010/api/courses/', // ==> courses with lessons only
  enrollCourseUrl: 'http://localhost:5010/api/courses/enroll/', // ==> {courseId}
  unenrollCourseUrl: 'http://localhost:5010/api/courses/unenroll/', // ==> {courseId}

  // Lesson Controller
  baseLessonsUrl: 'http://localhost:5010/api/lessons/',
  addLessonProgressUrl: 'http://localhost:5010/api/lessons/progress/', // ==> {lessonId}

  // User Controller
  userRegisterUrl: 'http://localhost:5010/api/users/register',
  userLoginUrl: 'http://localhost:5010/api/users/login',
  userProfileUrl: 'http://localhost:5010/api/users/me', // ==> only for patch (not delete, get, add)
};
